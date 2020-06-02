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


namespace ETicaretWinApp
{
    public partial class FormShopSetting : Form
    {
        EKirtasiye.N11.CategoryHelper categoryHelper = null;
        public FormShopSetting()
        {
            InitializeComponent();

            textBoxHBProductAdress.Text = ApplicationSettingHelper.ReadValue("HepsiBurada", "HBProductAdress");
            textBoxHBListingAdress.Text = ApplicationSettingHelper.ReadValue("HepsiBurada", "HBListingAdress");

            textBoxHBMerchandId.Text = ApplicationSettingHelper.ReadValue("HepsiBurada", "HBMerchandId");
            textBoxHBPassword.Text = ApplicationSettingHelper.ReadValue("HepsiBurada", "HBPassword");
            textBoxHBUserName.Text = ApplicationSettingHelper.ReadValue("HepsiBurada", "HBUserName");
            textBoxN11AppKey.Text = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
            textBoxN11SecretKey.Text = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplicationSettingHelper.AddValue("HepsiBurada", "HBProductAdress", textBoxHBProductAdress.Text);

            ApplicationSettingHelper.AddValue("HepsiBurada", "HBMerchandId", textBoxHBMerchandId.Text);
            ApplicationSettingHelper.AddValue("HepsiBurada", "HBPassword", textBoxHBPassword.Text);
            ApplicationSettingHelper.AddValue("HepsiBurada", "HBUserName", textBoxHBUserName.Text);
            ApplicationSettingHelper.AddValue("N11", "N11AppKey", textBoxN11AppKey.Text);
            ApplicationSettingHelper.AddValue("N11", "N11SecretKey", textBoxN11SecretKey.Text);
            ApplicationSettingHelper.AddValue("HepsiBurada", "HBListingAdress", textBoxHBListingAdress.Text);

            DialogResult = DialogResult.OK;
        }

        private void Save11Category(EKirtasiye.N11.N11Category n11Category)
        {
            ApiHelper.SaveN11Category(new N11Category()
            {
                Id = n11Category.Id,
                Name = n11Category.Name,
                ParentCategoryId = n11Category.ParentId
            });

            var subCategory = categoryHelper.GetSubCategories(n11Category.Id);
            foreach (var item in subCategory)
            {
                Save11Category(item);
            }

        }
        private void buttonN11CategoryGet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxN11AppKey.Text))
            {

                MessageBox.Show("Api Key girmelisiniz ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                categoryHelper = new EKirtasiye.N11.CategoryHelper(textBoxN11AppKey.Text, textBoxN11SecretKey.Text);

                var categoryList = categoryHelper.GetTopCategory();

                foreach (var item in categoryList)
                {
                    Save11Category(item);
                }

                MessageBox.Show("İşlem Bitti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }

        }
    }
}
