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
                var arr = value.AttributeValues.ToList();
                arr.Insert(0, new CicekSepetiAttributeValue() { AttributeText = "Seçiniz" });
                comboBoxValues.DataSource = arr;
                comboBoxValues.ValueMember = "AttributeValue";
                comboBoxValues.DisplayMember = "AttributeText";
            }
        }

        public int AttributeValue {
            get {
               return Convert.ToInt32(comboBoxValues.SelectedValue);

            }
            set {
                comboBoxValues.SelectedValue = value;
            }
        }
    }
}
