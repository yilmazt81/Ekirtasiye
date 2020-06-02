using EKirtasiye.DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKirtasiyeWebReader
{
    public partial class Form1 : Form
    {

        private string localTempFolder = @"D:\Personel\PersonelProject\PanelKirtasiye\Files";
        public Form1()
        {
            InitializeComponent();

            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        private void buttonProductCategory_Click(object sender, EventArgs e)
        {
            var productList = ProductCategoryRepository.GetProductCategories().Where(s => s.Id == 4351);

            foreach (var product in productList)
            {
                GetCategoryList(product);
            }
        }

        private void GetCategoryList(ProductCategory productCategory)
        {
            try
            {


                var categroyList = GetFromWebPage(productCategory);

                foreach (var category in categroyList)
                {

                    ProductCategoryRepository.InsertCategory(category);

                    GetCategoryList(category);
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private List<ProductCategory> GetFromWebPage(ProductCategory product)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();

            try
            {
                var htmlDocument = new HtmlAgilityPack.HtmlWeb();

                var document = htmlDocument.Load(product.CategoryUrl);


                var categoryUl = document.DocumentNode.SelectNodes("//ul").FirstOrDefault(s => s.Attributes.Contains("class") && s.Attributes["Class"].Value == "list-unstyled sub-categories");

                var liList = categoryUl.ChildNodes.Where(s => s.Name == "li").ToArray();
                foreach (var oneCategory in liList)
                {
                    if (oneCategory.Name == "li")
                    {
                        var liLink = oneCategory.ChildNodes.SingleOrDefault(s => s.Name == "a");
                        productCategories.Add(new ProductCategory()
                        {
                            CategoryName = liLink.InnerText,
                            CategoryUrl = "https://www.panelkirtasiye.com" + liLink.Attributes["href"].Value,
                            UpId = product.Id
                        });

                    }
                }

                if (productCategories.Any(s => s.CategoryName == product.CategoryName))
                {
                    productCategories.Clear();
                }
            }
            catch (Exception ex)
            {

                Trace.WriteLine(ex);
            }


            return productCategories;
        }

        private List<ProductUrl> ReadPageCategoryView(string pageUrl)
        {
            List<ProductUrl> webProductUrls = new List<ProductUrl>();
            var htmlDocument = new HtmlAgilityPack.HtmlWeb();

            var document = htmlDocument.Load(pageUrl);
            var productList = document.DocumentNode.SelectNodes("//div").Where(s => s.Attributes.Contains("class") && s.Attributes["Class"].Value == "product relative").ToList();

            foreach (var oneProduct in productList)
            {
                string productUrl = string.Empty, productName = string.Empty;
                var oneChild = oneProduct.ChildNodes.FirstOrDefault(s => s.Name == "a");

                if (oneChild.Name == "a")
                {
                    productUrl = "https://www.panelkirtasiye.com" + oneChild.Attributes["href"].Value;

                }
                //var header = oneChild.ChildNodes.SingleOrDefault(s => s.Name == "h4");

                webProductUrls.Add(new ProductUrl()
                {
                    ProductLink = productUrl,
                    ProductName = productName
                });


            }
            return webProductUrls;
        }

        private List<ProductUrl> ReadCategoryPages(ProductCategory productCategory)
        {
            string pageUrl = productCategory.CategoryUrl;
            List<ProductUrl> webProductUrls = new List<ProductUrl>();
            var htmlDocument = new HtmlAgilityPack.HtmlWeb();

            var document = htmlDocument.Load(pageUrl);
            var pagingDivs = document.DocumentNode.SelectNodes("//div").Where(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "pagination pull-right no-margin-top").ToArray();
            if (pagingDivs.Length != 0)
            {
                var pagingDiv = pagingDivs.FirstOrDefault();
                int maxPageNumber = 0;
                foreach (var oneChild in pagingDiv.ChildNodes)
                {
                    if (oneChild.Name == "ul")
                    {
                        foreach (var liChild in oneChild.ChildNodes.Where(s => s.Name == "li"))
                        {
                            var aChild = liChild.ChildNodes.FirstOrDefault(s => s.Name == "a" && s.Attributes.Contains("class") && s.Attributes["class"].Value == "last");
                            if (aChild != null)
                            {

                                var pageurlLink = aChild.Attributes["href"].Value;
                                var lastIndex = pageurlLink.Split('=');
                                maxPageNumber = int.Parse(lastIndex.LastOrDefault());
                                break;
                            }

                        }
                    }
                }

                for (int i = 1; i <= maxPageNumber; i++)
                {
                    var tmpP = ReadPageCategoryView(pageUrl + "?rpg=" + i);

                    foreach (var oneP in tmpP)
                    {
                        oneP.ProductCategoryId = productCategory.Id;
                        IdeaCatalogRepository.SaveProductUrl(oneP);

                        webProductUrls.Add(oneP);

                    }

                }

                return webProductUrls;
            }
            else
            {
                webProductUrls = ReadPageCategoryView(pageUrl);
                foreach (var oneP in webProductUrls)
                {
                    oneP.ProductCategoryId = productCategory.Id;
                    IdeaCatalogRepository.SaveProductUrl(oneP);


                }
            }
            return webProductUrls;
        }


        private void buttonGetProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var productList = ProductCategoryRepository.GetProductCategories();

                foreach (var productCategory in productList.Where(s => s.Id >= 4570))
                {
                    var webUrls = ReadCategoryPages(productCategory);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            WebPageReadWorker pageReadWorker = new WebPageReadWorker();
            pageReadWorker.ReadProductPage(@"https://www.panelkirtasiye.com/kirkpabuc-konusan-hayvanlar-7022");

            */
            for (int i = 1; i < 10; i++)
            {
                WebPageReadWorker pageReadWorker = new WebPageReadWorker();
                pageReadWorker.Run(i);
            }
            /*
             WebPageReadWorker pageReadWorker = new WebPageReadWorker();
             pageReadWorker.ReadProductPage("https://www.panelkirtasiye.com/cross-bailey-medalist-tukenmez-kalem-at0452ds-6");
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var htmlDocument = new HtmlAgilityPack.HtmlWeb();

            var document = htmlDocument.Load("https://www.panelkirtasiye.com/");

            var pagingDivs = document.DocumentNode.SelectNodes("//img").Where(s =>  s.Attributes["src"].Value.Contains("/skins/shared/Images/menu/")).ToArray();

            foreach (var oneItem in pagingDivs)
            {
                var url = "https://www.panelkirtasiye.com/" + oneItem.Attributes["src"].Value;
                WebClient webClient = new WebClient();
                webClient.DownloadFile(url, @"C:\Users\turkyilmaz.ozkan\Desktop\IdeaSoft-Muhesebe-Çıktısı-Örnek\Menu\" + Path.GetFileName(url));
            }

        }
    }
}
