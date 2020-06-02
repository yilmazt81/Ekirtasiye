using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public partial class FormSelectProductSource : Form
    {
        public FormSelectProductSource()
        {
            InitializeComponent();
             
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public bool WorkAllRecord {
            get {
                return checkBoxExportAll.Checked;
            }
            set {
                checkBoxExportAll.Checked = value;
            }
        }
        public DocumentFilterRequest FilterRequest {
            get {

                DocumentFilterRequest documentFilterRequest = new DocumentFilterRequest()
                {
                   
                    StokSource = uProductFilterCombo1.StokSource,
                    WebExportState = uProductFilterCombo1.WebExportState,
                    HaveInternetPrice = uProductFilterCombo1.WebPrice,
                    ProductStatus= uProductFilterCombo1.ProductStatus,
                    StokCodeList = uProductFilterCombo1.StokCodeList.ToArray(),
                    HepsiBuradaExport = uProductFilterCombo1.ExportHB,
                    N11Export = uProductFilterCombo1.ExportN11,
                    PriceFilter = uProductFilterCombo1.PriceFilter,
                    PriceFilterType = uProductFilterCombo1.PriceFilterType

                };

                return documentFilterRequest;
            }
        } 


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBoxAddDiscount_CheckedChanged(object sender, EventArgs e)
        {
            panelDiscount.Visible = checkBoxAddDiscount.Checked;
        }
    }
}
