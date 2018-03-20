using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyBridgeProject
{
    class Utils
    {
        public static void UnzipArchive(string zipFilePath, string password)
        {
            ZipFile zipFile = ZipFile.Read(zipFilePath);
            zipFile.Password = password;
                 foreach (ZipEntry zipEntry in zipFile)
                {
                    string tempOutputDirectory = ".\\TempOutputDirectory";
                    zipEntry.Extract(tempOutputDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
        }

    }
}
