namespace ETicaretWinApp
{
    partial class UGroupNameMatchs
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBoxGroupName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Adi";
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Location = new System.Drawing.Point(93, 14);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.ReadOnly = true;
            this.textBoxGroupName.Size = new System.Drawing.Size(244, 20);
            this.textBoxGroupName.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBoxGroupName
            // 
            this.comboBoxGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroupName.FormattingEnabled = true;
            this.comboBoxGroupName.Location = new System.Drawing.Point(378, 11);
            this.comboBoxGroupName.Name = "comboBoxGroupName";
            this.comboBoxGroupName.Size = new System.Drawing.Size(307, 21);
            this.comboBoxGroupName.TabIndex = 3;
            // 
            // UGroupNameMatchs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxGroupName);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.label1);
            this.Name = "UGroupNameMatchs";
            this.Size = new System.Drawing.Size(710, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox comboBoxGroupName;
    }
}
