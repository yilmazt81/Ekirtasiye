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

            textBoxTyEndPoint.Text = ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint");
            textBoxTyPassword.Text = ApplicationSettingHelper.ReadValue("Trendyol", "Password");
            textBoxTySupplierId.Text = ApplicationSettingHelper.ReadValue("Trendyol", "SupplierId");
            textBoxTyUserName.Text = ApplicationSettingHelper.ReadValue("Trendyol", "UserName");
            buttonTrendyolRefresh_Click(null, null);
            var selectedCargo = ApplicationSettingHelper.ReadValue("Trendyol", "SelectedCargo");
            if (!string.IsNullOrEmpty(selectedCargo))
            {
                comboBoxTrendyolCargo.SelectedValue = int.Parse(selectedCargo);
            }

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


            ApplicationSettingHelper.AddValue("Trendyol", "EndPoint", textBoxTyEndPoint.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "Password", textBoxTyPassword.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "SupplierId", textBoxTySupplierId.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "UserName", textBoxTyUserName.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "SelectedCargo",comboBoxTrendyolCargo.SelectedValue==null?"": comboBoxTrendyolCargo.SelectedValue.ToString());

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

        private void GetTrendyolAttribute(EKirtasiye.Trendyol.Category[] categories)
        {
            EKirtasiye.Trendyol.CategoryHelper categoryHelper = new EKirtasiye.Trendyol.CategoryHelper(textBoxTyEndPoint.Text);

            foreach (var category in categories)
            {

                try
                {
                    ApiHelper.TrendyolSaveCategory(new TrendyolCategory()
                    {
                        Name = category.name,
                        ParentCategoryId = category.parentId,
                        Id = category.id
                    });

                    var attributes = categoryHelper.GetCategoryAttributes(category.id);
                    if (attributes != null && attributes.categoryAttributes.Length > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("ddd");
                        foreach (var attribute in attributes.categoryAttributes)
                        {
                            ApiHelper.TrendyolSaveAttribute(new TrendyolAttribute()
                            {
                                Name = attribute.attribute.name,
                                Attributename = attribute.attribute.name,
                                AllowCustom = attribute.allowCustom,
                                Attributeid = attribute.attribute.id,
                                CategoryId = category.id,
                                DisplayName = attribute.attribute.name,
                                Required = attribute.required,
                                Slicer = attribute.slicer,
                                Varianter = attribute.varianter,
                                TrendyolAttributes = (attribute.attributeValues == null ? null : attribute.attributeValues.Select(s => new TrendyolAttributeValue()
                                {
                                    AttributeText = s.name,
                                    AttributeValue = s.id
                                })).ToArray()
                            });
                        }
                    }
                    if (category.subCategories.Length != 0)
                    {
                        GetTrendyolAttribute(category.subCategories);
                    }
                }
                catch (Exception ex)
                {

                    System.Diagnostics.Trace.WriteLine(ex);
                }
            }
        }


        private void buttonGetCategoryTrendyol_Click(object sender, EventArgs e)
        {
            if (textBoxTyEndPoint.Text == string.Empty)
                return;
            try
            {

                EKirtasiye.Trendyol.CategoryHelper categoryHelper = new EKirtasiye.Trendyol.CategoryHelper(textBoxTyEndPoint.Text);

                var categoryRequestReturn = categoryHelper.GetTrendyolCategories();

                foreach (var category in categoryRequestReturn.categories)
                {
                    try
                    {
                        var attributes = categoryHelper.GetCategoryAttributes(category.id);

                        if (attributes != null && attributes.categoryAttributes.Length > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("ddd");

                            foreach (var attribute in attributes.categoryAttributes)
                            {
                                ApiHelper.TrendyolSaveAttribute(new TrendyolAttribute()
                                {
                                    Name = attribute.attribute.name,
                                    Attributename = attribute.attribute.name,
                                    AllowCustom = attribute.allowCustom,
                                    Attributeid = attribute.attribute.id,
                                    CategoryId = category.id,
                                    DisplayName = attribute.attribute.name,
                                    Required = attribute.required,
                                    Slicer = attribute.slicer,
                                    Varianter = attribute.varianter,
                                    TrendyolAttributes = (attribute.attributeValues == null ? null : attribute.attributeValues.Select(s => new TrendyolAttributeValue()
                                    {
                                        AttributeText = s.name,
                                        AttributeValue = s.id
                                    })).ToArray()
                                });
                            }
                        }
                        ApiHelper.TrendyolSaveCategory(new TrendyolCategory()
                        {
                            Name = category.name,
                            ParentCategoryId = category.parentId,
                            Id = category.id
                        });
                        GetTrendyolAttribute(category.subCategories);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex);
                    }
                }



            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }
        }

        private void buttonTrendyolRefresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTyEndPoint.Text))
                return;
            try
            {
                EKirtasiye.Trendyol.ShipmentHelper trendyolCargo = new EKirtasiye.Trendyol.ShipmentHelper(textBoxTyEndPoint.Text);
                var cargoCompany = trendyolCargo.GetShipMentCompany();
                comboBoxTrendyolCargo.ValueMember = "id";
                comboBoxTrendyolCargo.DisplayMember = "name";
                comboBoxTrendyolCargo.DataSource = cargoCompany;
            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }

        }
    }
}
