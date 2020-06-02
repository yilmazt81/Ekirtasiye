using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public class ShareFileHelper
    {
        public static string InstagramProductShare(IdeaCatalog ideaCatalog)
        {
            string filePath = Path.Combine(Application.StartupPath, "Files/InstagramShareProductComment.html");

            var templateStr = File.ReadAllText(filePath, Encoding.UTF8);


            return ReplaceTags(templateStr, ideaCatalog);
        }

        private static string ReplaceTags(string templateHtml, IdeaCatalog ideaCatalog)
        {
            string tags = string.Empty;
            templateHtml = templateHtml.Replace("@ProductName", HelperXmlRead.ConvertHtmlCodesToTurkish(string.IsNullOrEmpty(ideaCatalog.Title) ? ideaCatalog.Label : ideaCatalog.Title));
            templateHtml = templateHtml.Replace("@ProductLink", ideaCatalog.MyProductUrl);
            templateHtml = templateHtml.Replace("@ProductPrice", ideaCatalog.WebPrice + " TL");

            if (!string.IsNullOrEmpty(ideaCatalog.Brand))
            {
                tags += "#" +HelperXmlRead.ConvertHtmlCodesToTurkish(ideaCatalog.Brand).Replace(" ", "") + " ";
            }

            if (ideaCatalog.MainCategoryId != 0)
            {
                tags += "#" + ApiHelper.GetCategory(ideaCatalog.MainCategoryId).CategoryName.Replace(" ","") + " ";
            }

            if (ideaCatalog.SubCategoryId != 0)
            {
                tags += "#" + ApiHelper.GetCategory(ideaCatalog.SubCategoryId).CategoryName.Replace(" ", "") + " ";
            }
            if (ideaCatalog.CategoryId != 0)
            {
                tags += "#" + ApiHelper.GetCategory(ideaCatalog.CategoryId).CategoryName.Replace(" ", "") + " ";
            }

            templateHtml = templateHtml.Replace("@Tags", tags);


            return templateHtml;
        }
    }
}
