using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.N11;

namespace ETicaretWinApp
{
    public partial class FormN11Export : Form
    {
        private string _apiKey, _secretKey = "";
        FormProductEdit productEdit = null;
        List<IdeaCatalog> lSearchCatalogList = null;
        private void FormN11Export_Load(object sender, EventArgs e)
        {
            lSearchCatalogList = ApiHelper.GetExportExternalShopExportProducts("N11").ToList();

            gridControl1.DataSource = lSearchCatalogList;
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            IdeaCatalog ideaCatalog = null;
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                var obj = gridView1.GetRow(row) as IdeaCatalog;
                ideaCatalog = obj;
                break;

            }

            if (ideaCatalog != null)
            {
                productEdit = new FormProductEdit();
                productEdit.SelectedProduct = ideaCatalog;
                productEdit.OnSaveAndNextDocument += ProductEdit_OnSaveAndNextDocument;
                productEdit.ShowDialog();
            }
        }
        private void ProductEdit_OnSaveAndNextDocument(string formName,IdeaCatalog ideaCatalog)
        {
            try
            {
                var saveIndex = lSearchCatalogList.IndexOf(ideaCatalog);
                lSearchCatalogList[saveIndex] = ideaCatalog;
                var nextCatalog = lSearchCatalogList[saveIndex + 1];
                productEdit.SelectedProduct = nextCatalog;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                // ShowException(ex);
            }

        }

        private void topluExportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (var ideaCatalog in lSearchCatalogList)
            {

                try
                {
                    var returnv = N11Helper.ExportProduct(ideaCatalog);
                    if (returnv != "ok")
                    {
                        System.Diagnostics.Trace.WriteLine(returnv);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex);
                }
            }
        }

        public FormN11Export()
        {
            InitializeComponent();
            try
            {
                _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
                _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
                var shipment = new ShipmentHelper(_apiKey, _secretKey);

            }
            catch (Exception e)
            {
                FormMain.ShowException(e);
            }
        }
    }
}
