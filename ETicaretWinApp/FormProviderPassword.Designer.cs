namespace ETicaretWinApp
{
    partial class FormProviderPassword
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCerenUserName = new System.Windows.Forms.TextBox();
            this.textBoxCerenPassword = new System.Windows.Forms.TextBox();
            this.textBoxCerenCategory = new System.Windows.Forms.TextBox();
            this.textBoxDeryaCategory = new System.Windows.Forms.TextBox();
            this.textBoxDeryaPassword = new System.Windows.Forms.TextBox();
            this.textBoxDeryaUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDeryaUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCerenUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Image = global::ETicaretWinApp.Properties.Resources._50;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(61, 266);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(149, 35);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.Location = new System.Drawing.Point(251, 266);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(149, 35);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Tamam";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 32);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(387, 210);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxCerenUrl);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.textBoxCerenCategory);
            this.tabPage1.Controls.Add(this.textBoxCerenPassword);
            this.tabPage1.Controls.Add(this.textBoxCerenUserName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(379, 178);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ceren";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxDeryaUrl);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBoxDeryaCategory);
            this.tabPage2.Controls.Add(this.textBoxDeryaPassword);
            this.tabPage2.Controls.Add(this.textBoxDeryaUserName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(379, 178);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Derya Dağıtım";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "KategoryId";
            // 
            // textBoxCerenUserName
            // 
            this.textBoxCerenUserName.Location = new System.Drawing.Point(132, 24);
            this.textBoxCerenUserName.Name = "textBoxCerenUserName";
            this.textBoxCerenUserName.Size = new System.Drawing.Size(216, 27);
            this.textBoxCerenUserName.TabIndex = 3;
            // 
            // textBoxCerenPassword
            // 
            this.textBoxCerenPassword.Location = new System.Drawing.Point(132, 59);
            this.textBoxCerenPassword.Name = "textBoxCerenPassword";
            this.textBoxCerenPassword.PasswordChar = '*';
            this.textBoxCerenPassword.Size = new System.Drawing.Size(216, 27);
            this.textBoxCerenPassword.TabIndex = 4;
            // 
            // textBoxCerenCategory
            // 
            this.textBoxCerenCategory.Location = new System.Drawing.Point(132, 96);
            this.textBoxCerenCategory.Name = "textBoxCerenCategory";
            this.textBoxCerenCategory.Size = new System.Drawing.Size(83, 27);
            this.textBoxCerenCategory.TabIndex = 5;
            // 
            // textBoxDeryaCategory
            // 
            this.textBoxDeryaCategory.Location = new System.Drawing.Point(124, 93);
            this.textBoxDeryaCategory.Name = "textBoxDeryaCategory";
            this.textBoxDeryaCategory.Size = new System.Drawing.Size(83, 27);
            this.textBoxDeryaCategory.TabIndex = 11;
            // 
            // textBoxDeryaPassword
            // 
            this.textBoxDeryaPassword.Location = new System.Drawing.Point(124, 56);
            this.textBoxDeryaPassword.Name = "textBoxDeryaPassword";
            this.textBoxDeryaPassword.PasswordChar = '*';
            this.textBoxDeryaPassword.Size = new System.Drawing.Size(216, 27);
            this.textBoxDeryaPassword.TabIndex = 10;
            // 
            // textBoxDeryaUserName
            // 
            this.textBoxDeryaUserName.Location = new System.Drawing.Point(124, 21);
            this.textBoxDeryaUserName.Name = "textBoxDeryaUserName";
            this.textBoxDeryaUserName.Size = new System.Drawing.Size(216, 27);
            this.textBoxDeryaUserName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "KategoryId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Şifre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Kullanıcı Adı";
            // 
            // textBoxDeryaUrl
            // 
            this.textBoxDeryaUrl.Location = new System.Drawing.Point(124, 135);
            this.textBoxDeryaUrl.Name = "textBoxDeryaUrl";
            this.textBoxDeryaUrl.Size = new System.Drawing.Size(216, 27);
            this.textBoxDeryaUrl.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Web Page";
            // 
            // textBoxCerenUrl
            // 
            this.textBoxCerenUrl.Location = new System.Drawing.Point(133, 133);
            this.textBoxCerenUrl.Name = "textBoxCerenUrl";
            this.textBoxCerenUrl.Size = new System.Drawing.Size(216, 27);
            this.textBoxCerenUrl.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Web Page";
            // 
            // FormProviderPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 319);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormProviderPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tedarikçi Şifreleri";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCerenCategory;
        private System.Windows.Forms.TextBox textBoxCerenPassword;
        private System.Windows.Forms.TextBox textBoxCerenUserName;
        private System.Windows.Forms.TextBox textBoxDeryaCategory;
        private System.Windows.Forms.TextBox textBoxDeryaPassword;
        private System.Windows.Forms.TextBox textBoxDeryaUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDeryaUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCerenUrl;
        private System.Windows.Forms.Label label8;
    }
}