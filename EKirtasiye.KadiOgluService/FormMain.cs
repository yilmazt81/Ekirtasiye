
using EKirtasiye.DBLayer;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace EKirtasiye.KadiOgluService
{
    public partial class FormMain : Form
    {
        KadiService.WebService1SoapClient soapClient = null;
        public FormMain()
        {
            InitializeComponent();

            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            soapClient = new KadiService.WebService1SoapClient("WebService1Soap");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private string ConvertStokType(string strStok)
        {
            if (strStok == "ADT")
                return "Adet";
            if (strStok == "PKT")
                return "Paket";
            if (strStok == "KOLÝ")
                return "Koli";

            if (string.IsNullOrEmpty(strStok))
            {
                return "Adet";
            }
            else
            {
                return "No";
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var xmlUrl = @"https://b2b.kadioglukirtasiye.com.tr/xml/urunler.xml";
                var localXml = @"D:\urunler.xml";
                /*
                WebClient webClient = new WebClient();
                webClient.DownloadFile(xmlUrl, localXml);
                */
                //  var urunListesi = soapClient.UrunListesi("120.34.3036", "89s2e245", "");

                XDocument xDocument = XDocument.Load(localXml);

                List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();

                foreach (XElement element in xDocument.Root.Elements("Urun"))
                {

                    try
                    {
                        var ideaC = new IdeaCatalog()
                        {
                            StockCode = "kk_" + element.Element("CODE").Value,
                            Title = element.Element("NAME").Value,
                            Label = element.Element("NAME").Value,
                            MainCategory = element.Element("UST_KAT").Value,
                            Category = element.Element("ORTA_KAT").Value,
                            SubCategory = element.Element("ALT_KAT").Value,
                            StockAmount = int.Parse(element.Element("STOK").Value),
                            Price1 = element.Element("FIYAT").Value,
                            Price2 = element.Element("FIYAT_HAM").Value,
                            Tax = element.Element("VAT").Value,
                            CurrencyAbbr = "TL",
                            Barcode = element.Element("_BARKOD").Element("BIRIM_1_BARCODE").Value,
                            Details = element.Element("OZELLIK_1").Value + " " + element.Element("OZELLIK_2").Value + " " + element.Element("OZELLIK_3").Value,
                            ProductUrl = $"http://b2b.kadioglukirtasiye.com.tr/urunDetay.aspx?ProdID={ element.Element("ID").Value }",
                            StockType = ConvertStokType(element.Element("_BARKOD").Element("BIRIM_1_ADI").Value),
                            Picture1Path = element.Element("RESIM1").Value,



                        };
                        ideaC.Status = (ideaC.StockAmount > 0);
                        var array = ideaC.Title.Split(' ');
                        ideaC.Brand = array[0].Trim();

                        if (!string.IsNullOrEmpty(ideaC.MainCategory))
                        {

                            ProductCategory productC = new ProductCategory()
                            {
                                CategoryName = ideaC.MainCategory.Trim(),
                                UpId = 0,
                                CategoryUrl = "https://www.kadioglukirtasiye.com/" + ideaC.MainCategory
                            };
                            ProductCategoryRepository.InsertCategory(productC);
                            ideaC.MainCategoryId = productC.Id;
                        }

                        if (!string.IsNullOrEmpty(ideaC.Category))
                        {

                            ProductCategory productC = new ProductCategory()
                            {
                                CategoryName = ideaC.Category.Trim(),
                                UpId = ideaC.MainCategoryId,
                                CategoryUrl = "https://www.kadioglukirtasiye.com/" + ideaC.Category
                            };
                            ProductCategoryRepository.InsertCategory(productC);
                            ideaC.CategoryId = productC.Id;
                        }
                        if (!string.IsNullOrEmpty(ideaC.SubCategory))
                        {

                            ProductCategory productC = new ProductCategory()
                            {
                                CategoryName = ideaC.Category.Trim(),
                                UpId = ideaC.CategoryId,
                                CategoryUrl = "https://www.kadioglukirtasiye.com/" + ideaC.SubCategory
                            };
                            ProductCategoryRepository.InsertCategory(productC);
                            ideaC.SubCategoryId = productC.Id;
                        }
                        IdeaCatalogRepository.InsertIdeaCatalog(ideaC);
                        ideaCatalogs.Add(ideaC);
                    }
                    catch (Exception ex)
                    {

                        Trace.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        bool documentComplated = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                var listProduct = IdeaCatalogRepository.GetFindPictureIdeaCatalog(1);
                foreach (var ideaCatalog in listProduct)
                {
                    string tmpFile = "";
                    try
                    {
                        documentComplated = false;
                        //  var htmlDocument = new HtmlAgilityPack.HtmlWeb();
                        string pageUrl = $@"https://www.google.com/search?q={ ideaCatalog.Title.Replace("%", "yüzde") }&tbm=shop";
                        //  var document = htmlDocument.Load(pageUrl);

                        var files = Directory.GetFiles(@"D:\Personel\PersonelProject\WebImage\", ideaCatalog.Id.ToString() + "_*.*");
                        if (files.Length != 0)
                            continue;

                        webBrowser1.Navigate(pageUrl);

                        while (!documentComplated)
                        {
                            Thread.Sleep(100);
                            Application.DoEvents();

                        }
                        var str = webBrowser1.Document.Body.InnerHtml;

                        var htmlDocument = new HtmlAgilityPack.HtmlWeb();
                        tmpFile = Path.GetTempFileName();

                        File.WriteAllText(tmpFile, str, Encoding.UTF8);
                        var document = htmlDocument.Load(tmpFile);
                        //sh-dgr__thumbnail
                        var divList = document.DocumentNode.SelectNodes("//div").Where(s => s.Attributes.Contains("class") && (s.Attributes["class"].Value.Contains("sh-dlr__list-result") ||   s.Attributes["class"].Value.Contains("sh-dgr__thumbnail"))).ToArray();

                        int i = 0;
                        if (divList.Length != 0)
                        {

                            foreach (var oneProductElement in divList.Take(1))
                            {

                                string imagePath = @"D:\Personel\PersonelProject\WebImage\" + ideaCatalog.Id.ToString() + "_" + i.ToString() + ".jpg";
                                var imageNode = GetElementByName(oneProductElement, "img");
                                var ilinkName = GetElementByNameWithLabel(oneProductElement, "a", ideaCatalog.Title);
                                /*if (ilinkName == null)
                                    continue;*/
                                var base64Image = imageNode.Attributes["src"].Value.Replace("data:image/jpeg;base64,", "");
                                byte[] imageBytes = Convert.FromBase64String(base64Image);
                                File.WriteAllBytes(imagePath, imageBytes);
                                ideaCatalog.Picture1Path = Path.GetFileName(imagePath);

                                i++;
                            }
                            IdeaCatalogRepository.UpdateImageState(ideaCatalog, 1);
                        }
                        else
                        {
                            var divList2 = document.DocumentNode.SelectNodes("//div").Where(s => s.Attributes.Contains("class") && s.Attributes["class"].Value.Contains("sh-dlr__list-result")).ToArray();
                            IdeaCatalogRepository.UpdateImageState(ideaCatalog, 101);
                        }
                        

                        // Thread.Sleep(5000);
                    }
                    catch (Exception ex)
                    {
                        IdeaCatalogRepository.UpdateImageState(ideaCatalog, 5);
                        Trace.WriteLine(ex);
                    }
                    finally
                    {
                        File.Delete(tmpFile);
                        Thread.Sleep(5000);
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveJpeg(Image img, string filename, int quality)
        {
            var q = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameter qualityParam = new EncoderParameter(q, (byte)quality);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(filename, jpegCodec, encoderParams);
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();
            var encoder = encoders.SingleOrDefault(c => string.Equals(c.MimeType, mimeType, StringComparison.InvariantCultureIgnoreCase));
            if (encoder == null) throw new Exception($"Encoder not found for mime type {mimeType}");
            return encoder;
        }
        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public string RemoveTurkish(string s)
        {
            string v = s.ToUpper();
            v = v.Replace("Ý", "I");
            v = v.Replace("Ö", "O");
            v = v.Replace("Ð", "G");
            v = v.Replace("Þ", "S");
            v = v.Replace("Ç", "C");
            v = v.Replace("Ü", "U");
            v = v.Replace('\u2029', ' ');
            v = v.Replace('\u2028', ' ');
            v = v.Replace(" ", "");

            return v.Trim();
        }
     
    }
}
