using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public partial class FormTrendyolExport : Form
    {
        List<IdeaCatalog> lSearchCatalogList = null;
        public FormTrendyolExport()
        {
            InitializeComponent();
        }

        private void FormTrendyolExport_Load(object sender, EventArgs e)
        {
            lSearchCatalogList = ApiHelper.GetExportExternalShopExportProducts("Trendyol").ToList();

            gridControl1.DataSource = lSearchCatalogList;
        }

        private void MenuItemBulkExport_Click(object sender, EventArgs e)
        {


            EKirtasiye.Trendyol.ProductHelper productHelper = new EKirtasiye.Trendyol.ProductHelper(ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint"), ApplicationSettingHelper.ReadValue("Trendyol", "SupplierId"), ApplicationSettingHelper.ReadValue("Trendyol", "UserName"), ApplicationSettingHelper.ReadValue("Trendyol", "Password"));
            EKirtasiye.Trendyol.BrandHelper brandHelper = new EKirtasiye.Trendyol.BrandHelper("");


            foreach (var ideaCatalog in lSearchCatalogList)
            {

                try
                {

                    var brand = brandHelper.GetBrandByName(ideaCatalog.Brand);
                    EKirtasiye.Trendyol.SuppliersAddressesHelper suppliersAddressesHelper = new EKirtasiye.Trendyol.SuppliersAddressesHelper(ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint"), ApplicationSettingHelper.ReadValue("Trendyol", "SupplierId"), ApplicationSettingHelper.ReadValue("Trendyol", "UserName"), ApplicationSettingHelper.ReadValue("Trendyol", "Password"));

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


                    float price = 0;
                    price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;
                    if (price > 150)
                    {
                        price = price + 20;
                    }

                    var defaultAttribute = ApiHelper.GetCategoryDefaultAttributes(productCategory.Id);
                    

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
                        brandId= brand.FirstOrDefault().id,
                        attributes = defaultAttribute.Select(s => new EKirtasiye.Trendyol.ProductCreateAttribute()
                        {
                            attributeId = s.AttributeId,
                            attributeValueId = s.AttributeValue.ToString()
                        }).ToArray(),
                        currencyType = ideaCatalog.CurrencyAbbr,
                        dimensionalWeight = ideaCatalog.Dm3,
                        listPrice = price.ToString().Replace(",", "."),
                        salePrice = price.ToString().Replace(",", "."),
                        cargoCompanyId = 1,
                        deliveryDuration = 5,
                        images = trendyolUrls.ToArray(),
                        returningAddressId = 0,
                        shipmentAddressId = supplierAdress.defaultShipmentAddress.id,
                        categoryId = productCategory.TrendyolCategoryId,
                        productMainId = ideaCatalog.Id.ToString()

                    };

                    var returnV = productHelper.CreateProduct(new EKirtasiye.Trendyol.CreateProductRequest()
                    {
                        items = new EKirtasiye.Trendyol.CreateTrendyolProduct[]
                           {
                            product
                           }
                    });

                    ApiHelper.SaveTrendyolCreateRequest(new EKirtasiye.Model.TrendyolCreateRequest()
                    {
                        ProductId = ideaCatalog.Id,
                        BatchRequest = returnV.batchRequestId

                    });

                    var requst = productHelper.GetBatchRequest(returnV.batchRequestId);


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex);
                }
            }

        }
    }
}
