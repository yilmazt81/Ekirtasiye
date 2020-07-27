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
    public partial class FormEditCategory : Form
    {

        private ProductCategory productCategory = null;
        public FormEditCategory()
        {
            InitializeComponent();
            RefreshCombobox();

        }

        private void RefreshCombobox()
        {
            comboBoxN11ExportTemplate.DataSource = ApiHelper.GetN11ExportTemplate();
        }

        public string UpCategoryName {
            set {
                labelMainGroup.Text = value;
            }
        }

        public ProductCategory ProductCategory {
            get {
                if (productCategory == null)
                {
                    productCategory = new ProductCategory();
                }
                productCategory.CategoryName = textBoxCategoryName.Text;



                productCategory.N11CategoryId = (textBoxN11Category.Tag == null ? 0 : (int)textBoxN11Category.Tag);
                productCategory.HepsiBuradaCategoryId = (textBoxHepsiBuradaCategory.Tag == null ? 0 : (int)textBoxHepsiBuradaCategory.Tag);
                productCategory.TrendyolCategoryId = (textBoxTrendyolCategory.Tag == null ? 0 : (int)textBoxTrendyolCategory.Tag);


                var exportTemplate = (EKirtasiye.Model.N11ExportTemplate)comboBoxN11ExportTemplate.SelectedItem;
                productCategory.N11ExportTemplateId = exportTemplate.Id;
                productCategory.N11ExportTemplateName = exportTemplate.TemplateName;

                productCategory.TrendyolCategoryName = textBoxTrendyolCategory.Text;
                productCategory.N11CategoryName = textBoxN11Category.Text;
                productCategory.HepsiBuradaCategoryName = textBoxHepsiBuradaCategory.Text;

                return productCategory;
            }
            set {
                productCategory = value;
                textBoxCategoryName.Text = productCategory.CategoryName;
                textBoxHepsiBuradaCategory.Text = productCategory.HepsiBuradaCategoryName;
                textBoxN11Category.Text = productCategory.N11CategoryName;
                textBoxTrendyolCategory.Text = productCategory.TrendyolCategoryName;

                textBoxN11Category.Tag = productCategory.N11CategoryId;
                textBoxHepsiBuradaCategory.Tag = productCategory.HepsiBuradaCategoryId;
                textBoxTrendyolCategory.Tag = productCategory.TrendyolCategoryId;


            }
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCategoryName.Text))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonHepsiBurada_Click(object sender, EventArgs e)
        {
            var hepsiBuradaCategoryList = ApiHelper.GetHepsiBuradaCategories();
            if (hepsiBuradaCategoryList == null)
            {
                MessageBox.Show("Category Listesi Alınamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormShopEntegrationCategory formShopEntegrationCategory = new FormShopEntegrationCategory();
            formShopEntegrationCategory.ShowCheckBoxes = false;
            formShopEntegrationCategory.LoadData(hepsiBuradaCategoryList);
            if (formShopEntegrationCategory.ShowDialog() == DialogResult.OK)
            {
                var tmpCateg = ProductCategory;
                tmpCateg.HepsiBuradaCategoryId = formShopEntegrationCategory.SelectedCategory.Id;
                tmpCateg.HepsiBuradaCategoryName = formShopEntegrationCategory.SelectedCategory.CategoryName;
                ProductCategory = tmpCateg;
            }

        }

        private void buttonN11_Click(object sender, EventArgs e)
        {
            var n11CategoryList = ApiHelper.GetN11Category();
            if (n11CategoryList == null)
            {
                MessageBox.Show("Category Listesi Alınamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormShopEntegrationCategory formShopEntegrationCategory = new FormShopEntegrationCategory();
            formShopEntegrationCategory.ShowCheckBoxes = false;
            formShopEntegrationCategory.LoadData(n11CategoryList);
            if (formShopEntegrationCategory.ShowDialog() == DialogResult.OK)
            {
                var tmpCateg = ProductCategory;
                tmpCateg.N11CategoryId = formShopEntegrationCategory.SelectedCategory.Id;
                tmpCateg.N11CategoryName = formShopEntegrationCategory.SelectedCategory.CategoryName;
                ProductCategory = tmpCateg;
            }
        }

        private void buttonAddN11Template_Click(object sender, EventArgs e)
        {
            FormN11ExportTemplate formN11Export = new FormN11ExportTemplate();
            if (formN11Export.ShowDialog() == DialogResult.OK)
            {
                ApiHelper.SaveN11ExportTemplate(formN11Export.ExportTemplate);
                RefreshCombobox();
            }
        }

        private void buttonBrowsTrendyol_Click(object sender, EventArgs e)
        {
            var trendyolCategoryList = ApiHelper.GetTrendyolCategories();
            if (trendyolCategoryList == null)
            {
                MessageBox.Show("Category Listesi Alınamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormShopEntegrationCategory formShopEntegrationCategory = new FormShopEntegrationCategory();
            formShopEntegrationCategory.ShowCheckBoxes = false;
            formShopEntegrationCategory.LoadData(trendyolCategoryList);
            if (formShopEntegrationCategory.ShowDialog() == DialogResult.OK)
            {
                var tmpCateg = ProductCategory;
                tmpCateg.TrendyolCategoryId = formShopEntegrationCategory.SelectedCategory.Id;
                tmpCateg.TrendyolCategoryName = formShopEntegrationCategory.SelectedCategory.CategoryName;
                ProductCategory = tmpCateg;
            }
        }

        private void buttonTrendyolAttributes_Click(object sender, EventArgs e)
        {
            if (textBoxTrendyolCategory.Text == string.Empty)
                return;
            FormTrendyoldefaultAttribute formTrendyoldefaultAttribute = new FormTrendyoldefaultAttribute(this.ProductCategory.Id, this.ProductCategory.TrendyolCategoryId);
            if (formTrendyoldefaultAttribute.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void buttonN11Attribute_Click(object sender, EventArgs e)
        {
            if (textBoxN11Category.Text == string.Empty)
                return;

            EKirtasiye.N11.CategoryHelper categoryHelper = new EKirtasiye.N11.CategoryHelper(ApplicationSettingHelper.ReadValue("N11", "N11AppKey"), ApplicationSettingHelper.ReadValue("N11", "N11SecretKey"));
            categoryHelper.GetCategoryAttributes(this.ProductCategory.N11CategoryId);

            /*FormTrendyoldefaultAttribute formTrendyoldefaultAttribute = new FormTrendyoldefaultAttribute(this.ProductCategory.Id, this.ProductCategory.N11CategoryId);
            if (formTrendyoldefaultAttribute.ShowDialog() == DialogResult.OK)
            {

            }*/
        }
    }
}
