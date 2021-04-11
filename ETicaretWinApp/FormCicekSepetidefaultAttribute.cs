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
    public partial class FormCicekSepetidefaultAttribute : Form
    {
        private int _categoryId = 0; 
        List<UCicekSepetiAttribute> uCicekSepetiAttributes = new List<UCicekSepetiAttribute>();
        public FormCicekSepetidefaultAttribute(int categoryId,int cicekSepetiCategoryId)
        {
            InitializeComponent();
            _categoryId = categoryId;
            CicekSepetiHelper.SaveCicekSepetiAttribute(cicekSepetiCategoryId);

            var attributeList = ApiHelper.GetCicekSepetiCategorieAttributes(cicekSepetiCategoryId);
            foreach (var item in attributeList.Where(s=>s.Attributename!= "Dinamik Özellik"))
            {
                LoadAttribute(item);
            }

        }

        private void LoadAttribute(CicekSepetiAttribute trendyolAttribute)
        {
            UCicekSepetiAttribute uTrendyol = new UCicekSepetiAttribute()
            {
                Attribute = trendyolAttribute
            };

            var attributedefaultValue = ApiHelper.GetCicekSepetiCategoryDefaultAttribute(_categoryId, trendyolAttribute.Id);
            if (attributedefaultValue != null)
            {
                uTrendyol.AttributeValue = attributedefaultValue.AttributeValue.ToString();
            }
            this.fLayoutPanelAttribute.Controls.Add(uTrendyol);
            uCicekSepetiAttributes.Add(uTrendyol);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            List<CicekSepetiCategoryDefaultAttribute> lCicekSepetiDefaultAttribute = new List<CicekSepetiCategoryDefaultAttribute>();
            foreach (var uTrendyolAttribute in uCicekSepetiAttributes)
            {

                lCicekSepetiDefaultAttribute.Add(new CicekSepetiCategoryDefaultAttribute()
                {
                    AttributeId = uTrendyolAttribute.Attribute.Id,
                    CategoryId = _categoryId,
                    AttributeName = uTrendyolAttribute.Attribute.Name,
                    AttributeValue = int.Parse(uTrendyolAttribute.AttributeValue),
                    AttributeValueText = uTrendyolAttribute.AttributeValueText
                });

            }
            var saveR = ApiHelper.SaveCategoryDefaultAttribute(lCicekSepetiDefaultAttribute);
            if (!saveR)
            {
                MessageBox.Show("Değerler kaydedilemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
