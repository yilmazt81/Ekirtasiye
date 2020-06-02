using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public partial class FormSelectTemplate : Form
    {
        ShareType _shareType = null;
        private string _templateFolder, localWorkFolder, selectedTemplateImage, selectedTemplateAnnotation = string.Empty;
        public FormSelectTemplate(ShareType shareType)
        {
            InitializeComponent();
            _shareType = shareType;
            this.Text = shareType.Name + " Templateleri";
            _templateFolder = System.Configuration.ConfigurationManager.AppSettings["FTPTemplateFolder"];
            uProductPicturesTemplate.OnSelectedImage += UProductPicturesTemplate_OnSelectedImage;
            localWorkFolder = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["LocalWorkFolder"], "ShareTemplate");

            labelImageSize.Text= $"Image Boyutu :  {_shareType.ShareSize.With} x {_shareType.ShareSize.Heigth} ";
            RefreshGrid();
        }

        public string SelectedTemplateImage {
            get {
                return selectedTemplateImage;
            }
        }

        public int SelectedShareTemplateId { get; set; }

        public string SelectedTemplateAnnotation {
            get {
                return selectedTemplateAnnotation;
            }
        }
        private void UProductPicturesTemplate_OnSelectedImage(string imagePath)
        {
            pictureBoxSelected.Image = Image.FromFile(imagePath);
            pictureBoxSelected.SizeMode = PictureBoxSizeMode.Zoom;
            var templateId = Path.GetFileNameWithoutExtension(imagePath).Replace("_Empty", "");
            SelectedShareTemplateId = int.Parse(templateId);
            selectedTemplateImage = Path.Combine(localWorkFolder, templateId + "_Empty" + Path.GetExtension(imagePath));

            string tmpAnnotationFile = Path.Combine(localWorkFolder, templateId + ".Xmp");
            if (File.Exists(tmpAnnotationFile))
            {
                selectedTemplateAnnotation = tmpAnnotationFile;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (SelectedShareTemplateId == 0)
            {
                MessageBox.Show("Template Seçilmedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void FormSelectTemplate_Load(object sender, EventArgs e)
        {

        }

        private void FormSelectTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            uProductPicturesTemplate.ClearImages();
            pictureBoxSelected.Image = null;
        }

        private void RefreshGrid()
        {
            var templateList = ApiHelper.GetShareTemplates(_shareType.Id);
            uProductPicturesTemplate.ClearImages();
            ;
            if (!Directory.Exists(localWorkFolder))
                Directory.CreateDirectory(localWorkFolder);
            var shareTemplates = ApiHelper.GetAllTemplates();

            string remoteFolder = System.Configuration.ConfigurationManager.AppSettings["FTPTemplateFolder"];
            foreach (var oneTemplate in shareTemplates)
            {
                string localTempFile = Path.Combine(localWorkFolder, oneTemplate.Id.ToString() + Path.GetExtension(oneTemplate.FileName));
                FileInfo fileInfo = new FileInfo(localTempFile);

                if (!fileInfo.Exists || (fileInfo.LastWriteTime < oneTemplate.LastUpdateDate && !string.IsNullOrEmpty(oneTemplate.SampleFileName)))
                {
                    FTPHelper.DownloadFile(localTempFile, remoteFolder + (!string.IsNullOrEmpty(oneTemplate.SampleFileName) ? oneTemplate.SampleFileName : oneTemplate.FileName));
                }
                string localTempEmptyFile = Path.Combine(localWorkFolder, oneTemplate.Id.ToString() + "_Empty" + Path.GetExtension(oneTemplate.FileName));
                FileInfo fileInfoEmp = new FileInfo(localTempEmptyFile);
                if (!fileInfoEmp.Exists)
                {
                    FTPHelper.DownloadFile(localTempEmptyFile, remoteFolder + oneTemplate.FileName);
                }
                string localAnnotationFile = Path.Combine(localWorkFolder, oneTemplate.Id.ToString() + ".Xmp");
                FileInfo fileInfoAnnotate = new FileInfo(localAnnotationFile);
                if ((!fileInfoAnnotate.Exists && !string.IsNullOrEmpty(oneTemplate.AnnotationFile)) ||
                     (!string.IsNullOrEmpty(oneTemplate.AnnotationFile) && (fileInfoAnnotate.LastWriteTime < oneTemplate.LastUpdateDate)))
                {
                    FTPHelper.DownloadFile(fileInfoAnnotate.FullName, remoteFolder + oneTemplate.AnnotationFile);
                }
            }

            foreach (var oneTemplate in templateList.OrderByDescending(s => s.Id))
            {
                string templateFileName = string.Empty;

                templateFileName = string.IsNullOrEmpty(oneTemplate.SampleFileName)
                    ? _templateFolder + oneTemplate.FileName
                    : _templateFolder + oneTemplate.SampleFileName;
                string localTempFile = Path.Combine(localWorkFolder, oneTemplate.Id.ToString() + Path.GetExtension(oneTemplate.FileName));
                string localTempEmptyFile = Path.Combine(localWorkFolder, oneTemplate.Id.ToString() + "_Empty" + Path.GetExtension(oneTemplate.FileName));
                string localAnnotationFile = Path.Combine(localWorkFolder, oneTemplate.Id.ToString() + ".Xmp");

                uProductPicturesTemplate.AddPicture(0, localTempFile);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void buttonUploadTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Jpg Files|*.jpg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Image image = Image.FromFile(openFileDialog.FileName))
                    {
                        if ((_shareType.ShareSize.With != image.Width) || (_shareType.ShareSize.Heigth != image.Height))
                        {
                            MessageBox.Show($"Seçtiğiniz image {_shareType.ShareSize.With} x {_shareType.ShareSize.Heigth} olmalıdır ","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            return;
                        }

                    }
                    ShareTypesTemplate shareTypesTemplate = new ShareTypesTemplate()
                    {
                        FileName = Guid.NewGuid().ToString("N") + Path.GetExtension(openFileDialog.FileName),
                        ShareTypeId = _shareType.Id
                    };

                    if (!FTPHelper.UploadFile(openFileDialog.FileName, _templateFolder + shareTypesTemplate.FileName))
                    {
                        MessageBox.Show("Dosya Yüklenemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ApiHelper.SaveShareTypesTemplate(shareTypesTemplate);
                    File.Copy(openFileDialog.FileName, Path.Combine(System.Configuration.ConfigurationManager.AppSettings["LocalWorkFolder"], "ShareTemplate", shareTypesTemplate.Id.ToString() + Path.GetExtension(shareTypesTemplate.FileName)));

                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }
    }
}
