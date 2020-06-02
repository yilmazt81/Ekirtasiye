using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp
{
    class FTPHelper
    {
        static FtpClient ftpClient = null;

        static FTPHelper()
        {
            ftpClient = new FtpClient(System.Configuration.ConfigurationManager.AppSettings["FTPAdress"]);
            ftpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = System.Configuration.ConfigurationManager.AppSettings["FTPUserName"],
                Password = System.Configuration.ConfigurationManager.AppSettings["FTPPassword"]
            };
        }

        private static void CheckConnection()
        {
            if (!ftpClient.IsConnected)
            {
                ftpClient.Connect();
            }
        }
        public static bool UploadFile(string filePath, string targetFilePath)
        {
            // string targetFilePath = targetFolder + "/" + Path.GetFileName(filePath);

            CheckConnection();
            bool sendFile = ftpClient.Upload(File.ReadAllBytes(filePath), targetFilePath);


            return sendFile;
        }

        public static bool IsExistFile(string filePath)
        {
            CheckConnection();
            return ftpClient.FileExists(filePath);

        }
        public static bool DownloadFile(string filePath, string remotePath)
        {
            CheckConnection();
            byte[] outBytes = null;
            bool download = ftpClient.Download(out outBytes, remotePath);
            File.WriteAllBytes(filePath, outBytes);

            return download;
        }
    }
}
