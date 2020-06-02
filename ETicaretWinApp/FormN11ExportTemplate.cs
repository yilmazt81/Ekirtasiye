using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.Model;
using EKirtasiye.N11;

namespace ETicaretWinApp
{
    public partial class FormN11ExportTemplate : Form
    {
        private N11ExportTemplate _exportTemplate = null;
        public FormN11ExportTemplate()
        {
            InitializeComponent();

            try
            {
                var _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
                var _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
                var shipment = new ShipmentHelper(_apiKey, _secretKey);
                var templateList = shipment.GetShipmentTemplateList();
                comboBoxDeliveryTemplate.DataSource = templateList;
            }
            catch (Exception exception)
            {
                FormMain.ShowException(exception);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        public N11ExportTemplate ExportTemplate {

            get {
                if (_exportTemplate == null)
                {
                    _exportTemplate = new N11ExportTemplate();
                }

                _exportTemplate.TemplateName = textBoxTemplateName.Text;
                _exportTemplate.CalculateType = comboBoxCalculateType.Text;
                _exportTemplate.CalculateValue = textBoxCalculateValue.Text;
                _exportTemplate.CargoDay = (int)numericUpDeliveryDay.Value;
                _exportTemplate.DeliveryTemplate = ((N11ShipmentTemplate)comboBoxDeliveryTemplate.SelectedValue).Name;
                _exportTemplate.EndDate = (dateTimePickerEndDate.Checked ? (DateTime?)dateTimePickerEndDate.Value : null);
                _exportTemplate.StartDate = (dateTimePickerStartDate.Checked ? (DateTime?)dateTimePickerStartDate.Value : null);
                _exportTemplate.SubText = textBoxSubText.Text;
                _exportTemplate.CalculatePriceType = comboBoxPriceType.Text;

                return _exportTemplate;

            }
            set {
                _exportTemplate = value;
                textBoxTemplateName.Text = _exportTemplate.TemplateName;
                comboBoxCalculateType.Text = _exportTemplate.CalculateType;
                textBoxCalculateValue.Text = _exportTemplate.CalculateValue;
                numericUpDeliveryDay.Value = _exportTemplate.CargoDay;
                // _exportTemplate.DeliveryTemplate = ((N11ShipmentTemplate)comboBoxDeliveryTemplate.SelectedValue).Name;
                dateTimePickerEndDate.Checked = (_exportTemplate.EndDate != null);
                dateTimePickerEndDate.Value = (_exportTemplate.EndDate != null ? _exportTemplate.EndDate.Value : DateTime.Now);

                dateTimePickerStartDate.Checked = (_exportTemplate.StartDate != null);
                dateTimePickerStartDate.Value = (_exportTemplate.StartDate != null ? _exportTemplate.StartDate.Value : DateTime.Now);
                textBoxSubText.Text = _exportTemplate.SubText;
                comboBoxPriceType.Text = _exportTemplate.CalculatePriceType;
            }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxTemplateName.Text))
            {
                MessageBox.Show("İsim Boş giremezsiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
