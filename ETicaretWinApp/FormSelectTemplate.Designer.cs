namespace ETicaretWinApp
{
    partial class FormSelectTemplate
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUploadTemplate = new System.Windows.Forms.Button();
            this.pictureBoxSelected = new System.Windows.Forms.PictureBox();
            this.uProductPicturesTemplate = new ETicaretWinApp.Controls.UProductPictures();
            this.labelImageSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.Location = new System.Drawing.Point(727, 449);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(131, 34);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Tamam";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Image = global::ETicaretWinApp.Properties.Resources._50;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(573, 449);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(131, 34);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUploadTemplate
            // 
            this.buttonUploadTemplate.Image = global::ETicaretWinApp.Properties.Resources.add;
            this.buttonUploadTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUploadTemplate.Location = new System.Drawing.Point(398, 12);
            this.buttonUploadTemplate.Name = "buttonUploadTemplate";
            this.buttonUploadTemplate.Size = new System.Drawing.Size(137, 32);
            this.buttonUploadTemplate.TabIndex = 3;
            this.buttonUploadTemplate.Text = "Template Ekle";
            this.buttonUploadTemplate.UseVisualStyleBackColor = true;
            this.buttonUploadTemplate.Click += new System.EventHandler(this.buttonUploadTemplate_Click);
            // 
            // pictureBoxSelected
            // 
            this.pictureBoxSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSelected.Location = new System.Drawing.Point(573, 63);
            this.pictureBoxSelected.Name = "pictureBoxSelected";
            this.pictureBoxSelected.Size = new System.Drawing.Size(285, 376);
            this.pictureBoxSelected.TabIndex = 4;
            this.pictureBoxSelected.TabStop = false;
            // 
            // uProductPicturesTemplate
            // 
            this.uProductPicturesTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uProductPicturesTemplate.Location = new System.Drawing.Point(12, 63);
            this.uProductPicturesTemplate.Name = "uProductPicturesTemplate";
            this.uProductPicturesTemplate.Size = new System.Drawing.Size(523, 376);
            this.uProductPicturesTemplate.TabIndex = 0;
            // 
            // labelImageSize
            // 
            this.labelImageSize.AutoSize = true;
            this.labelImageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelImageSize.Location = new System.Drawing.Point(12, 17);
            this.labelImageSize.Name = "labelImageSize";
            this.labelImageSize.Size = new System.Drawing.Size(120, 20);
            this.labelImageSize.TabIndex = 5;
            this.labelImageSize.Text = "Image Boyutu : ";
            // 
            // FormSelectTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 491);
            this.Controls.Add(this.labelImageSize);
            this.Controls.Add(this.pictureBoxSelected);
            this.Controls.Add(this.buttonUploadTemplate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.uProductPicturesTemplate);
            this.Name = "FormSelectTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template Seçiniz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSelectTemplate_FormClosed);
            this.Load += new System.EventHandler(this.FormSelectTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.UProductPictures uProductPicturesTemplate;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUploadTemplate;
        private System.Windows.Forms.PictureBox pictureBoxSelected;
        private System.Windows.Forms.Label labelImageSize;
    }
}