using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using EKirtasiye.Model;

namespace ETicaretWinApp
{
    public partial class FormShopEntegrationCategory : Form
    {
        List<ProductCategory> _productCategories = null;
        public FormShopEntegrationCategory()
        {
            InitializeComponent();
        }


        public ProductCategory SelectedCategory {

            get {
                if (treeListCategory.Selection.Count == 0)
                    return null;

                var selectedElement = treeListCategory.Selection[0];

                return (ProductCategory)selectedElement.Tag;
            }
        }
        public void LoadData(List<HepsiBuradaCategory> hepsiBuradaCategories)
        {
            LoadData(hepsiBuradaCategories.Select(s => new ProductCategory()
            {
                CategoryName = s.Name,
                Id = s.CategoryId,
                UpId = s.ParentCategoryId,
                TargetCategory = s.TargetCategory
            }).ToList());
        }

        public void LoadData(List<CicekSepetiCategory> cicekSepetiCategories)
        {
            LoadData(cicekSepetiCategories.Select(s => new ProductCategory()
            {
                CategoryName = s.Name,
                Id = s.Id,
                UpId = s.ParentCategoryId,
                TargetCategory = s.TargetCategory
            }).ToList());
        }
        public void LoadData(List<TrendyolCategory> trendyolCategories)
        {
            LoadData(trendyolCategories.Select(s => new ProductCategory()
            {
                CategoryName = s.Name,
                Id = (int)s.Id,
                UpId = (int)s.ParentCategoryId,
                TargetCategory = s.TargetCategory
            }).ToList());
        }

        public void LoadData(List<N11Category> n11Categories)
        {
            LoadData(n11Categories.Select(s => new ProductCategory()
            {
                CategoryName = s.Name,
                Id = (int)s.Id,
                UpId = (int)s.ParentCategoryId,
                TargetCategory = s.TargetCategory
            }).ToList());
        }
        public void LoadData(List<ProductCategory> productCategorys)
        {
            _productCategories = productCategorys;
            var mainCategory = new List<ProductCategory>();
            if (!ShowCheckBoxes)
            {
                mainCategory = _productCategories.Where(s => s.UpId == 0 && s.TargetCategory).ToList();
            }
            else
            {
                mainCategory = _productCategories.Where(s => s.UpId == 0).ToList();
            }

            treeListCategory.BeginUpdate();
            TreeListColumn col1 = treeListCategory.Columns.Add();
            col1.Caption = "CategoryName";
            col1.VisibleIndex = 0;
            treeListCategory.EndUpdate();

            treeListCategory.BeginUnboundLoad();
          

            foreach (var productCategory in mainCategory)
            {
                if (!ShowCheckBoxes)
                {
                    if (!productCategory.TargetCategory)
                        continue;
                }
                TreeListNode parentForRootNodes = null;
                TreeListNode rootNode = treeListCategory.AppendNode(new object[] { productCategory.CategoryName }, parentForRootNodes);
                rootNode.Tag = productCategory;
                rootNode.Checked = productCategory.TargetCategory;
                LoadItemCategory(rootNode, _productCategories.Where(s => s.UpId == productCategory.Id));
            }

            treeListCategory.ShowFindPanel();
            treeListCategory.EndUnboundLoad();
        }
        private void LoadItemCategory(TreeListNode treeNode, IEnumerable<ProductCategory> productCategories)
        {
            foreach (var productCategory in productCategories)
            {
                if (!ShowCheckBoxes)
                {
                    if (!productCategory.TargetCategory)
                        continue;
                }

                var subNode = treeListCategory.AppendNode(new object[] { productCategory.CategoryName }, treeNode);
                subNode.Tag = productCategory;
                LoadItemCategory(subNode, _productCategories.Where(s => s.UpId == productCategory.Id));
                // treeNode.Nodes.Add(subNode);
            }
        }

        public bool ShowCheckBoxes {
            set {

                treeListCategory.OptionsView.ShowCheckBoxes = value;
            }
            get {
                return treeListCategory.OptionsView.ShowCheckBoxes;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
