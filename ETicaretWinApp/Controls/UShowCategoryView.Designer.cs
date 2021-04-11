
namespace ETicaretWinApp.Controls
{
    partial class UShowCategoryView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeListCategory = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListCategory
            // 
            this.treeListCategory.DataSource = null;
            this.treeListCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListCategory.Location = new System.Drawing.Point(0, 0);
            this.treeListCategory.Name = "treeListCategory";
            this.treeListCategory.OptionsBehavior.Editable = false;
            this.treeListCategory.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.treeListCategory.OptionsFind.AllowIncrementalSearch = true;
            this.treeListCategory.OptionsFind.ExpandNodesOnIncrementalSearch = true;
            this.treeListCategory.Size = new System.Drawing.Size(499, 348);
            this.treeListCategory.TabIndex = 1;
            this.treeListCategory.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListCategory_FocusedNodeChanged);
            // 
            // UShowCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListCategory);
            this.Name = "UShowCategoryView";
            this.Size = new System.Drawing.Size(499, 348);
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListCategory;
    }
}
