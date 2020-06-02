using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Helper
{
    public class PDFHelper
    {
        private static int NumberOfPages(string inputFile)
        {
            int pageCount = 0;
            using (PdfReader inputPdf = new PdfReader(inputFile))
            {
                pageCount = inputPdf.NumberOfPages;
            }

            return pageCount;


        }
        public static void ExtractPages(string inputFile, string outputFolder)
        {
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            using (PdfReader reader = new PdfReader(inputFile))
            {

                for (int pagenumber = 1; pagenumber <= reader.NumberOfPages; pagenumber++)
                {
                    string filename = System.IO.Path.GetFileNameWithoutExtension(inputFile) + "_" + pagenumber.ToString().PadLeft(6, '0') + ".pdf";

                    Document document = new Document();
                    PdfCopy copy = new PdfCopy(document, new FileStream(outputFolder + "\\" + filename, FileMode.Create));

                    document.Open();

                    copy.AddPage(copy.GetImportedPage(reader, pagenumber));

                    document.Close();
                }
            }

        }

        public static string ConverPDFToTif(string filename)
        {
            try
            {

                PDFConvert converter = new PDFConvert();
                bool Converted = false;

                converter.OutputToMultipleFile = false;
                converter.FirstPageToConvert = -1;
                converter.LastPageToConvert = -1;

                converter.FitPage = true;
                converter.JPEGQuality = 100;
                converter.ResolutionX = 300;
                converter.ResolutionY = 300;
                converter.OutputFormat = "tiffscaled32";

                //converter.OutputFormat = "tifflzw";

                System.IO.FileInfo input = new FileInfo(filename);
                string output = string.Format("{0}\\{1}{2}", input.Directory, input.Name, ".tif");
                //If the output file exist alrady be sure to add a random name at the end until is unique!
                if (File.Exists(output))
                    File.Delete(output);

                Converted = converter.Convert(input.FullName, output);

                if (!Converted)
                {
                    throw new Exception("Convert Exception");
                }
            
                return output;
             

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string GetTextFromAllPages(String pdfPath)
        {
            PdfReader reader = new PdfReader(pdfPath);

            StringWriter output = new StringWriter();

            for (int i = 1; i <= reader.NumberOfPages; i++)
                output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy()));
            reader.Close();
            return output.ToString();
        }




    }
}
