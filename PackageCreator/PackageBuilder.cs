using System;
using PackageCreator.Models;
using PackageCreator.Services;

namespace PackageCreator
{
    public class PackageBuilder
    {
        public static void BuildPackage()
        {
            PackageInfo packageInfo = InputCollector.CollectPackageInfo();
            
            string defaultDirectory = WorkingDirectoryHelper.GetDefaultPackagesDirectory();
            string basePath = Path.Combine(defaultDirectory, packageInfo.Name);
            
            DirectoryBuilder.CreatePackageStructure(basePath, packageInfo.Name);
            
            ManifestGenerator.CreateManifest(basePath, packageInfo);
            
            PhpFileGenerator.CreatePhpFiles(basePath, packageInfo);

            Console.WriteLine("Package creation completed successfully!");
            
            string innerPackagePath = Path.Combine(basePath, packageInfo.Name);
            string zipOutputPath = Path.Combine(basePath, $"{packageInfo.Name}Package.zip");

            Console.Write("Do you want to create a zip archive of the package? (Y/n): ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "y";

            if (input == "y" || input == "yes" || input == "")
            {
                ZipHelper.CreatePackageZip(innerPackagePath, zipOutputPath);
            }
        }
    }
}