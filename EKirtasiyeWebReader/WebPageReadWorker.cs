using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using EKirtasiye.DBLayer;

namespace EKirtasiyeWebReader
{
    public class WebPageReadWorker
    {

        private bool process = false;
        public int LockedBy { get; set; }

        List<ProductCategory> productCategories = null;
        public void Run(int locked)
        {
            process = true;
            LockedBy = locked;

            Thread thread = new Thread(Worker);
            thread.Start();
        }
        public IdeaCatalog ReadProductPage(string pageUrl)
        {
            if (productCategories == null)
            {
                productCategories = ProductCategoryRepository.GetProductCategories();

            }
            IdeaCatalog ideaCatalog = new IdeaCatalog();

            var htmlDocument = new HtmlAgilityPack.HtmlWeb();

            var document = htmlDocument.Load(pageUrl);

            var productTitle = document.DocumentNode.SelectNodes("//h1").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "product-title");

            var priceSales = document.DocumentNode.SelectNodes("//span").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "price-sales");
            var priceStandart = document.DocumentNode.SelectNodes("//span").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "price-standard");
            var productBrand = document.DocumentNode.SelectNodes("//strong").FirstOrDefault(s => s.Attributes.Contains("itemprop") && s.Attributes["itemprop"].Value == "name");
            var productCode = document.DocumentNode.SelectNodes("//span").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "product-code-span");
            var productDescription = document.DocumentNode.SelectNodes("//div").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "tab-pane active" && s.Attributes["id"].Value == "Details");
            var productCodeStrong = productCode.ChildNodes.FirstOrDefault(s => s.Name == "strong");
            var productRebate = document.DocumentNode.SelectNodes("//span").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "product-price-rate mleft-10");

            var productImagesDiv = document.DocumentNode.SelectNodes("//div").Where(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "product-image-list hidden-xs").ToArray();

            var productCategory = document.DocumentNode.SelectNodes("//ul").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "hide-crumb bchidden");
            var productDisable = document.DocumentNode.SelectNodes("//i").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "fa fa-minus-circle color-out");
            if (productDisable != null)
            {
                throw new Exception("UrunBitti");
            }
            //

            string currentAbbr = "";
            ideaCatalog.Status = true;
            ideaCatalog.ProductUrl = pageUrl;
            ideaCatalog.Tax = "18";
            ideaCatalog.Warrant = "24";
            ideaCatalog.StockType = "Adet";
            ideaCatalog.StockAmount = 10;

            ideaCatalog.Title = productTitle.InnerText;
            ideaCatalog.MarketPrice = (priceStandart == null ? string.Empty : MoneyType(priceStandart.InnerText, ref currentAbbr));
            ideaCatalog.Price1 = MoneyType(priceSales.InnerText, ref currentAbbr);
            ideaCatalog.CurrencyAbbr = currentAbbr;
            ideaCatalog.Label = productTitle.InnerText;
            ideaCatalog.Brand = productBrand.InnerText;
            ideaCatalog.StockCode = productCodeStrong.InnerText;
            ideaCatalog.Details = productDescription.InnerHtml;
            if (productRebate != null)
            {
                var spanRebate = productRebate.ChildNodes.FirstOrDefault(s => s.Name == "span");
                if (spanRebate != null)
                {
                    var textNode = spanRebate.ChildNodes.FirstOrDefault(s => s.Name == "#text");
                    ideaCatalog.RebatePercent = int.Parse(textNode.InnerText.Replace("%", ""));
                }
            }
            int imageCounter = 1;
            foreach (var oneImageDiv in productImagesDiv)
            {
                var aImageNode = oneImageDiv.ChildNodes.Where(s => s.Name == "a");
                if (aImageNode != null)
                {
                    foreach (var aImageNode2 in aImageNode)
                    {

                        string imageLink = string.Empty;
                        var imageNode = aImageNode2.ChildNodes.FirstOrDefault(s => s.Name == "img");
                        imageLink = @"https://www.panelkirtasiye.com" + imageNode.Attributes["src"].Value.Replace(@"/middle/", @"/big/");

                        if (imageCounter == 1)
                            ideaCatalog.Picture1Path = imageLink;
                        if (imageCounter == 2)
                            ideaCatalog.Picture2Path = imageLink;
                        if (imageCounter == 3)
                            ideaCatalog.Picture3Path = imageLink;
                        if (imageCounter == 4)
                            ideaCatalog.Picture4Path = imageLink;


                        imageCounter++;
                    }
                }
            }

            int categoryCounter = 1;
            var subCategoryArry = productCategory.ChildNodes.Where(s => s.Name == "li").Skip(1).ToArray();
            for (int i = (subCategoryArry.Length > 3 ? subCategoryArry.Length - 3 : 0); i < subCategoryArry.Length; i++)
            {
                var oneCategoryNode = subCategoryArry[i];
                var categoryANode = oneCategoryNode.ChildNodes.FirstOrDefault(s => s.Name == "a");
                var category = productCategories.FirstOrDefault(s => s.CategoryName.Trim() == categoryANode.InnerText.Trim());
                if (category == null)
                {
                    ProductCategory productC = new ProductCategory()
                    {
                        CategoryName = categoryANode.InnerText.Trim(),
                        UpId =(ideaCatalog.CategoryId!=0? ideaCatalog.CategoryId: ideaCatalog.MainCategoryId),
                        CategoryUrl= "https://www.panelkirtasiye.com" + categoryANode.Attributes["href"].Value
                    };
                    ProductCategoryRepository.InsertCategory(productC);
                    category = productC;

                    Trace.WriteLine("Bulunamadı");
                    //throw new Exception("Category yok");
                }
                if (categoryCounter == 1)
                {
                    ideaCatalog.MainCategoryId = category.Id;
                    ideaCatalog.MainCategory = category.CategoryName;
                }
                if (categoryCounter == 2)
                {
                    ideaCatalog.CategoryId = category.Id;
                    ideaCatalog.Category = category.CategoryName;
                }

                if (categoryCounter == 3)
                {
                    ideaCatalog.SubCategoryId = category.Id;
                    ideaCatalog.SubCategory = category.CategoryName.Trim();

                }
                categoryCounter++;
            }
            if (subCategoryArry.Length > 3)
            {
                Trace.WriteLine("dddd");
            }

            IdeaCatalogRepository.InsertIdeaCatalog(ideaCatalog);
            return ideaCatalog;
        }

        private string MoneyType(string price, ref string moneyType)
        {
            string[] moneyTypes = new string[] { "TL", "USD", "EURO" };

            foreach (var tmpStr in moneyTypes)
            {
                if (price.Contains(tmpStr))
                {
                    moneyType = tmpStr;

                    return price.Replace(moneyType, "");
                }
            }
            return price;

        }
        private void Worker()
        {
            while (process)
            {
                try
                {
                    var productList = IdeaCatalogRepository.GetReadProductUrls(LockedBy);
                    if (productList.Count == 0)
                    {
                        return;
                    }
                    productCategories = ProductCategoryRepository.GetProductCategories();
                    foreach (var productUrl in productList)
                    {
                        try
                        {
                            var ideaProduct = ReadProductPage(productUrl.ProductLink);
                            IdeaCatalogRepository.UpdateProductUrl(productUrl.Id, 1);

                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex);
                            if (ex.Message == "UrunBitti")
                            {
                                IdeaCatalogRepository.UpdateProductUrl(productUrl.Id, 1);
                            }
                            else
                            {
                                IdeaCatalogRepository.UpdateProductUrl(productUrl.Id, 5);
                            }


                        }
                    }

                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                }

            }
        }

    }
}
