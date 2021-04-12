using EKirtasiye.Model;
using EKirtasiye.N11;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public static class N11Helper
    {


      

        public static string ExportProduct(IdeaCatalog ideaCatalog)
        {

            try
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
                if (productCategory.N11ExportTemplateId == 0)
                {
                    return "Export Template Belirli değil";
                }
                var _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
                var _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
                var productHelper = new ProductHelper(_apiKey, _secretKey);

                if (productCategory.N11ExportTemplateId == 0)
                    return "N11 Kategori Belirlenmedi";
                var exportTemplate = ApiHelper.GetN11ExportTemplate(productCategory.N11ExportTemplateId);


                List<N11Image> n11Images = new List<N11Image>();
                if (!string.IsNullOrEmpty(ideaCatalog.Picture1Path))
                {
                    n11Images.Add(new N11Image()
                    {
                        Order = 1,
                        Url = ideaCatalog.Picture1Path
                    });
                }
                if (!string.IsNullOrEmpty(ideaCatalog.Picture2Path))
                {
                    n11Images.Add(new N11Image()
                    {
                        Order = 2,
                        Url = ideaCatalog.Picture2Path
                    });
                }
                if (!string.IsNullOrEmpty(ideaCatalog.Picture3Path))
                {
                    n11Images.Add(new N11Image()
                    {
                        Order = 3,
                        Url = ideaCatalog.Picture3Path
                    });
                }
                if (!string.IsNullOrEmpty(ideaCatalog.Picture4Path))
                {
                    n11Images.Add(new N11Image()
                    {
                        Order = 4,
                        Url = ideaCatalog.Picture4Path
                    });
                }
                float price = 0;
                price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;
                if (price > 150)
                {
                    price = price + 20;
                }
                N11Product n11Product = new N11Product()
                {
                    Id = ideaCatalog.N11ProductId,
                    ProductSellerCode = ideaCatalog.StockCode,
                    Title = ideaCatalog.Title,
                    Subtitle = exportTemplate.SubText,
                    approvalStatus = (ideaCatalog.Status ? "1" : "2"),
                    CategoryId = productCategory.N11CategoryId,
                    CurrencyType = ideaCatalog.CurrencyAbbr,
                    Description = ideaCatalog.Details,
                    Domestic = false,
                    preparingDay = exportTemplate.CargoDay.ToString(),
                    productCondition = "1",
                    saleEndDate = (exportTemplate.EndDate != null ? exportTemplate.EndDate.Value.ToString("dd/MM/yyyy") : ""),
                    saleStartDate = (exportTemplate.StartDate != null ? exportTemplate.StartDate.Value.ToString("dd/MM/yyyy") : ""),
                    shipmentTemplate = exportTemplate.DeliveryTemplate,
                    ProductImages = n11Images.ToArray(),
                    Price = (decimal)price,
                    ProductBrand = ideaCatalog.Brand,
                    Barcode = ideaCatalog.Barcode

                };
                productHelper.SaveProduct(n11Product);

                var updateDB = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                {
                    Exported = true,
                    Id = ideaCatalog.Id,
                    ProductId = n11Product.Id,
                    ShopName = "N11",
                    ShopPrice = price.ToString()
                });
                if (!updateDB)
                {
                    throw new Exception("Ürün N11 e gönderildi fakat DB update edilemedi");
                }

                ApiHelper.SaveLastProductExportProperty(new LastProductExportProperty()
                {
                    ProductId = ideaCatalog.Id,
                    IdeaExportTargetId = 4, //N11 ExportId
                    ProductPrice = ideaCatalog.MarketPrice,
                    PicturePath1 = ideaCatalog.Picture1Path,
                    PicturePath2 = ideaCatalog.Picture2Path,
                    PicturePath3 = ideaCatalog.Picture3Path,
                    PicturePath4 = ideaCatalog.Picture4Path,
                    ProductState = ideaCatalog.Status
                });

                return "ok";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
