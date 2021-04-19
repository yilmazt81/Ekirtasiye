using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.CicekSepeti;
using EKirtasiye.Model;

namespace ETicaretWinApp
{
    public class CicekSepetiHelper
    {

        public static ShopCreateImage ConvertShopImage(int productId, string picturePath)
        {

            ShopCreateImage shopCreateImage = new ShopCreateImage()
            {
                ProductId = productId,
                ShopName = "CicekSepeti"
            };
            //shopCreateImage.PictureRemotePath = picturePath;

            string tmpPath = Path.Combine(Application.StartupPath, $@"ImageTemp\{productId}_{Path.GetFileName(picturePath)}");

            string ftpUploadPath = string.Empty;

            if (picturePath.StartsWith("http"))
            {

                if (!Directory.Exists(Path.GetDirectoryName(tmpPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(tmpPath));

                if (!File.Exists(tmpPath))
                {
                    using (WebClient webClient = new WebClient())
                    {
                        System.Net.Http.Headers.ProductHeaderValue productInfoHeaderValue = new System.Net.Http.Headers.ProductHeaderValue("EKirtasiye", "1.0.0.1");

                        webClient.Headers.Add(HttpRequestHeader.UserAgent, "EKirtasiye");


                        webClient.DownloadFile(picturePath, tmpPath);

                    }
                }
            }

            Image image = Image.FromFile(tmpPath);

            var imageW = (image.Width < 500 ? 500 : image.Width);
            var imageH = (image.Height < 500 ? 500 : image.Height);

            //Cicek sepeti için image oran 10x11 olması gerekli.
            var mustW = imageH * 0.90909;
            var mustH = 0;

            if (mustW < imageW)
            {
                mustH = (int)(imageW * 1.1  );
                mustW = imageW;
            }
            else
            {
                mustH = imageH;
            }
            Bitmap bitmap = new Bitmap((int)mustW, (int)mustH, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics grp = Graphics.FromImage(bitmap))
            {
                grp.FillRectangle(
                    Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                bitmap = new Bitmap(bitmap.Width, bitmap.Height, grp);
            }

            var leftSize = (mustW - image.Width) / 2;
            var upSize = (mustH - image.Height) / 2;
            var destRectagle = new Rectangle((int)leftSize, (int)upSize, imageW, imageH);

            CopyRegionIntoImage((Bitmap)image, new Rectangle(0, 0, imageW, imageH), ref bitmap, destRectagle);
            string localTempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".jpg");
            bitmap.Save(localTempFile);
            image = null;
            bitmap = null;
            FTPHelper.UploadFile(localTempFile, @"/httpdocs/CicekSepeti/" + Path.GetFileName(localTempFile));
            shopCreateImage.PictureRemotePath = "https://www.turkyilmazozkan.xyz/CicekSepeti/" + Path.GetFileName(localTempFile);
            File.Delete(localTempFile);

            return shopCreateImage;

        }

        public static void CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion, ref Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
        }

        public static string ExportProduct(IdeaCatalog ideaCatalog)
        {

            try
            {

                var cicekSepetiCategoryId = ideaCatalog.ReadAttribute("CicekSepetiCategory");
                List<CicekAttribute> cicekAttributes = new List<CicekAttribute>();

                if (cicekSepetiCategoryId == string.Empty)
                {


                    ProductCategory productCategory = null;

                    if (ideaCatalog.CategoryId != 0)
                    {
                        productCategory = ApiHelper.GetCategory(ideaCatalog.CategoryId);

                    }
                    if (ideaCatalog.SubCategoryId != 0)
                    {
                        productCategory = ApiHelper.GetCategory(ideaCatalog.SubCategoryId);
                    }

                    if (productCategory == null)
                    {
                        return "Product Category Belirli değil";
                    }

                    cicekSepetiCategoryId = productCategory.CicekSepetiCategoryId.ToString();

                    var categoryAttributes = ApiHelper.GetCicekSepetiCategorieAttributes(int.Parse(cicekSepetiCategoryId));

                    foreach (var cicekSepetiAttribute in categoryAttributes.Where(s => s.Attributename != "Dinamik Özellik"))
                    {

                        var attributedefaultValue = ApiHelper.GetCicekSepetiCategoryDefaultAttribute(productCategory.Id, cicekSepetiAttribute.Id);
                        if (attributedefaultValue != null)
                        {
                            cicekAttributes.Add(new CicekAttribute()
                            {
                                id = cicekSepetiAttribute.Attributeid,
                                valueId = attributedefaultValue.AttributeValue,
                                textLength = 0
                            });
                        }
                    }
                }
                else
                {
                    var productAttributes = ApiHelper.GetCicekSepetiProductAttribute(ideaCatalog.Id);
                    foreach (var attribute in productAttributes)
                    {
                        if (attribute.AttributeValue == 0)
                            continue;
                        cicekAttributes.Add(new CicekAttribute()
                        {
                            id = attribute.Attributeid,
                            valueId = attribute.AttributeValue,
                            textLength = 0
                        });
                    }
                }

                var _apiKey = ApplicationSettingHelper.ReadValue("CicekSepeti", "ApiKey");
                var _suplierId = ApplicationSettingHelper.ReadValue("CicekSepeti", "SupplierId");
                var _endPoint = ApplicationSettingHelper.ReadValue("CicekSepeti", "EndPoint");
                var productHelper = new CicekSepetiApi(_endPoint, _suplierId, _apiKey);


                List<string> productImages = new List<string>();
                var shopImageList = ideaCatalog.ShopCreateImages.Where(s => s.ShopName == "CicekSepeti").ToList();
                if (shopImageList.Count > 0)
                {
                    productImages = shopImageList.Select(s => s.PictureRemotePath).ToList();
                }
                else
                {
                    //Image Hazirla

                    if (!string.IsNullOrEmpty(ideaCatalog.Picture1Path))
                    {
                        shopImageList.Add(ConvertShopImage(ideaCatalog.Id, ideaCatalog.Picture1Path));

                    }
                    if (!string.IsNullOrEmpty(ideaCatalog.Picture2Path))
                    {
                        shopImageList.Add(ConvertShopImage(ideaCatalog.Id, ideaCatalog.Picture2Path));
                    }
                    if (!string.IsNullOrEmpty(ideaCatalog.Picture3Path))
                    {
                        shopImageList.Add(ConvertShopImage(ideaCatalog.Id, ideaCatalog.Picture3Path));
                    }
                    if (!string.IsNullOrEmpty(ideaCatalog.Picture4Path))
                    {
                        shopImageList.Add(ConvertShopImage(ideaCatalog.Id, ideaCatalog.Picture4Path));
                    }
                    productImages = shopImageList.Select(s => s.PictureRemotePath).ToList();
                }

                float price = 0;
                price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;

                var listPrice = price * 1.1;
                CicekSepetiProduct cicekSepetiProduct = new CicekSepetiProduct()
                {
                    barcode = ideaCatalog.Barcode,
                    categoryId = int.Parse(cicekSepetiCategoryId),
                    productName = ideaCatalog.Title,
                    description = ideaCatalog.Details,
                    stockCode = ideaCatalog.StockCode,
                    stockQuantity = ideaCatalog.StockAmount,
                    salesPrice = (decimal)price,
                    listPrice = (decimal)listPrice,
                    deliveryType = 2,//Kargo ile gönderilir.
                    deliveryMessageType = 5,//Hediye Kargo 1-3 Is Gunu,
                    images = productImages.ToArray(),
                    attributes = cicekAttributes.ToArray(),
                    mainProductCode = ideaCatalog.StockCode,
                    mediaLink = ""

                };
                var returnC = productHelper.CreateProduct(new List<CicekSepetiProduct>() { cicekSepetiProduct });


                if (returnC != null)
                {
                    ApiHelper.SaveCicekSepetiCreateRequest(new CicekSepetiCreateRequest()
                    {
                        BatchRequest = returnC.batchId,
                        ProductId = ideaCatalog.Id,
                        RequestType = "Create"
                    });

                    ApiHelper.SaveLastProductExportProperty(new LastProductExportProperty()
                    {
                        ProductId = ideaCatalog.Id,
                        IdeaExportTargetId = 6, //CicekSepeti
                        ProductPrice = ideaCatalog.MarketPrice,
                        PicturePath1 = ideaCatalog.Picture1Path,
                        PicturePath2 = ideaCatalog.Picture2Path,
                        PicturePath3 = ideaCatalog.Picture3Path,
                        PicturePath4 = ideaCatalog.Picture4Path,
                        ProductState = ideaCatalog.Status
                    });
                }
                else
                {
                    return "no";
                }

                return "ok";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void SaveCicekSepetiAttribute(int cicekSepeticategoryId)
        {
            var _apiKey = ApplicationSettingHelper.ReadValue("CicekSepeti", "ApiKey");
            var _suplierId = ApplicationSettingHelper.ReadValue("CicekSepeti", "SupplierId");
            var _endPoint = ApplicationSettingHelper.ReadValue("CicekSepeti", "EndPoint");
            var cicekSepetiApi = new CicekSepetiApi(_endPoint, _suplierId, _apiKey);


            var cicekSepetiCategoryAttribute = cicekSepetiApi.GetCategoryAttribute(cicekSepeticategoryId);

            List<CicekSepetiAttribute> cicekSepetiAttributes = new List<CicekSepetiAttribute>();
            foreach (var categoryattribute in cicekSepetiCategoryAttribute.categoryAttributes)
            {
                CicekSepetiAttribute cicekSepetiCategory = new CicekSepetiAttribute()
                {
                    CategoryId = cicekSepeticategoryId,
                    Attributeid = categoryattribute.attributeId,
                    DisplayName = categoryattribute.attributeName,
                    Required = categoryattribute.required,
                    Varianter = categoryattribute.varianter,
                    Attributename = categoryattribute.type,
                    Name = categoryattribute.attributeName,
                    AttributeValues = categoryattribute.attributeValues.Select(s => new CicekSepetiAttributeValue()
                    {
                        AttributeValue = s.id.ToString(),
                        AttributeText = s.name

                    }).ToArray()
                };
                cicekSepetiAttributes.Add(cicekSepetiCategory);
            }
            ApiHelper.SaveCicekSepetiAttributes(cicekSepetiAttributes);


        }

        public static CicekSepetiBatchReturn GetBatchState(string batchId)
        {

            var _apiKey = ApplicationSettingHelper.ReadValue("CicekSepeti", "ApiKey");
            var _suplierId = ApplicationSettingHelper.ReadValue("CicekSepeti", "SupplierId");
            var _endPoint = ApplicationSettingHelper.ReadValue("CicekSepeti", "EndPoint");
            var productHelper = new CicekSepetiApi(_endPoint, _suplierId, _apiKey);

            return productHelper.CheckBatchStatus(batchId);

        }

        public static string UpdateProducStockAndPrice(List<IdeaCatalog> ideaCatalogs)
        {

            var _apiKey = ApplicationSettingHelper.ReadValue("CicekSepeti", "ApiKey");
            var _suplierId = ApplicationSettingHelper.ReadValue("CicekSepeti", "SupplierId");
            var _endPoint = ApplicationSettingHelper.ReadValue("CicekSepeti", "EndPoint");
            var productHelper = new CicekSepetiApi(_endPoint, _suplierId, _apiKey);
            CicekSepetiUpdateStock cicekSepetiUpdateStock = new CicekSepetiUpdateStock();
            cicekSepetiUpdateStock.items = ideaCatalogs.Select(s => new UpdateStockPriceItem()
            {
                stockCode = s.StockCode,
                listPrice = (calculateListPrice(s)),
                salesPrice = float.Parse(s.MimimumPrice) * (float)1.18,
                StockQuantity = (!s.Status ? 0 : s.StockAmount)
            }).ToArray();
            var returnC = productHelper.UpdateProductStockAndPrice(cicekSepetiUpdateStock);

            float calculateListPrice(IdeaCatalog s)
            {
                return (float)((float.Parse(s.MimimumPrice) * (float)1.18) * 1.1);
            }

            return returnC.batchId;
        }
    }
}
