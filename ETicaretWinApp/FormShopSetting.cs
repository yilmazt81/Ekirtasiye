using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.CicekSepeti;
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
            numDownHepsiMinProfit.Value= int.Parse(ApplicationSettingHelper.ReadValue("HepsiBurada", "MinimumProfit", "10"));

            textBoxN11AppKey.Text = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
            textBoxN11SecretKey.Text = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
            numUpDownN11Profit.Value =int.Parse(ApplicationSettingHelper.ReadValue("N11", "MinimumProfit", "10"));

            textBoxTyEndPoint.Text = ApplicationSettingHelper.ReadValue("Trendyol", "EndPoint");
            textBoxTyPassword.Text = ApplicationSettingHelper.ReadValue("Trendyol", "Password");
            textBoxTySupplierId.Text = ApplicationSettingHelper.ReadValue("Trendyol", "SupplierId");
            textBoxTyUserName.Text = ApplicationSettingHelper.ReadValue("Trendyol", "UserName");
            numUpDownTrendyolMinProfit.Value = int.Parse(ApplicationSettingHelper.ReadValue("Trendyol", "MinimumProfit", "10"));


            checkBoxUseTrend.Checked = bool.Parse(ApplicationSettingHelper.ReadValue("Trendyol", "UseTrend", "false"));
            checkBoxUseN11.Checked = bool.Parse(ApplicationSettingHelper.ReadValue("N11", "UseN11", "false"));
            checkBoxUseHb.Checked = bool.Parse(ApplicationSettingHelper.ReadValue("HepsiBurada", "HepsiBurada", "false"));
            checkBoxUseCicekSepeti.Checked = bool.Parse(ApplicationSettingHelper.ReadValue("CicekSepeti", "UseCicekSepeti", "false"));
            numUpDownMinCicekProfit.Value = int.Parse(ApplicationSettingHelper.ReadValue("CicekSepeti", "MinimumProfit", "10"));

            textBoxCicekSepetiSupplierId.Text = ApplicationSettingHelper.ReadValue("CicekSepeti", "SupplierId");
            textBoxCicekSepetiApiKey.Text = ApplicationSettingHelper.ReadValue("CicekSepeti", "ApiKey");
            textBoxCicekSepetiUrl.Text = ApplicationSettingHelper.ReadValue("CicekSepeti", "EndPoint");

            numUpDownN11Magazam.Value= int.Parse(ApplicationSettingHelper.ReadValue("N11Magazam", "MinimumProfit", "10"));
   


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
            ApplicationSettingHelper.AddValue("HepsiBurada", "UseHB", checkBoxUseHb.Checked.ToString());



            ApplicationSettingHelper.AddValue("HepsiBurada", "HBMerchandId", textBoxHBMerchandId.Text);
            ApplicationSettingHelper.AddValue("HepsiBurada", "HBPassword", textBoxHBPassword.Text);
            ApplicationSettingHelper.AddValue("HepsiBurada", "HBUserName", textBoxHBUserName.Text);

            ApplicationSettingHelper.AddValue("N11", "N11AppKey", textBoxN11AppKey.Text);
            ApplicationSettingHelper.AddValue("N11", "UseN11", checkBoxUseN11.Checked.ToString());

            ApplicationSettingHelper.AddValue("N11", "N11SecretKey", textBoxN11SecretKey.Text);
            ApplicationSettingHelper.AddValue("HepsiBurada", "HBListingAdress", textBoxHBListingAdress.Text);

            ApplicationSettingHelper.AddValue("Trendyol", "UseTrend", checkBoxUseTrend.Checked.ToString());

            ApplicationSettingHelper.AddValue("Trendyol", "EndPoint", textBoxTyEndPoint.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "Password", textBoxTyPassword.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "SupplierId", textBoxTySupplierId.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "UserName", textBoxTyUserName.Text);
            ApplicationSettingHelper.AddValue("Trendyol", "SelectedCargo", comboBoxTrendyolCargo.SelectedValue == null ? "" : comboBoxTrendyolCargo.SelectedValue.ToString());


            ApplicationSettingHelper.AddValue("CicekSepeti", "UseCicekSepeti", checkBoxUseCicekSepeti.Checked.ToString());
            ApplicationSettingHelper.AddValue("CicekSepeti", "SupplierId", textBoxCicekSepetiSupplierId.Text);
            ApplicationSettingHelper.AddValue("CicekSepeti", "ApiKey", textBoxCicekSepetiApiKey.Text);
            ApplicationSettingHelper.AddValue("CicekSepeti", "EndPoint", textBoxCicekSepetiUrl.Text);
            ApplicationSettingHelper.AddValue("N11", "MinimumProfit", numUpDownN11Profit.Value.ToString());
            ApplicationSettingHelper.AddValue("CicekSepeti", "MinimumProfit", numUpDownMinCicekProfit.Value.ToString());
            ApplicationSettingHelper.AddValue("Trendyol", "MinimumProfit", numUpDownTrendyolMinProfit.Value.ToString());

            ApplicationSettingHelper.AddValue("HepsiBurada", "MinimumProfit", numDownHepsiMinProfit.Value.ToString());
            ApplicationSettingHelper.AddValue("N11Magazam", "MinimumProfit", numUpDownN11Magazam.Value.ToString());

            DialogResult = DialogResult.OK;
        }

        private void Save11Category(EKirtasiye.N11.N11Category n11Category)
        {
            /* ApiHelper.SaveN11Category(new N11Category()
             {
                 Id = n11Category.Id,
                 Name = n11Category.Name,
                 ParentCategoryId = n11Category.ParentId
             });

             var subCategory = categoryHelper.GetSubCategories(n11Category.Id);
             foreach (var item in subCategory)
             {
                 Save11Category(item);
             }*/

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

        private void SaveCicekSepeti(CicekCategory cicekSepetiCategory)
        {

            ApiHelper.CicekSepetiSaveCategory(new CicekSepetiCategory()
            {
                Id = cicekSepetiCategory.id,
                Name = cicekSepetiCategory.name,
                ParentCategoryId = (cicekSepetiCategory.parentCategoryId == null ? 0 : Convert.ToInt32(cicekSepetiCategory.parentCategoryId)),
            });

            foreach (var category in cicekSepetiCategory.subCategories)
            {
                ApiHelper.CicekSepetiSaveCategory(new CicekSepetiCategory()
                {
                    Id = category.id,
                    Name = category.name,
                    ParentCategoryId = (category.parentCategoryId == null ? 0 : Convert.ToInt32(category.parentCategoryId)),
                });
                if (category.subCategories != null)
                {
                    SaveCicekSepeti(category);
                }
            }
        }
        /*
        private void SaveCicekSepetiSubCategory(int categoryId, List<CicekSepetiCategory> cicekCategories)
        {
            CicekSepetiApi cicekSepetiApi = new CicekSepetiApi(textBoxCicekSepetiUrl.Text, textBoxCicekSepetiSupplierId.Text, textBoxCicekSepetiApiKey.Text);

            var cicekSepetiCategoryAttribute = cicekSepetiApi.GetCategoryAttribute(categoryId);

            List<CicekSepetiAttribute> cicekSepetiAttributes = new List<CicekSepetiAttribute>();
            foreach (var categoryattribute in cicekSepetiCategoryAttribute.categoryAttributes)
            {
                CicekSepetiAttribute cicekSepetiCategory = new CicekSepetiAttribute()
                {
                    CategoryId = categoryId,
                    Attributeid = categoryattribute.attributeId,
                    DisplayName = categoryattribute.attributeName,
                    Required = categoryattribute.required,
                    Varianter = categoryattribute.varianter,
                    Attributename = categoryattribute.type,
                    Name = categoryattribute.attributeName,
                    AttributeValues = categoryattribute.attributeValues.Select(s => new CicekSepetiAttributeValue()
                    {
                        AttributeValue = s.id.ToString(),
                        AttributeText = s.name

                    }).ToArray()
                };
                cicekSepetiAttributes.Add(cicekSepetiCategory);
            }
            ApiHelper.SaveCicekSepetiAttributes(cicekSepetiAttributes);

            foreach (var item in cicekCategories.Where(s => s.ParentCategoryId == categoryId))
            {
                SaveCicekSepetiSubCategory(item.Id, cicekCategories);
            }

        }*/
        private void buttonCicekSepetiGetCategory_Click(object sender, EventArgs e)
        {
            try
            {


                var productHelper = new CicekSepetiApi(textBoxCicekSepetiUrl.Text, textBoxCicekSepetiSupplierId.Text, textBoxCicekSepetiApiKey.Text);

                var categoryList = productHelper.GetCategory();
                foreach (var category in categoryList.categories)
                {
                    SaveCicekSepeti(category);
                }


                /*
                var categoryList = ApiHelper.GetCicekSepetiCategories();
                SaveCicekSepetiSubCategory(12455, categoryList);
                 */


            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }

        }
    }
}
