using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EKirtasiye.N11;
using HtmlAgilityPack;
using Microsoft.Win32;

namespace ETicaretWinApp
{
    public partial class FormCerenImport : Form
    {
        private ProductUrl _productUrl = null;
        private bool stopprocess = false;
        List<IdeaCatalogCategoryMatch> ideaCategegoryMatch = null;
        List<string> ldbProductList = new List<string>();
        ProductSaleService productHelper = null;
        ProductHelper productHelperPrice = null;
        string _providerName = string.Empty;
        public FormCerenImport(string providerName)
        {
            _providerName = providerName;
            InitializeComponent();
            ideaCategegoryMatch = ApiHelper.GetIdeaCatalogCategoryMatches();

            var _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
            var _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
            productHelper = new ProductSaleService(_apiKey, _secretKey);
            productHelperPrice = new ProductHelper(_apiKey, _secretKey);

        }

        public string RemoveTurkish(string s)
        {
            string v = s.ToUpper();
            v = v.Replace("İ", "I");
            v = v.Replace("Ö", "O");
            v = v.Replace("Ğ", "G");
            v = v.Replace("Ş", "S");
            v = v.Replace("Ç", "C");
            v = v.Replace("Ü", "U");
            v = v.Replace('\u2029', ' ');
            v = v.Replace('\u2028', ' ');
            v = v.Replace(" ", "");

            return v.Trim();
        }
        private void SetCatalogMatch(IdeaCatalog ideaCatalog)
        {
            if (!string.IsNullOrEmpty(ideaCatalog.MainCategory))
            {
                var mainCategory = ideaCategegoryMatch.FirstOrDefault(s => s.ColumnName == "MainCategory" && RemoveTurkish(s.ImportName) == RemoveTurkish(ideaCatalog.MainCategory));
                if (mainCategory != null)
                {
                    ideaCatalog.MainCategoryId = mainCategory.MainCategoryId;
                    ideaCatalog.CategoryId = mainCategory.SubCategoryId;
                    ideaCatalog.SubCategoryId = mainCategory.SubSubCategoryId;
                }
            }

            if (!string.IsNullOrEmpty(ideaCatalog.Category))
            {
                var subCategory = ideaCategegoryMatch.FirstOrDefault(s => s.ColumnName == "Category" && RemoveTurkish(s.ImportName) == RemoveTurkish(ideaCatalog.Category));
                if (subCategory != null)
                {
                    if (ideaCatalog.MainCategoryId == 0)
                    {
                        ideaCatalog.MainCategoryId = subCategory.MainCategoryId;
                    }
                    if (ideaCatalog.CategoryId == 0)
                    {
                        ideaCatalog.CategoryId = subCategory.SubCategoryId;
                    }
                    if (subCategory.SubSubCategoryId == 0)
                    {
                        ideaCatalog.SubCategoryId = subCategory.SubSubCategoryId;
                    }
                }
            }

            if (!string.IsNullOrEmpty(ideaCatalog.SubCategory))
            {
                var subCategory = ideaCategegoryMatch.FirstOrDefault(s => s.ColumnName == "SubCategory" && RemoveTurkish(s.ImportName) == RemoveTurkish(ideaCatalog.SubCategory));
                if (subCategory != null)
                {
                    if (ideaCatalog.MainCategoryId == 0)
                    {
                        ideaCatalog.MainCategoryId = subCategory.MainCategoryId;
                    }

                    if (ideaCatalog.CategoryId == 0)
                    {
                        ideaCatalog.CategoryId = subCategory.SubCategoryId;
                    }
                    if (subCategory.SubSubCategoryId == 0)
                    {
                        ideaCatalog.SubCategoryId = subCategory.SubSubCategoryId;
                    }
                }
            }
        }
        public string ConvertHtmlCodesToTurkish(string _str)
        {
            return HelperXmlRead.ConvertHtmlCodesToTurkish(_str);
        }


        private void FormCerenImport_Load(object sender, EventArgs e)
        {

        }

