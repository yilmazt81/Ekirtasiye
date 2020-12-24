
using EKirtasiye.Model;
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
    public partial class FormEditSelectedProductGroup : Form
    {

        List<IdeaCatalog> _ideaCatalogs = new List<IdeaCatalog>();
        public FormEditSelectedProductGroup(List<IdeaCatalog> ideaCatalogs)
        {
            InitializeComponent();
            _ideaCatalogs = ideaCatalogs;

            LoadCategory(ApiHelper.GetAllProductCategories());
        }
        public void LoadCategory(List<ProductCategory> productCategories)
        {
            //uCategoryView1.RefreshMainGroup();

            treeListCategory.ParentFieldName = "UpId";
            treeListCategory.KeyFieldName = "Id";
            treeListCategory.DataSource = productCategories;

            treeListCategory.ShowFindPanel();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (treeListCategory.Selection.Count == 0)
                return;
            var selectedNode = treeListCategory.Selection[0];


            foreach (var item in _ideaCatalogs)
            {
                var selectedCategory = ApiHelper.GetCategory(int.Parse(selectedNode.GetValue("Id").ToString()));

                if (selectedNode.Level == 0)
                {
                    item.MainCategoryId = selectedCategory.Id;
                    item.Web_MainCategory = selectedCategory.CategoryName;
                }
                else if (selectedNode.Level == 1)
                {
                    item.MainCategoryId = selectedCategory.UpId;
                    item.Web_MainCategory = ApiHelper.GetCategory(selectedCategory.UpId).CategoryName;
                    item.CategoryId = selectedCategory.Id;
                    item.Web_Category = selectedCategory.CategoryName;
                }
                else if (selectedNode.Level > 1)
                {
                    var subCategory = ApiHelper.GetCategory(selectedCategory.Id);
                    var category = ApiHelper.GetCategory(selectedCategory.UpId);
                   
                    var mainCategory = ApiHelper.GetCategory(category.UpId);

                    item.MainCategoryId = mainCategory.Id;                   
                    item.Web_MainCategory = mainCategory.CategoryName;                    
                    item.Web_Category = category.CategoryName;
                    item.CategoryId = category.Id;

                    item.SubCategoryId = selectedCategory.Id;
                    item.Web_SubCategory = selectedCategory.CategoryName;
                }
            }
            var firstCategor = _ideaCatalogs.FirstOrDefault();
            var productUpdateReques = new UpdateProductGroupRequest()
            {
                ProductIdList = _ideaCatalogs.Select(s => s.Id).ToArray(),
                MainCategoryId = firstCategor.MainCategoryId,
                CategoryId = firstCategor.CategoryId,
                SubCategoryId = firstCategor.SubCategoryId
            };

            if (!ApiHelper.UpdateProductCategoryList(productUpdateReques))
            {
                MessageBox.Show("Update işleminde hata", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            DialogResult = DialogResult.OK;

        }
    }
}
