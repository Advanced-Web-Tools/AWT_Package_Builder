using PackageCreator.Services;

namespace PackageCreator;

public class PackageBuilder
{
    public static void BuildPackage()
    {
        var packageInfo = InputCollector.CollectPackageInfo();

        var defaultDirectory = WorkingDirectoryHelper.GetDefaultPackagesDirectory();
        var basePath = Path.Combine(defaultDirectory, packageInfo.Name);

        DirectoryBuilder.CreatePackageStructure(basePath, packageInfo.Name);

        ManifestGenerator.CreateManifest(basePath, packageInfo);

        PhpFileGenerator.CreatePhpFiles(basePath, packageInfo);

        Console.WriteLine("Package creation completed successfully!");

        var innerPackagePath = Path.Combine(basePath, packageInfo.Name);
        var zipOutputPath = Path.Combine(basePath, $"{packageInfo.Name}Package.zip");

        Console.Write("Do you want to create a zip archive of the package? (Y/n): ");
        var input = Console.ReadLine()?.Trim().ToLower() ?? "y";

        Console.WriteLine("Creating build environment.\n");
        
        ZipHelper.ExtractZip("./build_env/build_env.zip", basePath);
        
        FileWritingHelper.ReplaceLine($"{basePath}/build/runtime/constants.php", "define('NAME', '');",
            $"define('NAME', '{packageInfo.Name}');");

        Console.WriteLine("Build environment created successfully!");
    }
}