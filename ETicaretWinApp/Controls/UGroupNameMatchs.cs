using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ETicaretWinApp
{
    public partial class UGroupNameMatchs : UserControl
    {
        public UGroupNameMatchs(List<ProductCategory> productCategories)
        {
            InitializeComponent();
          
            comboBoxGroupName.DataSource = productCategories;
        }

        public string MuhasebeGroupName { get {
               return textBoxGroupName.Text;

            }
            set {
                textBoxGroupName.Text = value;
            }
        }

        public ProductCategory SelectedValue { get {

                return (ProductCategory)comboBoxGroupName.SelectedItem;
            }
            set {
                comboBoxGroupName.SelectedItem = value; 
            }
        }


    }
}
