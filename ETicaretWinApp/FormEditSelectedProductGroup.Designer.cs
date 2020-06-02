namespace ETicaretWinApp
{
    partial class FormEditSelectedProductGroup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditSelectedProductGroup));
            this.buttonOk = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeListCategory = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.Location = new System.Drawing.Point(541, 399);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(144, 32);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Tamam";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 105);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // treeListCategory
            // 
            this.treeListCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListCategory.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.treeListCategory.DataSource = null;
            this.treeListCategory.Location = new System.Drawing.Point(131, 13);
            this.treeListCategory.Name = "treeListCategory";
            this.treeListCategory.OptionsBehavior.Editable = false;
            this.treeListCategory.Size = new System.Drawing.Size(554, 368);
            this.treeListCategory.TabIndex = 3;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Group Adı";
            this.treeListColumn1.FieldName = "CategoryName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Hepsi Burada Grup Adı";
            this.treeListColumn2.FieldName = "HepsiBuradaCategoryName";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "N11 Group Adı";
            this.treeListColumn3.FieldName = "N11CategoryName";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            // 
            // FormEditSelectedProductGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 443);
            this.Controls.Add(this.treeListCategory);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormEditSelectedProductGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditSelectedProductGroup";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonOk;
        private DevExpress.XtraTreeList.TreeList treeListCategory;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
    }
}