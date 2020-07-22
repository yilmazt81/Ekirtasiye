using EKirtasiye.Trendyol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp
{
    public static class TrendyolHelper
    {
        static EKirtasiye.Trendyol.ProductHelper productHelper = new EKirtasiye.Trendyol.ProductHelper(ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint"), ApplicationSettingHelper.ReadValue("Trendyol", "SupplierId"), ApplicationSettingHelper.ReadValue("Trendyol", "UserName"), ApplicationSettingHelper.ReadValue("Trendyol", "Password"));
        static EKirtasiye.Trendyol.BrandHelper brandHelper = new EKirtasiye.Trendyol.BrandHelper(ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint"));
        static EKirtasiye.Trendyol.SuppliersAddressesHelper suppliersAddressesHelper = null;
        static TrendyolHelper()
        {
            productHelper = new EKirtasiye.Trendyol.ProductHelper(ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint"), ApplicationSettingHelper.ReadValue("Trendyol", "SupplierId"), ApplicationSettingHelper.ReadValue("Trendyol", "UserName"), ApplicationSettingHelper.ReadValue("Trendyol", "Password"));
            brandHelper = new EKirtasiye.Trendyol.BrandHelper(ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint"));
            suppliersAddressesHelper = new EKirtasiye.Trendyol.SuppliersAddressesHelper(ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint"), ApplicationSettingHelper.ReadValue("Trendyol", "SupplierId"), ApplicationSettingHelper.ReadValue("Trendyol", "UserName"), ApplicationSettingHelper.ReadValue("Trendyol", "Password"));

        }

        public static CreateRequestReturn UpdatePriceAndEnvantor(UpdatePriceAndInventor[] priceAndInventors)
        {
            return productHelper.UpdatePriceAndInventory(new EKirtasiye.Trendyol.UpdatePriceRequest()
            {
                items = priceAndInventors
            });
        }

        public static string ExportProduct(IdeaCatalog ideaCatalog)
        {


            try
            {
                var brand = brandHelper.GetBrandByName(ideaCatalog.Brand);

                var supplierAdress = suppliersAddressesHelper.GetAdress();

                ProductCategory productCategory = null;

                if (ideaCatalog.CategoryId != 0)
                {
                    productCategory = ApiHelper.GetCategory(ideaCatalog.CategoryId);

                }
                if (ideaCatalog.SubCategoryId != 0)
                {
                    productCategory = ApiHelper.GetCategory(ideaCatalog.SubCategoryId);
                }

                if (productCategory.TrendyolCategoryId == 0)
                {

                    return "Trendyol Category işlenmemiş";

                }

                float price = 0;
                price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;
                if (price > 150)
                {
                    price = price + 20;
                }

                var categoryAttributes = ApiHelper.GetTrendyolCategorieAttributes(productCategory.TrendyolCategoryId);

                var defaultAttribute = ApiHelper.GetCategoryDefaultAttributes(productCategory.Id);
                foreach (var attribute in categoryAttributes)
                {
                    if (!defaultAttribute.Any(s => s.AttributeId == attribute.Attributeid))
                    {
                        string defaultValue = "yok";
                        if (attribute.Attributename == "Renk")
                        {
                            defaultValue = "Karışık Çok Renkli";
                        }
                        defaultAttribute.Add(new EKirtasiye.Model.TrendyolCategoryDefaultAttribute()
                        {
                            AttributeId = attribute.Attributeid,
                            AttributeName = attribute.Attributename,
                            CustomAttributeValue = defaultValue

                        });
                    }
                }

                List<EKirtasiye.Trendyol.TrendyolUrl> trendyolUrls = new List<EKirtasiye.Trendyol.TrendyolUrl>();
                if (!string.IsNullOrEmpty(ideaCatalog.Picture1Path))
                {
                    trendyolUrls.Add(new EKirtasiye.Trendyol.TrendyolUrl()
                    {
                        url = ideaCatalog.Picture1Path
                    });
                }
                if (!string.IsNullOrEmpty(ideaCatalog.Picture2Path))
                {
                    trendyolUrls.Add(new EKirtasiye.Trendyol.TrendyolUrl()
                    {
                        url = ideaCatalog.Picture2Path
                    });
                }

                if (!string.IsNullOrEmpty(ideaCatalog.Picture3Path))
                {
                    trendyolUrls.Add(new EKirtasiye.Trendyol.TrendyolUrl()
                    {
                        url = ideaCatalog.Picture3Path
                    });
                }
                var product = new EKirtasiye.Trendyol.CreateTrendyolProduct()
                {
                    barcode = ideaCatalog.Barcode,
                    description = ideaCatalog.Details,
                    vatRate = int.Parse(ideaCatalog.Tax),
                    quantity = ideaCatalog.StockAmount,
                    title = ideaCatalog.Title,
                    stockCode = ideaCatalog.StockCode,
                    brandId = brand.FirstOrDefault().id,
                    attributes = defaultAttribute.Select(s => new EKirtasiye.Trendyol.ProductCreateAttribute()
                    {
                        attributeId = s.AttributeId,
                        attributeValueId = (s.AttributeValue == 0 ? null : (object)s.AttributeValue),
                        customAttributeValue = s.CustomAttributeValue
                    }).ToArray(),
                    currencyType = ideaCatalog.CurrencyAbbr,
                    dimensionalWeight = ideaCatalog.Dm3,
                    listPrice = (price * 1.1).ToString().Replace(",", "."),
                    salePrice = price.ToString().Replace(",", "."),
                    cargoCompanyId = 1,
                    //deliveryDuration = 10,
                    images = trendyolUrls.ToArray(),
                    returningAddressId = null,
                    shipmentAddressId = supplierAdress.defaultShipmentAddress.id,
                    categoryId = productCategory.TrendyolCategoryId,
                    productMainId = ideaCatalog.Id.ToString(),

                };

                var returnV = productHelper.CreateProduct(new EKirtasiye.Trendyol.CreateProductRequest()
                {
                    items = new EKirtasiye.Trendyol.CreateTrendyolProduct[]
                       {
                            product
                       }
                });

                if (returnV == null)
                {
                    return "Post işlemi başarısız ";
                }



                ApiHelper.SaveTrendyolCreateRequest(new EKirtasiye.Model.TrendyolCreateRequest()
                {
                    ProductId = ideaCatalog.Id,
                    BatchRequest = returnV.batchRequestId

                });

                var requst = productHelper.GetBatchRequest(returnV.batchRequestId);
                if (requst.failedItemCount == 0)
                {

                    var updateDB = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                    {
                        Exported = true,
                        Id = ideaCatalog.Id,
                        ShopName = "Trendyol",
                        ShopPrice = price.ToString()
                    });

                    return "ok";
                }
                else
                {
                    string returnMessage = "";
                    foreach (var item in requst.items)
                    {
                        foreach (var reason in item.failureReasons)
                        {
                            returnMessage += reason;
                        }

                    }
                    return returnMessage;
                }

                //return "ok";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
