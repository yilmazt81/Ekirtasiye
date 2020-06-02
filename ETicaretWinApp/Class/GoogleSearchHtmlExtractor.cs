using FluentFTP;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ETicaretWinApp
{
    public class GoogleSearchHtmlExtractor
    {
        static FtpClient ftpClient = null;
        static GoogleSearchHtmlExtractor()
        {
            ftpClient = new FtpClient(System.Configuration.ConfigurationManager.AppSettings["FTPAdress"]);
            ftpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = System.Configuration.ConfigurationManager.AppSettings["FTPUserName"],
                Password = System.Configuration.ConfigurationManager.AppSettings["FTPPassword"]
            };
        }

        private static HtmlNode GetElementByName(HtmlNode htmlElement, string elementName)
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
        private static HtmlNode GetElementByName(HtmlNode htmlElement, string elementName, string className)
        {
            foreach (var item in htmlElement.ChildNodes)
            {
                if (item.Name == elementName && item.Attributes.Contains("class") && item.Attributes["class"].Value == className)
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

        private static void GetAllElementByName(HtmlNode htmlNode, string name, List<HtmlNode> htmlNodes)
        {
            foreach (var item in htmlNode.ChildNodes)
            {
                if (item.Name == name)
                {
                    htmlNodes.Add(item);
                }
                if (item.ChildNodes.Count != 0)
                {
                    GetAllElementByName(item, name, htmlNodes);

                }
            }
        }
        public static int LevenshteinDistance(string source, string target)
        {
            // degenerate cases
            if (source == target) return 0;
            if (source.Length == 0) return target.Length;
            if (target.Length == 0) return source.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[target.Length + 1];
            int[] v1 = new int[target.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < source.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < target.Length; j++)
                {
                    var cost = (source[i] == target[j]) ? 0 : 1;
                    v1[j + 1] = Math.Min(v1[j] + 1, Math.Min(v0[j + 1] + 1, v0[j] + cost));
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[target.Length];
        }
        public static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = LevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        public static string SaveImage(string base64Image, ref string fileExtention)
        {
            if (string.IsNullOrEmpty(base64Image))
                return string.Empty;

            string imageFilePath, tempFile = string.Empty;
            if (base64Image.StartsWith("data:image/jpeg;"))
            {
                fileExtention = ".jpg";
                base64Image = base64Image.Replace("data:image/jpeg;base64,", "");
            }
            else if (base64Image.StartsWith("http"))
            {
                tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".jpg");
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.DownloadFile(base64Image, tempFile);
                fileExtention = ".jpg";

                return tempFile;

            }
            else if (base64Image.StartsWith("data:image/gif;"))
            {
                if (base64Image.Length < 100)
                    return string.Empty;
                fileExtention = ".gif";
                base64Image = base64Image.Replace("data:image/gif;base64,", "");
            }
            else
            {
                fileExtention = "";
            }
            string tmpFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + fileExtention);
            var imageBytes = System.Convert.FromBase64String(base64Image);


            File.WriteAllBytes(tmpFile, imageBytes);
            return tmpFile;

        }

        public static string SaveAndUploadImage(string base64Image)
        {

            string fileExtention = "";
            string tempFile = SaveImage(base64Image, ref fileExtention);
            if (string.IsNullOrEmpty(tempFile))
                return string.Empty;

            string imageFilePath = Guid.NewGuid().ToString("N") + fileExtention;
            string targetFilePath = "/httpdocs/WebImage/" + imageFilePath;
            if (!string.IsNullOrEmpty(tempFile))
            {
                var imageBytes = File.ReadAllBytes(tempFile);
                ftpClient.Connect();
                ftpClient.Upload(imageBytes, targetFilePath);
                File.Delete(tempFile);
            }
            else
            {
                var imageBytes = System.Convert.FromBase64String(base64Image);
                ftpClient.Connect();
                ftpClient.Upload(imageBytes, targetFilePath);
            }

            return imageFilePath;

        }

        public static string UploadImage(string imagePath)
        {
            string imageFilePath = Path.GetFileName(imagePath);
            string targetFilePath = "/httpdocs/WebImage/" + imageFilePath;

            string imageURl = "http://turkyilmazozkan.xyz/webImage/" + imageFilePath;

            var imageBytes = File.ReadAllBytes(imagePath);
            ftpClient.Connect();
            ftpClient.Upload(imageBytes, targetFilePath);

            return imageURl;
        }
        public static void SavePictureToWeb(IdeaCatalog ideaCatalog, string base64Image)
        {
            var imageFilePath = SaveAndUploadImage(base64Image);

            if (string.IsNullOrEmpty(imageFilePath))
                return;

            ideaCatalog.Picture1Path = "http://turkyilmazozkan.xyz/WebImage/" + imageFilePath;

            ApiHelper.UpdateProductPictures(new EKirtasiye.Model.UpdateProductPictureRequest()
            {
                ProductId = ideaCatalog.Id,
                PicturePath1 = ideaCatalog.Picture1Path,
                PicturePath2 = ideaCatalog.Picture2Path,
                PicturePath3 = ideaCatalog.Picture3Path,
                PicturePath4 = ideaCatalog.Picture4Path
            });

            ftpClient.Disconnect();
        }

        public static WebPagePRoductSelected GetSelectedProduct(string fullPageHtml)
        {
            WebPagePRoductSelected webPagePRoductSelected = new WebPagePRoductSelected();
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(fullPageHtml);

            var selectedDiv = document.DocumentNode.SelectNodes("//div").Where(s => s.Attributes.Contains("class") && (s.Attributes["class"].Value == "sh-dp__sc")).ToArray();
            var productDescription = document.DocumentNode.SelectNodes("//span").Where(s => s.Attributes.Contains("class") && s.Attributes["class"].Value == "sh-ds__full-txt translate-details-content").ToArray();
            if (selectedDiv.Length == 1)
            {
                var currentDiv = selectedDiv.FirstOrDefault();
                var firstImageDiv = currentDiv.ChildNodes.Where(s => s.Name == "div" && s.Attributes.Contains("class")).FirstOrDefault();
                var thumnailImageDiv = firstImageDiv.ChildNodes.FirstOrDefault(s => s.Name == "div" && s.Attributes["class"].Value.Contains("media-options"));
                if (thumnailImageDiv != null)
                {

                    List<HtmlNode> htmlNodes = new List<HtmlNode>();

                    GetAllElementByName(thumnailImageDiv, "a", htmlNodes);
                    webPagePRoductSelected.ProductImages = new List<ProductImage>();
                    foreach (HtmlNode imageNode in htmlNodes)
                    {
                        if (imageNode.InnerHtml.Contains("Diğerlerini göster"))
                            continue;
                        webPagePRoductSelected.ProductImages.Add(new ProductImage() { ImageData = imageNode.Attributes["data-image"].Value });
                    }
                }
                else
                {
                    var mainImage = GetElementByName(currentDiv, "img");
                    if (mainImage != null)
                    {
                        webPagePRoductSelected.ProductImages = new List<ProductImage>();
                        webPagePRoductSelected.ProductImages.Add(new ProductImage() { ImageData = mainImage.Attributes["src"].Value });
                    }
                    else
                    {
                        System.Diagnostics.Trace.WriteLine("exxx");
                    }
                }
                webPagePRoductSelected.Description = productDescription.Length == 0 ? "" : HelperXmlRead.ConvertHtmlCodesToTurkish(productDescription[0].InnerHtml);

                var divPrice = GetElementByName(currentDiv, "div", " _-dp _-do");
                if (divPrice != null)
                {
                    webPagePRoductSelected.ProductPrice = divPrice.InnerText.Replace("₺", "");
                }else
                {
                    var divPricedo2 = GetElementByName(currentDiv, "div", " _-dr _-dq");
                    if (divPricedo2 != null)
                    {
                        webPagePRoductSelected.ProductPrice = divPricedo2.InnerText.Replace("₺", "");
                    }
                }
            }

            return webPagePRoductSelected;

        }

        public static List<WebPageProduct> GetProductLinks(string fullPageHtml, string productName)
        {
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(fullPageHtml);

            var aProduct = new List<WebPageProduct>();
            //sh-dlr__content
            var linkeList = document.DocumentNode.SelectNodes("//div").Where(s => s.Attributes.Contains("class") && (s.Attributes["class"].Value == "sh-dgr__content" || s.Attributes["class"].Value == "sh-dlr__content")).ToArray();
            int pageOrder = 1;
            foreach (HtmlNode oneNodeProduct in linkeList)
            {
                WebPageProduct webPageProduct = new WebPageProduct()
                {
                    InnerHtml = oneNodeProduct.InnerHtml,
                    PageOrder = pageOrder
                };
                pageOrder++;
                foreach (var oneNode in oneNodeProduct.ChildNodes)
                {



                    var classValue = oneNode.Attributes["class"].Value;
                    if (classValue == "sh-dgr__thumbnail" || classValue == "sh-dlr__thumbnail")
                    {
                        var imageElement = GetElementByName(oneNode, "img");
                        var aLinkNode = GetElementByName(oneNode, "a");

                        var attributeSrc = imageElement.Attributes["src"].Value;

                        webPageProduct.ImageBase64 = attributeSrc;
                        webPageProduct.ProductImageHref = aLinkNode.Attributes["href"].Value;
                    }
                    else if (classValue == "p7n7Ze")
                    {
                        if (string.IsNullOrEmpty(webPageProduct.ProductName))
                        {
                            var headerNode = GetElementByName(oneNode, "h4");
                            if (headerNode == null)
                                continue;
                            webPageProduct.ProductName = HelperXmlRead.ConvertHtmlCodesToTurkish(headerNode.InnerText);
                            webPageProduct.Similarity = CalculateSimilarity(productName.ToUpper(), webPageProduct.ProductName.ToUpper());
                        }
                    }
                    else if (classValue == "ZGFjDb")
                    {
                        if (string.IsNullOrEmpty(webPageProduct.ProductName))
                        {
                            var headerNode = GetElementByName(oneNode, "h3");
                            webPageProduct.ProductName = HelperXmlRead.ConvertHtmlCodesToTurkish(headerNode.InnerText);
                            webPageProduct.Similarity = CalculateSimilarity(productName.ToUpper(), webPageProduct.ProductName.ToUpper());
                        }
                        //Bu versiyonda price bu tag icerisinde .
                        List<HtmlNode> htmlNodes = new List<HtmlNode>();
                        GetAllElementByName(oneNode, "span", htmlNodes);

                        var priceNode = htmlNodes.FirstOrDefault(s => s.Attributes.Contains("aria-hidden") && s.Attributes["aria-hidden"].Value == "true");
                        if (priceNode != null)
                        {
                            webPageProduct.ProductPrice = priceNode.InnerHtml;

                        }
                    }
                    else if (classValue == "sh-dgr__secondary-container")
                    {
                        List<HtmlNode> htmlNodes = new List<HtmlNode>();
                        GetAllElementByName(oneNode, "span", htmlNodes);

                        var priceNode = htmlNodes.FirstOrDefault(s => s.Attributes.Contains("aria-hidden") && s.Attributes["aria-hidden"].Value == "true");
                        if (priceNode != null)
                        {
                            webPageProduct.ProductPrice = priceNode.InnerHtml;

                        }

                    }
                }
                aProduct.Add(webPageProduct);
            }

            return aProduct;

        }
    }
}
