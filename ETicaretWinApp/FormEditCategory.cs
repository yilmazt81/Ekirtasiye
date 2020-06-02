﻿using System;
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

                var exportTemplate = (EKirtasiye.Model.N11ExportTemplate)comboBoxN11ExportTemplate.SelectedItem;
                productCategory.N11ExportTemplateId = exportTemplate.Id;
                productCategory.N11ExportTemplateName = exportTemplate.TemplateName;
                return productCategory;
            }
            set {
                productCategory = value;
                textBoxCategoryName.Text = productCategory.CategoryName;
                textBoxHepsiBuradaCategory.Text = productCategory.HepsiBuradaCategoryName;
                textBoxN11Category.Text = productCategory.N11CategoryName;

                textBoxN11Category.Tag = productCategory.N11CategoryId;
                textBoxHepsiBuradaCategory.Tag = productCategory.HepsiBuradaCategoryId;
               // comboBoxN11ExportTemplate.SelectedValue=

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
    }
}