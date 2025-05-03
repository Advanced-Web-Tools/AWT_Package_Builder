using System;
using System.IO;
using System.IO.Compression;

namespace PackageCreator.Services
{
    public static class ZipHelper
    {
        public static void CreatePackageZip(string sourceFolderPath, string zipFilePath)
        {
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }

            ZipFile.CreateFromDirectory(sourceFolderPath, zipFilePath);
            Console.WriteLine($"Package successfully zipped: {zipFilePath}");
        }

    }
}