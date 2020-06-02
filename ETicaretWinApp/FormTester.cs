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
    public partial class FormTester : Form
    {
        public FormTester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                 
                EKirtasiye.N11.CategoryHelper categoryHelper = new EKirtasiye.N11.CategoryHelper(ApplicationSettingHelper.ReadValue("N11", "N11AppKey"), ApplicationSettingHelper.ReadValue("N11", "N11SecretKey"));

                var category = categoryHelper.GetTopCategory();

                foreach (var n11Category in category)
                {
                    var subId = categoryHelper.GetSubCategories(n11Category.Id);

                }

                /*
                EKirtasiye.HepsiBurada.CatalogProductApiHelper apiHelper = new EKirtasiye.HepsiBurada.CatalogProductApiHelper("02879e22-0a4d-49be-8c54-6fca8c2ec8e3", "Kk12345!", "kirtasiyekurdu_dev", "https://mpop-sit.hepsiburada.com");
                apiHelper.Authenticate();

                EKirtasiye.HepsiBurada.ListingApiHelper listingApiHelper = new EKirtasiye.HepsiBurada.ListingApiHelper("02879e22-0a4d-49be-8c54-6fca8c2ec8e3",  "kirtasiyekurdu_dev", "Kk12345!", "https://listing-external-sit.hepsiburada.com/");

                listingApiHelper.GetSellerListing();

                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
