 
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
    public partial class FormUpdateProductGroup : Form
    {
        private string _columnName = "";
       
        List<ProductCategory> productCategories = new List<ProductCategory>();

        public FormUpdateProductGroup(string[] groupList,string columnName)
        {
            InitializeComponent();
            _columnName = columnName;
           
            productCategories.Insert(0, new ProductCategory() { CategoryName = "Seçiniz" });

            

            foreach (var productCategory in ApiHelper.GetProductCategoriesByUpId(0))
            {
                productCategories.Add(productCategory);

                foreach (var subCategory in ApiHelper.GetProductCategoriesByUpId(productCategory.Id))
                {
                    productCategories.Add(new ProductCategory()
                    {
                        Id = subCategory.Id,
                        UpId=productCategory.Id,
                        CategoryName = $"{ productCategory.CategoryName } - { subCategory.CategoryName } "
                    });

                    foreach (var subsubItem in ApiHelper.GetProductCategoriesByUpId(subCategory.Id))
                    {
                        productCategories.Add(new ProductCategory()
                        {
                            UpId = subCategory.Id,
                            Id = subsubItem.Id,
                            CategoryName = $@"{productCategory.CategoryName} - {subCategory.CategoryName}  - { subsubItem.CategoryName} "
                        });
                    }
                }
            }


            foreach (var oneGroup in groupList)
            {
                UGroupNameMatchs uGroupNameMatchs = new UGroupNameMatchs(productCategories);
                uGroupNameMatchs.MuhasebeGroupName = oneGroup;
                fLayoutPanelGroups.Controls.Add(uGroupNameMatchs);

            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                
                foreach (var oneControl in fLayoutPanelGroups.Controls)
                {
                    UGroupNameMatchs uGroupName = (UGroupNameMatchs)oneControl;
                    ProductCategory productCategory = uGroupName.SelectedValue;
                    if (productCategory.Id == 0)
                        continue;
                    var categoryArray = productCategory.CategoryName.Split('-');
                 
                    IdeaCatalogCategoryMatch ideaCatalogCategoryMatch = new IdeaCatalogCategoryMatch()
                    {
                        ImportName= uGroupName.MuhasebeGroupName,
                        ColumnName=_columnName    ,
                        SelectedFullName= productCategory.CategoryName

                    };
                    if (categoryArray.Length == 1)
                    {
                        ideaCatalogCategoryMatch.MainCategoryId = productCategory.Id;
                    }else if (categoryArray.Length == 2)
                    {
                        ideaCatalogCategoryMatch.MainCategoryId = productCategory.UpId;
                        ideaCatalogCategoryMatch.SubCategoryId = productCategory.Id;

                    }
                    else if (categoryArray.Length == 3)
                    {
                        var firstCategory = productCategories.FirstOrDefault(s => s.CategoryName == categoryArray[0].Trim());
                        ideaCatalogCategoryMatch.MainCategoryId = firstCategory.Id;
                        ideaCatalogCategoryMatch.SubCategoryId = productCategory.UpId;
                        ideaCatalogCategoryMatch.SubSubCategoryId = productCategory.Id;

                    }
                    //ProductCategoryRepository.SaveIdeaCatalogCategoryMatch(ideaCatalogCategoryMatch);

                }
                this.Close();
            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }
        }
    }
}
