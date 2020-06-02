using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.Model;
using FluentFTP;
using HtmlAgilityPack;
using Microsoft.Win32;

namespace ETicaretWinApp
{
    public partial class FormProductWebBrowser : Form
    {
        List<IdeaCatalog> _ideaCatalogs = null;
        bool documentComplated = false;
        FtpClient ftpClient = null;
        public FormProductWebBrowser(List<IdeaCatalog> ideaCatalogs)
        {
            InitializeComponent();


            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                Key.SetValue(appName, 99999, RegistryValueKind.DWord);

            _ideaCatalogs = ideaCatalogs;
        }
        public FormProductWebBrowser()
        {
            InitializeComponent();


            ftpClient = new FtpClient(System.Configuration.ConfigurationManager.AppSettings["FTPAdress"]);
            ftpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = System.Configuration.ConfigurationManager.AppSettings["FTPUserName"],
                Password = System.Configuration.ConfigurationManager.AppSettings["FTPPassword"]
            };
            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                Key.SetValue(appName, 99999, RegistryValueKind.DWord);


        }
       
       

        private void ReadWebResult(IdeaCatalog ideaCatalog)
        {

            webBrowserProduct.DocumentCompleted -= WebBrowserProduct_DocumentCompleted;
            try
            {
                if (webBrowserProduct.Document.Body == null)
                    return;
                var productLinks = GoogleSearchHtmlExtractor.GetProductLinks(webBrowserProduct.Document.Body.InnerHtml, ideaCatalog.Title).OrderBy(s => s.PageOrder).ToArray();

                if (productLinks.Length == 0)
                {
                    ApiHelper.UpdateProductWebExportState(new EKirtasiye.Model.UpdateProductStatusRequest()
                    {
                        WebStatus = "Bilgi Yok",
                        ProductIdList = new List<int> { ideaCatalog.Id }
                    });
                }
                var productLink = productLinks.OrderBy(s => s.PageOrder).FirstOrDefault();

                if (productLink != null)
                {
                    if (string.IsNullOrEmpty(ideaCatalog.Picture1Path))
                    {
                        GoogleSearchHtmlExtractor.SavePictureToWeb(ideaCatalog, productLink.ImageBase64);
                    }
                    var price = productLink.ProductPrice.Replace("₺", "");
                    ApiHelper.UpdateProductPrice(new EKirtasiye.Model.UpdateProductPriceRequest()
                    {
                        ProductId = ideaCatalog.Id,
                        WebPrice = price
                    });
                    try
                    {
                        string webStatus = "Fiyat Kontrol";
                        if (ideaCatalog.ProductSource == "Stok")
                        {
                            var priceMaliyet = string.IsNullOrEmpty(ideaCatalog.MarketPrice) ? 0 : double.Parse(ideaCatalog.MarketPrice);
                            var webPrice = double.Parse(price);
                            webStatus = (priceMaliyet > webPrice) ? "Fiyat Kontrol" : "Fiyat Update";
                        }
                        else if (ideaCatalog.ProductSource == "Ceren")
                        {
                            var priceMaliyet = double.Parse(ideaCatalog.MarketPrice);
                            var webPrice = double.Parse(price);
                            webStatus = (priceMaliyet > webPrice) ? "Fiyat Kontrol" : "Fiyat Update";
                        }
                        else
                        {
                            var priceMaliyet = double.Parse(ideaCatalog.MarketPrice) * double.Parse("1," + ideaCatalog.Tax);
                            var webPrice = double.Parse(price);

                            webStatus = (priceMaliyet > webPrice) ? "Fiyat Kontrol" : "Fiyat Update";
                        }


                        ApiHelper.UpdateProductWebExportState(new EKirtasiye.Model.UpdateProductStatusRequest()
                        {
                            WebStatus = webStatus,
                            ProductIdList = new List<int>() { ideaCatalog.Id }
                        });
                    }
                    catch (Exception ex)
                    {

                        Trace.WriteLine(ex);
                    }
                }

                var productSaveList = productLinks.Select(s => new ProductWebSearchResult()
                {
                    LinkName = s.ProductName,
                    ProductId = ideaCatalog.Id,
                    //ProductImage = GoogleSearchHtmlExtractor.SaveAndUploadImage(s.ImageBase64),
                    ProductPrice = s.ProductPrice,
                    ProductSimilarity = s.Similarity * 100,
                    ProductUrl = s.ProductImageHref
                }).ToList();

                ApiHelper.SaveProductWebResult(productSaveList);
            }
            catch (Exception ex)
            {

                Trace.WriteLine(ex);

            }
            finally
            {
                webBrowserProduct.DocumentCompleted += WebBrowserProduct_DocumentCompleted;
            }

        }

