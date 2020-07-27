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


            foreach (var ideaCatalog in lSearchCatalogList)
            {

                try
                {

                    TrendyolHelper.ExportProduct(ideaCatalog);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex);
                }
            }

        }

        private void MenuItemPriceUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                TrendyolHelper.OpenProductAccepted("5010993447503");

              //  var batchResult = TrendyolHelper.UpdatePriceAndEnvantor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
