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
        static TrendyolPartnerpageHelper trendyolPartnerpageHelper = null;
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

        public static string OpenProductAccepted(IdeaCatalog[] ideaCatalog)
        {
            /*
            float price = 0;
            price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;
            if (price > 150)
            {
                price = price + 20;
            }*/
            var updateProduct = ideaCatalog.Select(s => new UpdatePriceAndInventor()
            {
                barcode = s.Barcode,
                quantity = (s.Status ? s.StockAmount : 0),
                listPrice = float.Parse(s.MimimumPrice) * (float)1.16,
                salePrice = float.Parse(s.MimimumPrice) * (float)1.15
            }).ToArray();

            /*
            var updateProduct = new EKirtasiye.Trendyol.UpdatePriceAndInventor[] { new EKirtasiye.Trendyol.UpdatePriceAndInventor()
                {
                    barcode=ideaCatalog.Barcode,
                    quantity=(ideaCatalog.Status?ideaCatalog.StockAmount:0),
                    listPrice=price,
                    salePrice=price
                } };
            */
            var updatePrice = UpdatePriceAndEnvantor(updateProduct);

            if (updatePrice != null)
            {
                foreach (var catalog in ideaCatalog)
                {
                    ApiHelper.SaveTrendyolCreateRequest(new EKirtasiye.Model.TrendyolCreateRequest()
                    {
                        ProductId = catalog.Id,
                        BatchRequest = updatePrice.batchRequestId,
                        RequestType = "OpenProduct"

                    });
                }
            }
            return (updatePrice == null ? string.Empty : updatePrice.batchRequestId);

        }

        public static string CloseProductAccepted(IdeaCatalog[] ideaCatalog)
        {

            var updateProduct = ideaCatalog.Select(s => new UpdatePriceAndInventor()
            {
                barcode = s.Barcode,
                quantity = 0,
                listPrice = float.Parse(s.MimimumPrice) * (float)1.16,
                salePrice = float.Parse(s.MimimumPrice) * (float)1.15
            }).ToArray();

            var updatePrice = UpdatePriceAndEnvantor(updateProduct);

            if (updatePrice != null)
            {
                foreach (var catalog in ideaCatalog)
                {
                    ApiHelper.SaveTrendyolCreateRequest(new EKirtasiye.Model.TrendyolCreateRequest()
                    {
                        ProductId = catalog.Id,
                        BatchRequest = updatePrice.batchRequestId,
                        RequestType = "CloseProduct"

                    });
                }
            }
            return (updatePrice == null ? string.Empty : updatePrice.batchRequestId);

        }

        private static CreateTrendyolProduct CreateTrendyolProduct(IdeaCatalog ideaCatalog)
        {
            try
            {


                var cargoCompany = ApplicationSettingHelper.ReadValue("Trendyol", "SelectedCargo");

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

                    return null;

                }

                float price = 0;
                price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;


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
                if (brand.Length == 0)
                    return null;
                var product = new EKirtasiye.Trendyol.CreateTrendyolProduct()
                {
                    barcode = ideaCatalog.Barcode,
                    description = ideaCatalog.Details,
                    vatRate = (ideaCatalog.Tax == string.Empty ? 18 : int.Parse(ideaCatalog.Tax)),
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
                    cargoCompanyId = int.Parse(cargoCompany),
                    //deliveryDuration = 3,
                    images = trendyolUrls.ToArray(),
                    returningAddressId = null,
                    shipmentAddressId = supplierAdress.defaultShipmentAddress.id,
                    categoryId = productCategory.TrendyolCategoryId,
                    productMainId = ideaCatalog.StockCode,

                };

                return product;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static string ExportProduct(IdeaCatalog[] ideaCatalogs)
        {


            try
            {


                var requestList = new EKirtasiye.Trendyol.CreateProductRequest()
                {
                    items = ideaCatalogs.Select(s => CreateTrendyolProduct(s)).Where(k => k != null).ToArray()
                };

                var returnV = productHelper.CreateProduct(requestList);

                if (returnV == null)
                {
                    return "Post işlemi başarısız ";
                }

                foreach (var item in requestList.items)
                {
                    var ideaCatalog = ideaCatalogs.FirstOrDefault(s => s.StockCode == item.stockCode);
                    ApiHelper.SaveTrendyolCreateRequest(new EKirtasiye.Model.TrendyolCreateRequest()
                    {
                        ProductId = ideaCatalog.Id,
                        BatchRequest = returnV.batchRequestId,
                        RequestType = "Create"

                    });
                    var updateDB = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                    {
                        Exported = true,
                        Id = ideaCatalog.Id,
                        ShopName = "Trendyol",
                        ShopPrice = ""
                    });
                }

                return "ok";
                /*
                var requst = productHelper.GetBatchRequest(returnV.batchRequestId);
                if (requst.failedItemCount == 0)
                {

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
                }*/

                //return "ok";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
