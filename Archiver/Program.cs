using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace Archiver
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("D://Project/PRO100/Desktop/bin/Release/release.zip"))
            {
                File.Delete("D://Project/PRO100/Desktop/bin/Release/release.zip");
            }

            var sourceFolder = "D://Project/PRO100/Desktop/bin/Release/net5.0-windows";
            var zipFile = "D://Project/PRO100/Desktop/bin/Release/release.zip";

            ZipFile.CreateFromDirectory(sourceFolder, zipFile, CompressionLevel.Fastest, false);


            //
            FileInfo fileInf = new FileInfo("D://Project/PRO100/Desktop/bin/Release/net5.0-windows/PRO100.exe");
            if (fileInf.Exists)
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo("D://Project/PRO100/Desktop/bin/Release/net5.0-windows/PRO100.exe");
                var update = $"D://Project/PRO100/WebAPI/bin/Release/net5.0/publish/App_Data/Updates/{info.ProductVersion}.zip";

                if (File.Exists($"D://Project/PRO100/WebAPI/bin/Release/net5.0/publish/App_Data/Updates/{info.ProductVersion}.zip"))
                {
                    File.Delete($"D://Project/PRO100/WebAPI/bin/Release/net5.0/publish/App_Data/Updates/{info.ProductVersion}.zip");
                }

                ZipFile.CreateFromDirectory(sourceFolder, update, CompressionLevel.Fastest, false);
            }
        }
    }
}