        private void WebBrowserProduct_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            documentComplated = true;
        }

        private void ProcessProduct()
        {
            try
            {
                foreach (var ideaCatalog in _ideaCatalogs)
                {
                    string tmpFile = "";
                    try
                    {
                        documentComplated = false;
                        //  var htmlDocument = new HtmlAgilityPack.HtmlWeb();
                        textBoxProductName.Text = ideaCatalog.Title;
                        string searchParam = HelperXmlRead.ConvertHtmlCodesToTurkish(!string.IsNullOrEmpty(ideaCatalog.Title) ? ideaCatalog.Title : ideaCatalog.Label).Replace("%", "yüzde");
                        if (!string.IsNullOrEmpty(ideaCatalog.Barcode))
                        {
                            searchParam = ideaCatalog.Barcode;
                        }
                        string pageUrl = $@"https://www.google.com/search?q={ searchParam }&tbm=shop";
                        //  var document = htmlDocument.Load(pageUrl);
                        /*
                        var files = Directory.GetFiles(@"D:\Personel\PersonelProject\WebImage\", ideaCatalog.Id.ToString() + "_*.*");
                        if (files.Length != 0)
                            continue;
                        */
                        webBrowserProduct.Navigate(pageUrl);

                        while (!documentComplated)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();

                        }

                        ReadWebResult(ideaCatalog);

                        // Thread.Sleep(5000);
                    }
                    catch (Exception ex)
                    {
                        //IdeaCatalogRepository.UpdateImageState(ideaCatalog, 5);
                        Trace.WriteLine(ex);
                    }
                    finally
                    {

                        Thread.Sleep(5000);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private HtmlNode GetElementByName(HtmlNode htmlElement, string elementName)
        {
            foreach (var item in htmlElement.ChildNodes)
            {
                if (item.Name == elementName)
                {
                    return item;
                }
                if (item.ChildNodes.Count != 0)
                {
                    var newItem = GetElementByName(item, elementName);
                    if (newItem != null)
                    {
                        return newItem;
                    }
                }
            }

            return null;
        }
        private HtmlNode GetElementByName(HtmlNode htmlElement, string elementName, string className)
        {
            foreach (var item in htmlElement.ChildNodes)
            {
                if (item.Name == elementName && item.Attributes.Contains("class") && item.Attributes["class"].Value.Contains(className))
                {
                    return item;
                }
                if (item.ChildNodes.Count != 0)
                {
                    var newItem = GetElementByName(item, elementName, className);
                    if (newItem != null)
                    {
                        return newItem;
                    }
                }
            }

            return null;
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
        private HtmlNode GetElementByNameWithLabel(HtmlNode htmlElement, string elementName, string name)
        {
            foreach (var item in htmlElement.ChildNodes)
            {
                if (item.Name == elementName)
                {
                    return item;
                }
                if (item.ChildNodes.Count != 0)
                {
                    var newItem = GetElementByNameWithLabel(item, elementName, name);
                    if (newItem != null)
                    {
                        return newItem;
                    }
                }
            }

            return null;
        }


        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            documentComplated = true;
        }

        private void textBoxProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string pageUrl = $@"https://www.google.com/search?q={ textBoxProductName.Text.Replace("%", "yüzde") }&tbm=shop";
                //  var document = htmlDocument.Load(pageUrl);          
                var htmlDocument = new HtmlAgilityPack.HtmlWeb();

                // var document= htmlDocument.Load(pageUrl,"POST");


                webBrowserProduct.Navigate(pageUrl);
                while (!documentComplated)
                {
                    Thread.Sleep(100);
                    Application.DoEvents();

                }

                ReadWebResult(new IdeaCatalog() { Title = textBoxProductName.Text });

            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ProcessProduct();
        }
    }
}
