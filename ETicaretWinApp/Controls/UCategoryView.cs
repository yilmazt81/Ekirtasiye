using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace ETicaretWinApp.Controls
{
    public partial class UCategoryView : UserControl
    {
        private ProductCategory _mainCategory, _subCategory, _category = null;
        private List<ProductCategory> mainCategoryList = null;
        private List<TreeNodeWithCategory> treeNodeWithCategories = new List<TreeNodeWithCategory>();
        public UCategoryView()
        {
            InitializeComponent();




        }

        private void LoadItemCategory(TreeListNode treeNode, IEnumerable<ProductCategory> productCategories)
        {
            foreach (var productCategory in productCategories)
            {


                var subNode = treeListCategory.AppendNode(new object[] { productCategory.CategoryName, productCategory.HepsiBuradaCategoryName, productCategory.N11CategoryName, productCategory.N11ExportTemplateName }, treeNode);
                subNode.Tag = productCategory;
                treeNodeWithCategories.Add(new TreeNodeWithCategory()
                {
                    CategoryId = productCategory.Id,
                    Node = subNode
                });

                LoadItemCategory(subNode, mainCategoryList.Where(s => s.UpId == productCategory.Id));
                // treeNode.Nodes.Add(subNode);
            }
        }

        public void RefreshMainGroup()
        {
            mainCategoryList = ApiHelper.GetAllProductCategories().ToList();
            mainCategoryList.Insert(0, new ProductCategory()
            {
                CategoryName = "Tümü",
                N11CategoryName = "",
                HepsiBuradaCategoryName = "",
                Id = 0
            });
            treeNodeWithCategories = new List<TreeNodeWithCategory>();
            if (treeListCategory.Columns.Count == 0)
            {


                treeListCategory.BeginUpdate();
                TreeListColumn col1 = treeListCategory.Columns.Add();
                col1.Caption = "Kategory";
                col1.VisibleIndex = 0;

                TreeListColumn col2 = treeListCategory.Columns.Add();
                col2.Caption = "HepsiBurada Kategory";
                col2.VisibleIndex = 0;

                TreeListColumn col3 = treeListCategory.Columns.Add();
                col3.Caption = "N11 Kategory";
                col3.VisibleIndex = 0;

                TreeListColumn col4 = treeListCategory.Columns.Add();
                col4.Caption = "N11 Export Template";
                col4.VisibleIndex = 0;


                treeListCategory.EndUpdate();

                treeListCategory.BeginUnboundLoad();
            }
            foreach (var productCategory in mainCategoryList.Where(s => s.UpId == 0))
            {

                TreeListNode parentForRootNodes = null;
                TreeListNode rootNode = treeListCategory.AppendNode(new object[] { productCategory.CategoryName, productCategory.HepsiBuradaCategoryName, productCategory.N11CategoryName, productCategory.N11ExportTemplateName }, parentForRootNodes);
                rootNode.Tag = productCategory; 
                rootNode.Checked = productCategory.TargetCategory;
                treeNodeWithCategories.Add(new TreeNodeWithCategory()
                {
                    CategoryId = productCategory.Id,
                    Node = rootNode
                });
                if (productCategory.Id == 0)
                    continue;
                LoadItemCategory(rootNode, mainCategoryList.Where(s => s.UpId == productCategory.Id));
            }

            treeListCategory.ShowFindPanel();
            treeListCategory.EndUnboundLoad();

            /*
            treeListCategory.ParentFieldName = "UpId";
            treeListCategory.KeyFieldName = "Id";
            treeListCategory.DataSource = mainCategoryList;

            treeListCategory.ShowFindPanel();
            */
        }

        private void SetCategoryValues()
        {
            _category = new ProductCategory();
            _subCategory = new ProductCategory();
            _mainCategory = new ProductCategory();

            if (treeListCategory.Selection.Count == 0)
            {
                _mainCategory = new ProductCategory()
                {
                    CategoryName = "Tümü"
                };

                _category = _mainCategory;
                _subCategory = _mainCategory;
                return;
            }

            var selectedNode = treeListCategory.Selection[0];
            var selectedCategory = (ProductCategory)selectedNode.Tag;
            if (selectedCategory == null)
            {
                return;
            }
            if (selectedNode.Level == 0)
            {
                _mainCategory = selectedCategory;
            }
            else if (selectedNode.Level == 1)
            {

                _mainCategory = ApiHelper.GetCategory(selectedCategory.UpId);
                _category = selectedCategory;
            }
            else if (selectedNode.Level > 1)
            {
                var category = ApiHelper.GetCategory(selectedCategory.UpId);
                var mainCategory = ApiHelper.GetCategory(category.UpId);

                _mainCategory = mainCategory;
                _category = category;
                _subCategory = selectedCategory;
            }

        }

        public ProductCategory MainCategory {
            get {

                SetCategoryValues();

                return _mainCategory;
            }
            set {

                _mainCategory = value;
                if (_mainCategory != null && _mainCategory.Id != 0)
                {
                    var treeNodeItem = treeNodeWithCategories.SingleOrDefault(s => s.CategoryId == _mainCategory.Id);
                    treeListCategory.FocusedNode = treeNodeItem.Node;
                }
            }

        }




        public ProductCategory Category {
            get {
                SetCategoryValues();

                return _category;
            }
            set {
                _category = value;
                if (_category != null && _category.Id != 0)
                {
                    var treeNodeItem = treeNodeWithCategories.SingleOrDefault(s => s.CategoryId == _category.Id);
                    treeListCategory.FocusedNode = treeNodeItem.Node;

                }

            }
        }

        private void MenuItemNew_Click(object sender, EventArgs e)
        {
            if (treeListCategory.Selection.Count == 0)
                return;
            try
            {
                FormEditCategory formEditCategory = new FormEditCategory();
                ProductCategory productCategoryUp = null;
                if (Category != null)
                    productCategoryUp = Category;
                else if (SubCategory != null)
                    productCategoryUp = SubCategory;
                else if (MainCategory != null)
                    productCategoryUp = MainCategory;

                if (productCategoryUp != null)
                {
                    formEditCategory.UpCategoryName = productCategoryUp.CategoryName;
                }
                else
                {
                    formEditCategory.UpCategoryName = "Ana Kategory";
                }

                if (formEditCategory.ShowDialog() == DialogResult.OK)
                {
                    ProductCategory productCategory = formEditCategory.ProductCategory;
                    productCategory.UpId = productCategoryUp.Id;

                    if (!ApiHelper.InsertCategory(productCategory))
                    {
                        MessageBox.Show("Kategory Eklenemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    treeListCategory.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            if (treeListCategory.Selection.Count == 0)
                return;

            try
            {
                if (treeListCategory.Selection.Count == 0)
                    return;

                var selectedNode = treeListCategory.Selection[0];
                var selectedCategory = (ProductCategory)selectedNode.Tag;

                FormEditCategory formEditCategory = new FormEditCategory();
                formEditCategory.ProductCategory = selectedCategory;

                if (formEditCategory.ShowDialog() == DialogResult.OK)
                {
                    selectedCategory = formEditCategory.ProductCategory;

                    if (!ApiHelper.InsertCategory(selectedCategory))
                    {
                        MessageBox.Show("Kategory Eklenemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }                   
                    //treeListCategory.RefreshDataSource();
                }

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }

        public ProductCategory SubCategory {
            get {
                SetCategoryValues();
                return _subCategory;
            }
            set {
                _subCategory = value;
                if (_subCategory != null && _subCategory.Id != 0)
                {

                    var treeNodeItem = treeNodeWithCategories.SingleOrDefault(s => s.CategoryId == _subCategory.Id);
                    treeListCategory.FocusedNode = treeNodeItem.Node;
                    
                }

            }
        }



    }
}