        private async void buttonGetProductLinks_Click(object sender, EventArgs e)
        {
            try
            {

                var productListUpdate = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                {
                    N11Export = "Evet",
                    ProductStatus = "Aktif",
                    StokSource = _providerName
                });
                ldbProductList = productListUpdate.Select(s => s.StockCode).ToList();

                string userName = ApplicationSettingHelper.ReadValue(_providerName, "UserName");
                string password = ApplicationSettingHelper.ReadValue(_providerName, "Password");
                string url = ApplicationSettingHelper.ReadValue(_providerName, "Url");
                string categroy = ApplicationSettingHelper.ReadValue(_providerName, "Category");
                CerenApi cerenApi = new CerenApi(url);
                var result = await cerenApi.Login(userName, password);

                var category = await cerenApi.GetCategoryProducts(categroy);
                ProcessProduct(category.data, cerenApi);

                for (int i = 2; i <= category.data.pagination.total_page; i++)
                {
                    try
                    {
                        var categorySub = await cerenApi.GetCategoryProducts(categroy, i);
                        ProcessProduct(categorySub.data, cerenApi);
                        Thread.Sleep(600);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        // throw;
                    }
                }
                foreach (var oneproductCode in ldbProductList)
                {
                    try
                    {
                        var stokSearch = await cerenApi.GetProductCode(oneproductCode);
                        var ideaCatalog = productListUpdate.FirstOrDefault(s => s.StockCode == oneproductCode);
                        if (stokSearch.data.list.Length == 0)
                        {
                            ideaCatalog.Status = false;
                            ApiHelper.InsertIdeaCatalog(ideaCatalog);

                            var resultdisable = productHelper.DisableProduct(ideaCatalog.N11ProductId);
                        }
                        else
                        {
                            var stokstate = stokSearch.data.list[0].StokDurumu.Any(s => s.StokState == "Var");
                            if (!stokstate)
                            {
                                ideaCatalog.Status = false;
                                ApiHelper.InsertIdeaCatalog(ideaCatalog);

                                var resultdisable = productHelper.DisableProduct(ideaCatalog.N11ProductId);

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                    }

                }

                MessageBox.Show("işlem Bitti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }
        private bool ConvertStockState(string storage,string state, out int stock)
        {
            if (_providerName=="Ceren" && storage.Trim() != "KARTAL")
            {

                stock = 0;
                return false;
            }
            if (state == "Var")
            {
                stock = 5;
                return true;
            }
            else if (state == "Yok")
            {
                stock = 0;
                return false;
            }
            else if (state.Contains("+"))
            {
                stock = int.Parse(state.Replace("+", ""));
                return true;
            }
            else
            {
                stock = 0;
                return false;
            }
        }
        private async void ProcessProduct(Class.DataCategory dataCategory, CerenApi cerenApi)
        {

            foreach (var cerenProduct in dataCategory.list)
            {
                try
                {

                    var ideaCatalog = IsImportedProduct(cerenProduct.StockCode);
                    int stockMount = 0;
                    if (ideaCatalog == null)
                    {

                        if (!cerenProduct.StokDurumu.Any(s => ConvertStockState(s.StorageName,s.StokState, out stockMount)))
                        {
                            continue;
                        }
                        ApiHelper.SaveProductUrl(new ProductUrl()
                        {
                            ProductName = cerenProduct.ProductName,
                            StockCode = cerenProduct.StockCode,
                            ProductLink = $"http://www.{_providerName}.com/product/show/" + cerenProduct.Id,
                            ProductSource = _providerName,
                            StockState = cerenProduct.StokDurumu.Any(s => ConvertStockState(s.StorageName,s.StokState, out stockMount))
                        });
                    }
                    else
                    {
                        var status = cerenProduct.StokDurumu.Any(s => ConvertStockState(s.StorageName, s.StokState, out stockMount));
                        /*
                        if (!status && ideaCatalog.N11ProductId != 0 && ideaCatalog.ApprovalStatus != "2")
                        {   //Pasif yapılacak
                            var result = productHelper.DisableProduct(ideaCatalog.N11ProductId);
                           // Thread.Sleep(new TimeSpan(0, 0, 10));
                           

                            if (!result)
                            {
                                System.Diagnostics.Debug.WriteLine("Pasif yapamadım");
                            }
                            ApiHelper.UpdateShopProductState(new EKirtasiye.Model.UpdateProductShopSaleRequest()
                            {
                                Id = ideaCatalog.Id,
                                ShopName = "N11",
                                ApprovalStatus = "2"
                            });

                        }
                        else
                        {*/
                        bool priceChanged = false;
                        var cerenPrice = cerenProduct.ProductPrice.Replace(ideaCatalog.CurrencyAbbr, "").Trim();
                        priceChanged = ideaCatalog.Price1.Trim() != cerenPrice;
                        ideaCatalog.Price1 = cerenProduct.ProductPrice.Replace(ideaCatalog.CurrencyAbbr, "");
                        var priceTemp = float.Parse(ideaCatalog.Price1.Replace(".", ""));
                        var taxRate = float.Parse("1," + ideaCatalog.Tax);
                        ideaCatalog.StockAmount = stockMount;
                        ideaCatalog.MarketPrice = (priceTemp * taxRate).ToString();
                        ideaCatalog.Status = status;
                        ApiHelper.InsertIdeaCatalog(ideaCatalog);
                        /*
                        if (ideaCatalog.N11ProductId != 0)
                        {
                            if (priceChanged)
                            {
                                float price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;
                                if (price > 150)
                                {
                                    price = price + 20;
                                }
                                var updatePrice = productHelperPrice.UpdateProductPrice(ideaCatalog.N11ProductId, (decimal)price);
                                if (!updatePrice)
                                {
                                    System.Diagnostics.Debug.WriteLine("ss");
                                }
                                Thread.Sleep(new TimeSpan(0, 0, 10));

                            }
                        }*/
                        //}*/

                        ldbProductList.Remove(ideaCatalog.StockCode);
                    }
                }
                catch (Exception ex)
                {
                    //await cerenApi.Login("kemalkesab@gmail.com", "QYJ5ZW_UQN!9");
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }
        private IdeaCatalog IsImportedProduct(string stockCode)
        {
            var productLt = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
            {
                StokSource = _providerName,
                StokCodeList = new string[] { stockCode },
                ProductStatus = "Tümü"
            });

            return (productLt.Count == 1 ? productLt[0] : null);
        }
        int pageCounter = 1;
        private async void buttonGetProduct_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"{_providerName} için ürünleri almak istediğinizden emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                stopprocess = false;
                var haveDocument = true;

                string userName = ApplicationSettingHelper.ReadValue(_providerName, "UserName");
                string password = ApplicationSettingHelper.ReadValue(_providerName, "Password");
                string url = ApplicationSettingHelper.ReadValue(_providerName, "Url");
                string categroy = ApplicationSettingHelper.ReadValue(_providerName, "Category");
                CerenApi cerenApi = new CerenApi(url);
                var result = await cerenApi.Login(userName, password);

                while (haveDocument)
                {
                    var productList = ApiHelper.GetIdeaCatalogFromBarcode((int)nuUpDownLocked.Value, _providerName);
                    if (productList.Count == 0)
                    {

                        haveDocument = false;
                        return;
                    }


                    foreach (var productUrl in productList)
                    {
                        try
                        {

                            var productId = productUrl.ProductLink.Replace($"http://www.{_providerName}.com/product/show/", "");

                            var product = await cerenApi.GetProductDetail(int.Parse(productId));


                            var productLt = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                            {
                                StokSource = _providerName,
                                StokCodeList = new string[] { product.data.StockCode },
                                ProductStatus = "Tümü"
                            });
                            IdeaCatalog ideaCatalog = null;
                            if (productLt.Count == 0)
                            {
                                ideaCatalog = new IdeaCatalog();
                                ideaCatalog.Title = ConvertHtmlCodesToTurkish(product.data.ProductName);
                                ideaCatalog.Label = ideaCatalog.Title;
                                ideaCatalog.StockCode = product.data.StockCode;
                                ideaCatalog.ProductSource = _providerName;
                                ideaCatalog.StockType = "Adet";
                                ideaCatalog.Status = false;
                                ideaCatalog.CurrencyAbbr = product.data.ParaBirimi;
                                ideaCatalog.WebExportStatus = "Hazir";
                                ideaCatalog.Tax = "18";
                            }
                            else
                            {
                                ideaCatalog = productLt[0];
                            }

                            ideaCatalog.Price1 = product.data.NetFiyat.Replace(ideaCatalog.CurrencyAbbr, "");
                            _productUrl = productUrl;

                            int counterImage = 0;
                            if (ideaCatalog.Id == 0)
                            {

                                foreach (var oneNode in product.data.UrunResimleri)
                                {
                                    var filePath = (_providerName == "Ceren" ? "http://77.75.33.201/C03/" : "https://derya.natyazilim.com.tr/rsm/") + oneNode.DosyaAdi;
                                    if (counterImage == 0)
                                    {
                                        ideaCatalog.Picture1Path = filePath;
                                    }
                                    if (counterImage == 1)
                                    {
                                        ideaCatalog.Picture2Path = filePath;
                                    }
                                    if (counterImage == 2)
                                    {
                                        ideaCatalog.Picture3Path = filePath;
                                    }
                                    if (counterImage == 3)
                                    {
                                        ideaCatalog.Picture4Path = filePath;
                                    }
                                    counterImage++;
                                }
                            }
                            if (product.data.UrunOzellikleri.Any(s => s.OzellikAdi.Contains("Marka")))
                            {
                                ideaCatalog.Brand = product.data.UrunOzellikleri.FirstOrDefault(s => s.OzellikAdi.Contains("Marka")).Ozellik;
                            }

                            var priceTemp = float.Parse(ideaCatalog.Price1.Replace(".", ""));
                            var taxRate = float.Parse("1," + ideaCatalog.Tax);
                            ideaCatalog.MarketPrice = (priceTemp * taxRate).ToString();
                            int stockMount = 0;
                            ideaCatalog.Status = product.data.StokDurumu.Any(s => ConvertStockState(s.StorageName, s.StokState, out stockMount));
                            ideaCatalog.StockAmount = (ideaCatalog.Status ? stockMount : 0);
                            var barcodeF = product.data.Barkodlar.FirstOrDefault(s => s.StokTuru == "ADT" || s.StokTuru == "ADET");
                            if (barcodeF != null)
                            {
                                ideaCatalog.Barcode = barcodeF.Barkod;
                            }
                            /* if (product.data.Barkodlar.Any(s => s.Barkod != ideaCatalog.Barcode))
                             {
                                 ideaCatalog.Barcodes = product.data.Barkodlar.Where(s => s.Barkod != ideaCatalog.Barcode).Select(s => new IdeaCatalog_Barcode() { Barcode = s.Barkod, StockType = s.StokTuru }).ToArray();

                             }*/
                            if (ideaCatalog.Id == 0)
                            {
                                string ozellikler = "<table>";
                                foreach (var htmlNode in product.data.UrunOzellikleri)
                                {
                                    ozellikler += $"<tr><td>{htmlNode.OzellikAdi}</td><td>:</td><td>{htmlNode.Ozellik}</td></tr>";

                                }
                                ozellikler += "</table>";
                                ideaCatalog.Details = ozellikler;
                            }


                            int counter = 0;
                            var categoryList = product.data.UrunKategorys.Select(s => s.KategoryAdi).ToArray();
                            if (product.data.UrunKategorys.Length > 3)
                            {
                                int newSkip = product.data.UrunKategorys.Length - 3;
                                categoryList = categoryList.Skip(newSkip).ToArray();
                            }
                            foreach (var htmlNode in categoryList)
                            {

                                if (counter == 0)
                                {
                                    ideaCatalog.MainCategory = ConvertHtmlCodesToTurkish(htmlNode);
                                }
                                if (counter == 1)
                                {
                                    ideaCatalog.Category = ConvertHtmlCodesToTurkish(htmlNode);
                                }

                                if (counter == 2)
                                {
                                    ideaCatalog.SubCategory = ConvertHtmlCodesToTurkish(htmlNode);
                                }
                                counter++;

                            }
                            SetCatalogMatch(ideaCatalog);
                            if (ApiHelper.InsertIdeaCatalog(ideaCatalog))
                            {
                                _productUrl.ReadProductPage = 1;
                            }
                            else
                            {
                                _productUrl.ReadProductPage = 2;
                            }


                            ApiHelper.SaveProductUrl(_productUrl);
                        }
                        catch (Exception ex)
                        {
                            productUrl.ReadProductPage = 5;

                            ApiHelper.SaveProductUrl(productUrl);
                            Trace.WriteLine(ex);
                        }


                    }
                }
            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }
            //LoginBrowser();
        }


    }
}
