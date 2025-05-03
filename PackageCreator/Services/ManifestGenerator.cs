using System;
using System.IO;
using Newtonsoft.Json;
using PackageCreator.Models;

namespace PackageCreator.Services
{
    public class ManifestGenerator
    {
        public static void CreateManifest(string basePath, PackageInfo packageInfo)
        {
            string manifestPath = Path.Combine(basePath, packageInfo.Name, "manifest.json");

            var manifest = new
            {
                storeId = packageInfo.StoreId,
                name = packageInfo.Name,
                description = packageInfo.Description,
                icon = packageInfo.Icon,
                previewImage = packageInfo.PreviewImage,
                version = packageInfo.Version,
                minimumAwtVersion = packageInfo.MinimumAwtVersion,
                maximumAwtVersion = packageInfo.MaximumAwtVersion,
                packageType = packageInfo.PackageType,
                license = packageInfo.License,
                licenseUrl = packageInfo.LicenseUrl,
                author = packageInfo.Author,
                systemPackage = packageInfo.SystemPackage
            };
            
            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented);
            File.WriteAllText(manifestPath, json);

            Console.WriteLine($"Manifest generated at: {manifestPath}");
        }
    }
}