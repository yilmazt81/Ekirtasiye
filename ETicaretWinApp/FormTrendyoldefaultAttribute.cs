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
        List<UTrendyolAttribute> uTrendyolAttributes = new List<UTrendyolAttribute>();
        public FormTrendyoldefaultAttribute(int categoryId,int trendyolCategoryId)
        {
            InitializeComponent();
            _categoryId = categoryId;
            
            var attributeList = ApiHelper.GetTrendyolCategorieAttributes(trendyolCategoryId);
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

            var attributedefaultValue = ApiHelper.GetTrendyolCategoryDefaultAttribute(_categoryId, trendyolAttribute.Attributeid);
            if (attributedefaultValue != null)
            {
                uTrendyol.AttributeValue = attributedefaultValue.AttributeValue;
            }
            this.fLayoutPanelAttribute.Controls.Add(uTrendyol);
            uTrendyolAttributes.Add(uTrendyol);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            List<TrendyolCategoryDefaultAttribute> ltrendyolDefaultAttribute = new List<TrendyolCategoryDefaultAttribute>();
            foreach (var uTrendyolAttribute in uTrendyolAttributes)
            {

                ltrendyolDefaultAttribute.Add(new TrendyolCategoryDefaultAttribute()
                {
                    AttributeId = uTrendyolAttribute.Attribute.Attributeid,
                    CategoryId = _categoryId,
                    AttributeName = uTrendyolAttribute.Attribute.Attributename,
                    AttributeValue = uTrendyolAttribute.AttributeValue
                });

            }
            var saveR = ApiHelper.SaveCategoryDefaultAttribute(ltrendyolDefaultAttribute);
            if (!saveR)
            {
                MessageBox.Show("Değerler kaydedilemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
