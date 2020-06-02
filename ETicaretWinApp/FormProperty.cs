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
    public partial class FormProperty : Form
    {
        public FormProperty()
        {
            InitializeComponent();
        }

        public object SelectedObject {
            set {
                propertyGridControl.SelectedObject = value;
            }
            get {
               return propertyGridControl.SelectedObject;

            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
