using System;
using System.IO;

namespace PackageCreator.Services
{
    public class DirectoryBuilder
    {
        public static void CreatePackageStructure(string basePath, string packageName)
        {
            string packagePath = Path.Combine(basePath, packageName);
            
            if (!Directory.Exists(packagePath))
            {
                Directory.CreateDirectory(packagePath);
                Console.WriteLine($"Created package directory at: {packagePath}");
            }
            
            CreateSubdirectories(packagePath);
            
            string iconDirectory = Path.Combine(packagePath, "data", "icon");
            Directory.CreateDirectory(iconDirectory);
            Console.WriteLine($"Created icon directory at: {iconDirectory}");
        }

        private static void CreateSubdirectories(string packagePath)
        {
            string[] subdirectories = new string[]
            {
                "routes", "controllers", "controllers/controller", "views", "views/assets/css", "views/assets/js", "views/assets/images", "views/templates"
            };

            foreach (var subdirectory in subdirectories)
            {
                string fullPath = Path.Combine(packagePath, subdirectory);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    Console.WriteLine($"Created subdirectory: {fullPath}");
                }
            }
        }
    }
}