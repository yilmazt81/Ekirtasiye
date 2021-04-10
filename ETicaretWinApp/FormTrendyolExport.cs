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




            try
            {
                foreach (var item in lSearchCatalogList)
                {
                    try
                    {

                        TrendyolHelper.ExportProduct(new IdeaCatalog[] { item });
                        System.Threading.Thread.Sleep(new TimeSpan(0, 0, 2));
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
                

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }


        }

        private void MenuItemPriceUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                //TrendyolHelper.OpenProductAccepted("5010993447503");

                //  var batchResult = TrendyolHelper.UpdatePriceAndEnvantor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var productListUpdate = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                {
                    ExportTrendyol = "Evet",
                    ProductStatus = "Aktif"
                });


                TrendyolHelper.OpenProductAccepted(productListUpdate.ToArray());
                System.Threading.Thread.Sleep(100);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
