using EKirtasiye.Controls;
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
    public partial class FormShareIntegramView : Form
    {
        UImageEditor uImageEditor = null;
        IdeaCatalog _ideaCatalog = null;
        private int selectedTemplateId = 0;
          string iniFilePath = "";
        List<EKirtasiye.Model.InstagramUserFollowing> userFollowings = null;
        public FormShareIntegramView(IdeaCatalog ideaCatalog)
        {
            InitializeComponent();

            iniFilePath = Path.Combine(Application.StartupPath, "Setting.ini");
          
            _ideaCatalog = ideaCatalog;
            uImageEditor = new UImageEditor();
            splitContainerTop.Panel2.Controls.Add(uImageEditor);
            uImageEditor.Dock = DockStyle.Fill;
            StripComboBoxShareType.ComboBox.DataSource = ApiHelper.GetShareTypes();
            StripComboBoxShareType.SelectedIndex = int.Parse(ApplicationSettingHelper.ReadValue("InstagramShare", "SelectedShareType", "0"));
            numUpDownUser.Value = int.Parse(ApplicationSettingHelper.ReadValue("InstagramShare", "RandomUserCount", "10"));

            userFollowings = ApiHelper.GetInstagramUser();


        }

        private async void SendComment(string mediaId)
        {
            var shareText = textBoxComment.Text;

            var topicalExploreComment = await FormInstagramLogin.InstaApi.CommentProcessor.CommentMediaAsync(mediaId, shareText);
            if (!topicalExploreComment.Succeeded)
            {
                MessageBox.Show("Yorum gönderilemedi" + topicalExploreComment.Info.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private async void SharePicture(string[] lLocalImages)
        {

            try
            {
                if (lLocalImages.Length == 0)
                {
                    MessageBox.Show("Paylaşılacak Resim Yok ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                List<InstagramApiSharp.Classes.Models.InstaUserTagUpload> instaUserTagUploads = new List<InstagramApiSharp.Classes.Models.InstaUserTagUpload>();
                foreach (var userobj in checkedListBoxUserList.CheckedItems)
                {

                    var user = (EKirtasiye.Model.InstagramUserFollowing)userobj;
                    instaUserTagUploads.Add(new InstagramApiSharp.Classes.Models.InstaUserTagUpload()
                    {
                        Pk = long.Parse(user.UserPK),
                        Username = user.UserName
                    });
                }

                if (lLocalImages.Length == 1)
                {
                    var mediaImage = new InstagramApiSharp.Classes.Models.InstaImageUpload
                    {
                        Height = 0,
                        Width = 0,
                        Uri = lLocalImages.FirstOrDefault(),
                        UserTags = instaUserTagUploads
                    };


                    var resultUpload = await FormInstagramLogin.InstaApi.MediaProcessor.UploadPhotoAsync(mediaImage, _ideaCatalog.Title);

                    if (resultUpload.Succeeded)
                    {
                        SendComment(resultUpload.Value.Pk);
                    }
                    else
                    {
                        MessageBox.Show("Resim gönderilemedi" + resultUpload.Info.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    InstagramApiSharp.Classes.Models.InstaAlbumUpload[] mediaImageAlbum = lLocalImages.Select(s => new InstagramApiSharp.Classes.Models.InstaAlbumUpload()
                    {
                        ImageToUpload = new InstagramApiSharp.Classes.Models.InstaImageUpload()
                        {
                            Uri = s,
                            UserTags = instaUserTagUploads

                        }
                    }
                    ).ToArray();


                    var resultUpload = await FormInstagramLogin.InstaApi.MediaProcessor.UploadAlbumAsync(mediaImageAlbum, _ideaCatalog.Title);

                    if (resultUpload.Succeeded)
                    {
                        SendComment(resultUpload.Value.Pk);
                    }
                    else
                    {
                        MessageBox.Show("Resim gönderilemedi" + resultUpload.Info.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                foreach (var oneImage in lLocalImages)
                {
                    File.Delete(oneImage);
                }

                MessageBox.Show("Paylaşım Bitti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);

            }
        }

        private async void ShareStory(string[] lLocalImages)
        {
            try
            {
                if (lLocalImages.Length == 0)
                {
                    MessageBox.Show("Paylaşılacak Resim Yok ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                List<InstagramApiSharp.Classes.Models.InstaUserTagUpload> instaUserTagUploads = new List<InstagramApiSharp.Classes.Models.InstaUserTagUpload>();
                foreach (var userobj in checkedListBoxUserList.CheckedItems)
                {

                    var user = (EKirtasiye.Model.InstagramUserFollowing)userobj;
                    instaUserTagUploads.Add(new InstagramApiSharp.Classes.Models.InstaUserTagUpload()
                    {
                        Pk = long.Parse(user.UserPK),
                        Username = user.UserName
                    });
                }
                foreach (var oneImage in lLocalImages)
                {


                    var mediaImage = new InstagramApiSharp.Classes.Models.InstaImage
                    {
                        Height = 0,
                        Width = 0,
                        Uri = oneImage

                    };

                    InstagramApiSharp.Classes.Models.InstaStoryUploadOptions storyUploadOptions = new InstagramApiSharp.Classes.Models.InstaStoryUploadOptions();


                    var resultUpload = await FormInstagramLogin.InstaApi.StoryProcessor.UploadStoryPhotoWithUrlAsync(mediaImage, _ideaCatalog.Title, new Uri(_ideaCatalog.MyProductUrl), storyUploadOptions);

                    if (resultUpload.Succeeded)
                    {
                        SendComment(resultUpload.Value.Media.Pk.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Resim gönderilemedi" + resultUpload.Info.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                foreach (var oneImage in lLocalImages)
                {
                    File.Delete(oneImage);
                }

                MessageBox.Show("Paylaşım Bitti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);

            }
        }

        private void FormShareIntegramView_Load(object sender, EventArgs e)
        {

            try
            {

                /*
                 iniFile.AddValue("InstagramShare", "TemplateFile", formSelectTemplate.SelectedTemplateAnnotation);
                iniFile.AddValue("InstagramShare", "BackGroundFile", formSelectTemplate.SelectedTemplateImage);

                iniFile.AddValue("InstagramShare", "SelectedShareTemplateId", formSelectTemplate.SelectedShareTemplateId.ToString());
                 */
                
                var backGroup = ApplicationSettingHelper.ReadValue("InstagramShare", "BackGroundFile", Path.Combine(Application.StartupPath, @"Files\Empty.png"));
                selectedTemplateId = int.Parse(ApplicationSettingHelper.ReadValue("InstagramShare", "SelectedShareTemplateId", "0"));
                if (File.Exists(backGroup))
                {
                    uImageEditor.LoadImage(backGroup);
                }
                else
                {
                    backGroup = Path.Combine(Application.StartupPath, @"Files\Empty.png");
                    uImageEditor.LoadImage(backGroup);
                }

                uImageEditor.Zoom(ViewerHelper.ZoomType.BestFit);
                textBoxComment.Text = ShareFileHelper.InstagramProductShare(_ideaCatalog);
                var TemplateFile = ApplicationSettingHelper.ReadValue("InstagramShare", "TemplateFile");
                if (!string.IsNullOrEmpty(TemplateFile))
                {
                    if (File.Exists(TemplateFile))
                    {
                        uImageEditor.LoadSaveAnnotation(TemplateFile);
                    }
                }

                if (!string.IsNullOrEmpty(_ideaCatalog.Picture1Path))
                {

                    uProductPicturesThumnail.AddPicture(_ideaCatalog.Id, _ideaCatalog.Picture1Path);
                }
                else
                {
                    _ideaCatalog.Picture1Path = "";

                }

                if (!string.IsNullOrEmpty(_ideaCatalog.Picture2Path))
                {
                    uProductPicturesThumnail.AddPicture(_ideaCatalog.Id, _ideaCatalog.Picture2Path);
                }
                else
                {
                    _ideaCatalog.Picture2Path = "";

                }
                if (!string.IsNullOrEmpty(_ideaCatalog.Picture3Path))
                {
                    uProductPicturesThumnail.AddPicture(_ideaCatalog.Id, _ideaCatalog.Picture3Path);
                }
                else
                {
                    _ideaCatalog.Picture3Path = "";
                }
                if (!string.IsNullOrEmpty(_ideaCatalog.Picture4Path))
                {
                    uProductPicturesThumnail.AddPicture(_ideaCatalog.Id, _ideaCatalog.Picture4Path);
                }
                else
                {
                    _ideaCatalog.Picture4Path = "";
                }
                SetViewAnnotationsImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void StripButtonSaveAnnotation_Click(object sender, EventArgs e)
        {
            var template = ApiHelper.GetShareTemplate(selectedTemplateId);

            if (!string.IsNullOrEmpty(uImageEditor.TemplateFilePath))
            {
                uImageEditor.SaveAnnotation(uImageEditor.TemplateFilePath);
                var tempFile = uImageEditor.SaveAnnotationItemsImages(uProductPicturesThumnail.ProductPicturesLocal);
                var oneTempFile = tempFile.FirstOrDefault();
                template.SampleFileName = template.Id.ToString() + "SampleFile.jpg";

                File.Copy(oneTempFile, Path.Combine(System.Configuration.ConfigurationManager.AppSettings["LocalWorkFolder"], "ShareTemplate", template.Id.ToString() + Path.GetExtension(template.FileName)), true);


                try
                {
                    FTPHelper.UploadFile(oneTempFile, System.Configuration.ConfigurationManager.AppSettings["FTPTemplateFolder"] + template.SampleFileName);
                }
                catch
                {


                }
                foreach (var oneFile in tempFile)
                {
                    File.Delete(oneFile);
                }

            }

            string tempAnnotationFile = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["LocalWorkFolder"], "ShareTemplate", this.selectedTemplateId + ".Xmp");

            uImageEditor.SaveAnnotation(tempAnnotationFile);

            try
            {

                template.AnnotationFile = Path.ChangeExtension(template.FileName, ".Xmp");
                FTPHelper.UploadFile(uImageEditor.TemplateFilePath, System.Configuration.ConfigurationManager.AppSettings["FTPTemplateFolder"] + template.AnnotationFile);
                ApiHelper.SaveShareTypesTemplate(template);

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
            finally
            {
                ApplicationSettingHelper.AddValue("InstagramShare", "TemplateFile", uImageEditor.TemplateFilePath);
               
            }
        }

        private void StripButtonOpenTemplate_Click(object sender, EventArgs e)
        {

            var shareType = (ShareType)StripComboBoxShareType.SelectedItem;
            FormSelectTemplate formSelectTemplate = new FormSelectTemplate(shareType);

            if (formSelectTemplate.ShowDialog() == DialogResult.OK)
            {

                uImageEditor.LoadImage(formSelectTemplate.SelectedTemplateImage);
                if (!string.IsNullOrEmpty(formSelectTemplate.SelectedTemplateAnnotation))
                {
                    uImageEditor.LoadSaveAnnotation(formSelectTemplate.SelectedTemplateAnnotation);
                }
                SetViewAnnotationsImage();
                ApplicationSettingHelper.AddValue("InstagramShare", "TemplateFile", formSelectTemplate.SelectedTemplateAnnotation);
                ApplicationSettingHelper.AddValue("InstagramShare", "BackGroundFile", formSelectTemplate.SelectedTemplateImage);

                ApplicationSettingHelper.AddValue("InstagramShare", "SelectedShareTemplateId", formSelectTemplate.SelectedShareTemplateId.ToString());
                this.selectedTemplateId = formSelectTemplate.SelectedShareTemplateId;
                 
            }


        }

        private void LoginUser()
        {
            if (FormInstagramLogin.InstaApi == null)
            {
                FormInstagramLogin formInstagramLogin = new FormInstagramLogin();

                if (formInstagramLogin.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
            }

        }
        private void StripButtonSendInstegram_Click(object sender, EventArgs e)
        {
            LoginUser();
            var shareType = (ShareType)StripComboBoxShareType.SelectedItem;

            var returnImages = uImageEditor.SaveAnnotationItemsImages(uProductPicturesThumnail.ProductPicturesLocal);

            if (shareType.SosialMediaName == "Instagram")
            {
                SharePicture(returnImages);

            }
            else if (shareType.SosialMediaName == "InstagramStory")
            {
                ShareStory(returnImages);
            }



        }

        private void uProductPicturesThumnail_OnSelectedImage(string imagePath)
        {
            uImageEditor.ProductImage = imagePath;
            uImageEditor.SetAnnotationValue("@ProductImage", imagePath);
            SetViewAnnotationsImage();


        }

        private void SetViewAnnotationsImage()
        {
            uImageEditor.SetAnnotationValue("@ProductName", HelperXmlRead.ConvertHtmlCodesToTurkish((string.IsNullOrEmpty(_ideaCatalog.Title) ? _ideaCatalog.Label : _ideaCatalog.Title)));
            uImageEditor.SetAnnotationValue("@ProductPrice", _ideaCatalog.WebPrice + " " + _ideaCatalog.CurrencyAbbr);
            uImageEditor.SetAnnotationValue("@ProductBrand", HelperXmlRead.ConvertHtmlCodesToTurkish(_ideaCatalog.Brand));
            uImageEditor.SetAnnotationValue("@ProductDiscount", (_ideaCatalog.RebatePercent == 0 ? string.Empty : _ideaCatalog.RebatePercent.ToString()));

        }

        private void StripButtonOpenBackGroup_Click(object sender, EventArgs e)
        {
            /* OpenFileDialog openFileDialog = new OpenFileDialog();
             openFileDialog.Filter = "Jpg Dosyası|*.jpg|png Dosyası|*.png";

             if (openFileDialog.ShowDialog() == DialogResult.OK)
             {
                 iniFile.AddValue("InstagramShare", "BackGroundFile", openFileDialog.FileName);
                 iniFile.Save(iniFilePath);

                 uImageEditor.LoadImage(openFileDialog.FileName);
             }*/
        }
        private void StripComboBoxShareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var shareType = (ShareType)StripComboBoxShareType.SelectedItem;
            ApplicationSettingHelper.AddValue("InstagramShare", "SelectedShareType", StripComboBoxShareType.SelectedIndex.ToString());
          

        }

        private void FormShareIntegramView_FormClosed(object sender, FormClosedEventArgs e)
        {
            uProductPicturesThumnail.ClearImages();
        }

        private void buttonRandome_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random(5);
                ApplicationSettingHelper.AddValue("InstagramShare", "RandomUserCount", numUpDownUser.Value.ToString());
                

                for (int i = 0; i < numUpDownUser.Value; i++)
                {
                    var randomIndex = random.Next(0, userFollowings.Count);
                    var user = userFollowings[randomIndex];
                    checkedListBoxUserList.Items.Add(user, true);
                }
            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }

        }
    }
}
