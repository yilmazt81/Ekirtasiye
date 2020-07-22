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
    public partial class UTrendyolAttribute : UserControl
    {
        public UTrendyolAttribute()
        {
            InitializeComponent();
        }

        TrendyolAttribute trendyolAttribute = null;
        public TrendyolAttribute Attribute {
            get {
                return trendyolAttribute;

            }
            set {
                trendyolAttribute = value;
                label1.Text = value.Attributename;
                var arr = value.TrendyolAttributes.ToList();
                arr.Insert(0, new TrendyolAttributeValue() { AttributeText = "Seçiniz" });
                comboBoxValues.DataSource = arr;
                comboBoxValues.ValueMember = "AttributeValue";
                comboBoxValues.DisplayMember = "AttributeText";
            }
        }

        public int AttributeValue {
            get {
               return (int)comboBoxValues.SelectedValue;

            }
            set {
                comboBoxValues.SelectedValue = value;
            }
        }
    }
}
