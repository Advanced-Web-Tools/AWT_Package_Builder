using Newtonsoft.Json;
using PackageCreator.Models;

namespace PackageCreator.Services;

public class ManifestGenerator
{
    public static void CreateManifest(string basePath, PackageInfo packageInfo)
    {
        var manifestPath = Path.Combine(basePath, packageInfo.Name, "manifest.json");

        var manifest = new
        {
            plugin = packageInfo.PackageType == "1"
                ? new
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
                    system = packageInfo.SystemPackage
                }
                : null,

            theme = packageInfo.PackageType == "2"
                ? new
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
                    system = packageInfo.SystemPackage
                }
                : null
        };


        var json = JsonConvert.SerializeObject(manifest, Formatting.Indented);
        File.WriteAllText(manifestPath, json);

        Console.WriteLine($"Manifest generated at: {manifestPath}");
    }
}