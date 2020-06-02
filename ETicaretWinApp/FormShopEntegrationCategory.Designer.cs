namespace ETicaretWinApp
{
    partial class FormShopEntegrationCategory
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
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.treeListCategory = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAccept.Location = new System.Drawing.Point(636, 492);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(123, 30);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "Tamam";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Image = global::ETicaretWinApp.Properties.Resources._50;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(491, 492);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(123, 30);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // treeListCategory
            // 
            this.treeListCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListCategory.DataSource = null;
            this.treeListCategory.Location = new System.Drawing.Point(12, 12);
            this.treeListCategory.Name = "treeListCategory";
            this.treeListCategory.OptionsBehavior.Editable = false;
            this.treeListCategory.Size = new System.Drawing.Size(747, 461);
            this.treeListCategory.TabIndex = 0;
            // 
            // FormShopEntegrationCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 534);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.treeListCategory);
            this.Name = "FormShopEntegrationCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pazaryeri  Kategory";
            ((System.ComponentModel.ISupportInitialize)(this.treeListCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private DevExpress.XtraTreeList.TreeList treeListCategory;
    }
}