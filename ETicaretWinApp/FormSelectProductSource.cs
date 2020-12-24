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

           var targetExport= ApiHelper.GetIdeaExportTargets();

            comboBoxTargetExport.DisplayMember = "Name";
            comboBoxTargetExport.ValueMember = "Id";
            comboBoxTargetExport.DataSource = targetExport;



        }

        public IdeaExportTarget ExportTarget { get {

                return (IdeaExportTarget)comboBoxTargetExport.SelectedItem;
            }
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

                DocumentFilterRequest documentFilterRequest = uProductFilterCombo1.DocumentFilterRequest;
 

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
