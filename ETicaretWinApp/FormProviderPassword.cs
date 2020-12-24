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
    public partial class FormProviderPassword : Form
    {
        public FormProviderPassword()
        {
            InitializeComponent();

            textBoxCerenUserName.Text = ApplicationSettingHelper.ReadValue("Ceren", "UserName");
            textBoxCerenPassword.Text = ApplicationSettingHelper.ReadValue("Ceren", "Password");
            textBoxCerenCategory.Text = ApplicationSettingHelper.ReadValue("Ceren", "Category");
            textBoxCerenUrl.Text = ApplicationSettingHelper.ReadValue("Ceren", "Url");


            textBoxDeryaUserName.Text = ApplicationSettingHelper.ReadValue("Derya", "UserName");
            textBoxDeryaPassword.Text = ApplicationSettingHelper.ReadValue("Derya", "Password");
            textBoxDeryaCategory.Text = ApplicationSettingHelper.ReadValue("Derya", "Category");
            textBoxDeryaUrl.Text = ApplicationSettingHelper.ReadValue("Derya", "Url");

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            ApplicationSettingHelper.AddValue("Ceren", "UserName", textBoxCerenUserName.Text);
            ApplicationSettingHelper.AddValue("Ceren", "Password", textBoxCerenPassword.Text);
            ApplicationSettingHelper.AddValue("Ceren", "Category", textBoxCerenCategory.Text);
            ApplicationSettingHelper.AddValue("Ceren", "Url", textBoxCerenUrl.Text);


            ApplicationSettingHelper.AddValue("Derya", "UserName", textBoxDeryaUserName.Text);
            ApplicationSettingHelper.AddValue("Derya", "Password", textBoxDeryaPassword.Text);
            ApplicationSettingHelper.AddValue("Derya", "Category", textBoxDeryaCategory.Text);
            ApplicationSettingHelper.AddValue("Derya", "Url", textBoxDeryaUrl.Text);

            DialogResult = DialogResult.OK;
        }
    }
}
