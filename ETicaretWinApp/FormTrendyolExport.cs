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
                var batchResult = TrendyolHelper.UpdatePriceAndEnvantor(new EKirtasiye.Trendyol.UpdatePriceAndInventor[] { new EKirtasiye.Trendyol.UpdatePriceAndInventor()
                {
                    barcode="0887961639872",
                    quantity=10,
                    listPrice=(float)780.5,
                    salePrice=(float)870.5
                } });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
