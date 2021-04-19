using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.Model;

namespace ETicaretWinApp.Controls
{
    public partial class UCicekSepetiAttribute : UserControl
    {
        public UCicekSepetiAttribute()
        {
            InitializeComponent();
        }

        CicekSepetiAttribute cicekSepetiAttribute = null;
        public CicekSepetiAttribute Attribute {
            get {
                return cicekSepetiAttribute;

            }
            set {
                cicekSepetiAttribute = value;
                label1.Text = value.Name;
                if (cicekSepetiAttribute.Required)
                {
                    label1.ForeColor = Color.Red;
                }else
                {
                    label1.ForeColor = Color.Black;
                }
                var arr = value.AttributeValues.OrderBy(s=>s.AttributeText).ToList();
                arr.Insert(0, new CicekSepetiAttributeValue() { AttributeText = "Seçiniz", AttributeValue = "0" });
                comboBoxValues.DataSource = arr;
                comboBoxValues.ValueMember = "AttributeValue";
                comboBoxValues.DisplayMember = "AttributeText";
            }
        }

        public string AttributeValue {
            get {
                return comboBoxValues.SelectedValue.ToString();

            }
            set {
                comboBoxValues.SelectedValue = value;
            }
        }
        

        public string AttributeValueText {
            get {

                return ((CicekSepetiAttributeValue)comboBoxValues.SelectedItem).AttributeText;
            }
        }
    }
}
