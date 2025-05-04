using System.IO.Compression;

namespace PackageCreator.Services;

public static class ZipHelper
{
    public static void CreatePackageZip(string sourceFolderPath, string zipFilePath)
    {
        if (File.Exists(zipFilePath)) File.Delete(zipFilePath);

        ZipFile.CreateFromDirectory(sourceFolderPath, zipFilePath);
        Console.WriteLine($"Package successfully zipped: {zipFilePath}");
    }

    public static void ExtractZip(string zipFilePath, string destinationPath)
    {
        if (!File.Exists(zipFilePath))
        {
            Console.WriteLine($"Zip file not found: {zipFilePath}");
            return;
        }

        using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
        {
            foreach (var entry in archive.Entries)
            {
                string fullPath = Path.Combine(destinationPath, entry.FullName);

                if (string.IsNullOrEmpty(entry.Name))
                {
                    Directory.CreateDirectory(fullPath);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath)); // Ensure directory exists
                    using (var entryStream = entry.Open())
                    using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        entryStream.CopyTo(fileStream);
                    }
                }
            }
        }

        Console.WriteLine($"Zip file extracted: {zipFilePath}");
    }

}