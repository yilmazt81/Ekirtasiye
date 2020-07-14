using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.Model;
using ETicaretWinApp.Controls;

namespace ETicaretWinApp
{
    public partial class FormTrendyoldefaultAttribute : Form
    {
        private int _categoryId = 0;
        public FormTrendyoldefaultAttribute(int categoryId)
        {
            InitializeComponent();
            _categoryId = categoryId;

            var attributeList = ApiHelper.GetTrendyolCategorieAttributes(_categoryId);
            foreach (var item in attributeList)
            {
                LoadTrendyolAttribute(item);
            }

        }

        private void LoadTrendyolAttribute(TrendyolAttribute trendyolAttribute)
        {
            UTrendyolAttribute uTrendyol = new UTrendyolAttribute()
            {
                Attribute = trendyolAttribute
            };
            this.fLayoutPanelAttribute.Controls.Add(uTrendyol);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }
    }
}
