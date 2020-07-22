using EKirtasiye.N11;
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
    public partial class FormShopManagerN11 : Form
    {
        EKirtasiye.N11.ProductHelper productHelper = null;
        ProductSaleService productSaleService = null;

        public FormShopManagerN11()
        {
            InitializeComponent();

            productHelper = new EKirtasiye.N11.ProductHelper(ApplicationSettingHelper.ReadValue("N11", "N11AppKey"), ApplicationSettingHelper.ReadValue("N11", "N11SecretKey"));
            productSaleService = new ProductSaleService(ApplicationSettingHelper.ReadValue("N11", "N11AppKey"), ApplicationSettingHelper.ReadValue("N11", "N11SecretKey"));
            comboBoxPageItemCount.SelectedIndexChanged += ComboBoxPageNumber_SelectedIndexChanged;

            comboBoxPageNumber.SelectedIndexChanged += ComboBoxPageNumber_SelectedIndexChanged;
            comboBoxPageItemCount.Text = ApplicationSettingHelper.ReadValue("ShopManagerN1", "PageItemCount", "50");
            LoadProduct();
        }

        private void LoadProduct()
        {
            try
            {
                int maxPageCount = 0;

                comboBoxPageItemCount.SelectedIndexChanged -= ComboBoxPageNumber_SelectedIndexChanged;

                comboBoxPageNumber.SelectedIndexChanged -= ComboBoxPageNumber_SelectedIndexChanged;

                int currentPage = (comboBoxPageNumber.Text == string.Empty ? 1 : int.Parse(comboBoxPageNumber.Text));
                var productList = productHelper.GetProductList(out maxPageCount, pageSize: int.Parse(comboBoxPageItemCount.Text), currentPage: currentPage);

                if (comboBoxPageNumber.Items.Count != maxPageCount)
                {
                    comboBoxPageNumber.Items.Clear();
                    for (int i = 1; i <= maxPageCount; i++)
                    {
                        comboBoxPageNumber.Items.Add(i);
                    }
                    comboBoxPageNumber.Text = currentPage.ToString();
                }

                gridControlProducts.DataSource = productList;

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
            finally
            {
                comboBoxPageItemCount.SelectedIndexChanged += ComboBoxPageNumber_SelectedIndexChanged;

                comboBoxPageNumber.SelectedIndexChanged += ComboBoxPageNumber_SelectedIndexChanged;
            }
        }

        private void ComboBoxPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void buttonCheckStok_Click(object sender, EventArgs e)
        {
            int maxPageCount = 0;
            int pageNumber = 1;
            bool complated = false;
            /*
            var productListDisable = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
            {
                N11Export = "Evet",
                ProductStatus = "Pasif"

            });

            foreach (var ideaCatalog in productListDisable)
            {
                if (!productHelper.DeleteProductBySellerCode(ideaCatalog.StockCode))
                {
                    MessageBox.Show("Silinemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                    {
                        Exported = false,
                        Id = ideaCatalog.Id,
                        ShopName = "N11"
                    });
                }
            }*/

            while (!complated)
            {

                var productList = productHelper.GetProductList(out maxPageCount, pageSize: 10, currentPage: pageNumber);
                if (productList.Count == 0)
                    complated = true;
                foreach (var n11Product in productList)
                {
                    var productListDB = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                    {
                        StokCodeList = new string[] { n11Product.ProductSellerCode },
                        ProductStatus = "Tümü"
                    });
                    if (productListDB.Count == 0)
                        continue;

                    ApiHelper.UpdateShopProductState(new EKirtasiye.Model.UpdateProductShopSaleRequest()
                    {
                        Id = productListDB[0].Id,
                        ShopName = "N11",
                        ApprovalStatus = n11Product.approvalStatus
                    });

                    //n11Product.approvalStatus
                    /*
                    if (productListDB.Count != 1)
                    {
                    }
                    else
                    {
                        var dbProduct = productListDB[0];
                        if (!dbProduct.Status)
                        {
                            productHelper.DeleteProductBySellerCode(dbProduct.StockCode);
                            ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                            {
                                Exported = false,
                                Id = dbProduct.Id,
                                ShopName = "N11"
                            });

                        }
                        else
                        {
                            if (dbProduct.N11ProductId == 0)
                            {
                                dbProduct.N11ProductId = n11Product.Id;
                                dbProduct.ExportN11 = true;
                                var apiReturn = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                                {
                                    Exported = true,
                                    Id = dbProduct.Id,
                                    ProductId = dbProduct.N11ProductId,
                                    ShopName = "N11"
                                });
                                if (!apiReturn)
                                {
                                    MessageBox.Show("Ürün DB ye update edilemedi", "Bilgi", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                        }

                    }*/
                }
                pageNumber++;
            }
        }

        private void buttonUpdateProductPrice_Click(object sender, EventArgs e)
        {
            try
            {
                var productListUpdate = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                {
                    N11Export = "Evet",
                    ProductStatus = "Aktif"
                });

                foreach (var ideaCatalog in productListUpdate)
                {
                    var _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
                    var _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
                    var productHelper = new ProductHelper(_apiKey, _secretKey);
                    float price = 0;
                    var stokCo = ideaCatalog.StockCode;

                    price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;
                    if (price > 150)
                    {
                        price = price + 20;
                    }
                    var update = productHelper.UpdateProductPrice(ideaCatalog.N11ProductId, (decimal)price, ideaCatalog.CurrencyAbbr);

                }

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }

        private void buttonDisableProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var productListUpdate = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                {
                    N11Export = "Aktif (Satışta)",
                    ProductStatus = "Pasif",
                    StokSource = "Ceren"
                }
                );

                foreach (var ideaCatalog in productListUpdate)
                {
                    var _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
                    var _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
                    var productHelper = new ProductHelper(_apiKey, _secretKey);
                    float price = 0;
                    var stokCo = ideaCatalog.StockCode;

                    if (ideaCatalog.N11ProductId != 0)
                    {
                        var update = productSaleService.DisableProduct(ideaCatalog.N11ProductId);


                    }
                    else
                    {
                        var update = productSaleService.DisableProduct(ideaCatalog.StockCode);

                    }

                }

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }

        private void buttonOpenProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var productListUpdate = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                {
                    N11Export = "Evet",
                    ProductStatus = "Aktif"
                }
                );

                foreach (var ideaCatalog in productListUpdate)
                {
                    var _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
                    var _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
                    var productHelper = new ProductHelper(_apiKey, _secretKey);
                    float price = 0;
                    var stokCo = ideaCatalog.StockCode;
                    price = float.Parse(ideaCatalog.MimimumPrice) * (float)1.15;
                    if (price > 150)
                    {
                        price = price + 20;
                    }
                    if (!ideaCatalog.Status)
                        continue;
                    if (ideaCatalog.N11ProductId != 0)
                    {

                        var updatePrice = productHelper.UpdateProductPrice(ideaCatalog.N11ProductId, (decimal)price, ideaCatalog.CurrencyAbbr);
                        if (updatePrice)
                        {
                            var update = productSaleService.StartProduct(ideaCatalog.N11ProductId);
                            ApiHelper.UpdateShopProductState(new EKirtasiye.Model.UpdateProductShopSaleRequest()
                            {
                                Id = ideaCatalog.Id,
                                ShopName = "N11",
                                ApprovalStatus = "1"
                            });

                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine("exx");
                        }


                    }
                    else
                    {
                        var updatePrice = productHelper.UpdateProductPriceSellerCode(ideaCatalog.StockCode, (decimal)price, ideaCatalog.CurrencyAbbr);
                        if (updatePrice)
                        {

                            var update = productSaleService.StartProduct(ideaCatalog.StockCode);
                            ApiHelper.UpdateShopProductState(new EKirtasiye.Model.UpdateProductShopSaleRequest()
                            {
                                Id = ideaCatalog.Id,
                                ShopName = "N11",
                                ApprovalStatus = "1"
                            });

                        }
                        else
                        {
                            System.Diagnostics.Trace.WriteLine("exx");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }
    }
}
