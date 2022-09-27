namespace ETicaretWinApp.Controls
{
    partial class UCategoryView
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
            this.components = new System.ComponentModel.Container();
            this.treeListCategory = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cMenuStripCategory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).BeginInit();
            this.cMenuStripCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeListCategory
            // 
            this.treeListCategory.Appearance.BandPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treeListCategory.Appearance.BandPanel.Options.UseForeColor = true;
            this.treeListCategory.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5});
            this.treeListCategory.ContextMenuStrip = this.cMenuStripCategory;
            this.treeListCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListCategory.FixedLineWidth = 3;
            this.treeListCategory.HorzScrollStep = 4;
            this.treeListCategory.Location = new System.Drawing.Point(0, 0);
            this.treeListCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeListCategory.MinWidth = 27;
            this.treeListCategory.Name = "treeListCategory";
            this.treeListCategory.OptionsBehavior.Editable = false;
            this.treeListCategory.OptionsMenu.EnableNodeMenu = false;
            this.treeListCategory.Size = new System.Drawing.Size(997, 516);
            this.treeListCategory.TabIndex = 9;
            this.treeListCategory.TreeLevelWidth = 24;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Group Adı";
            this.treeListColumn1.FieldName = "CategoryName";
            this.treeListColumn1.MinWidth = 27;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 100;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Hepsi Burada Grup Adı";
            this.treeListColumn2.FieldName = "HepsiBuradaCategoryName";
            this.treeListColumn2.MinWidth = 27;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 100;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "N11 Group Adı";
            this.treeListColumn3.FieldName = "N11CategoryName";
            this.treeListColumn3.MinWidth = 27;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 100;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "N11 Export Template";
            this.treeListColumn4.FieldName = "N11 Export Template";
            this.treeListColumn4.MinWidth = 27;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 100;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "ÇiçekSepeti Group Adı";
            this.treeListColumn5.FieldName = "CicekSepetiCategoryName";
            this.treeListColumn5.MinWidth = 27;
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 100;
            // 
            // cMenuStripCategory
            // 
            this.cMenuStripCategory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMenuStripCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNew,
            this.MenuItemEdit});
            this.cMenuStripCategory.Name = "cMenuStripCategory";
            this.cMenuStripCategory.Size = new System.Drawing.Size(135, 56);
            // 
            // MenuItemNew
            // 
            this.MenuItemNew.Image = global::ETicaretWinApp.Properties.Resources._21;
            this.MenuItemNew.Name = "MenuItemNew";
            this.MenuItemNew.Size = new System.Drawing.Size(134, 26);
            this.MenuItemNew.Text = "Yeni";
            this.MenuItemNew.Click += new System.EventHandler(this.MenuItemNew_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Image = global::ETicaretWinApp.Properties.Resources.Edit;
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.Size = new System.Drawing.Size(134, 26);
            this.MenuItemEdit.Text = "Değiştir";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // UCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListCategory);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCategoryView";
            this.Size = new System.Drawing.Size(997, 516);
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).EndInit();
            this.cMenuStripCategory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTreeList.TreeList treeListCategory;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private System.Windows.Forms.ContextMenuStrip cMenuStripCategory;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
    }
}
