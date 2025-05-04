using System.Net.Mail;
using System.Text.RegularExpressions;
using PackageCreator.Models;

namespace PackageCreator.Services;

public class InputCollector
{
    public static PackageInfo CollectPackageInfo()
    {
        var packageInfo = new PackageInfo();

        Console.WriteLine("Enter the base directory path for the package (leave empty for default):");
        var basePath = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(basePath))
        {
            basePath = WorkingDirectoryHelper.GetDefaultPackagesDirectory();
        }
        else if (!Directory.Exists(basePath))
        {
            Console.WriteLine("The provided path is invalid. Using default directory instead.");
            basePath = WorkingDirectoryHelper.GetDefaultPackagesDirectory();
        }

        Console.WriteLine($"Base Path: {basePath}");

        Console.Write("Enter store ID (optional, press Enter to skip): ");
        var storeIdInput = Console.ReadLine();
        packageInfo.StoreId = string.IsNullOrEmpty(storeIdInput) ? null : int.Parse(storeIdInput);

        while (true)
        {
            Console.Write("Enter package name (required): ");
            packageInfo.Name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(packageInfo.Name))
                break;
            Console.WriteLine("Package name cannot be empty.");
        }
        
        
        packageInfo.Name = InputCollector.CapitalizeFirstLetter(packageInfo.Name);

        Console.Write("Enter description (optional, press Enter to skip): ");
        packageInfo.Description = Console.ReadLine();

        Console.Write("Enter icon name (optional, press Enter to skip): ");
        packageInfo.Icon = Console.ReadLine();

        Console.Write("Enter preview image path (optional, press Enter to skip): ");
        packageInfo.PreviewImage = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter version (required): ");
            packageInfo.Version = Console.ReadLine();

            if (!Regex.IsMatch(packageInfo.Version, @"^\d+\.\d+\.\d+$"))
            {
                Console.WriteLine("Invalid version format. Expected format: X.Y.Z (e.g., 1.0.0)");
                continue;
            }


            if (!string.IsNullOrWhiteSpace(packageInfo.Version))
                break;
            Console.WriteLine("Version cannot be empty.");
        }

        while (true)
        {
            Console.Write("Enter minimum AWT version (required): ");
            packageInfo.MinimumAwtVersion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(packageInfo.MinimumAwtVersion))
                break;
            Console.WriteLine("Minimum AWT version cannot be empty.");
        }

        Console.Write("Enter maximum AWT version (optional, press Enter to skip): ");
        packageInfo.MaximumAwtVersion = Console.ReadLine();

        while (true)
        {
            Console.Write("Enter package type (1 for Plugin, 2 for Theme) (required): ");
            var packageTypeInput = Console.ReadLine();
            if (packageTypeInput == "1" || packageTypeInput == "2")
            {
                packageInfo.PackageType = packageTypeInput;
                break;
            }

            Console.WriteLine("Invalid package type. Please enter 1 or 2.");
        }

        Console.Write("Enter license info (optional, press Enter to skip): ");
        packageInfo.License = Console.ReadLine();

        Console.Write("Enter license URL (optional, press Enter to skip): ");
        packageInfo.LicenseUrl = Console.ReadLine();

        Console.Write("Enter author name (optional, press Enter to skip): ");
        packageInfo.Author = Console.ReadLine();

        while (true)
        {
            Console.Write("Is this a system package? (yes/no) (required): ");
            var systemPackageInput = Console.ReadLine()?.Trim().ToLower();
            if (systemPackageInput == "yes")
            {
                packageInfo.SystemPackage = true;
                break;
            }

            if (systemPackageInput == "no")
            {
                packageInfo.SystemPackage = false;
                break;
            }

            Console.WriteLine("Please enter 'yes' or 'no'.");
        }

        ShowSummary(packageInfo);

        Console.Write("Do you want to proceed with the package creation? (y/n): ");
        var confirmInput = Console.ReadLine()?.Trim().ToLower();

        if (confirmInput == "y" || confirmInput == "yes")
        {
            Console.WriteLine("Proceeding with package creation...");
            return packageInfo;
        }

        Console.WriteLine("Aborted. Please restart the process.");
        return null;
    }

    private static void ShowSummary(PackageInfo packageInfo)
    {
        Console.WriteLine("\n--- Package Information Summary ---");
        Console.WriteLine($"Package Name: {packageInfo.Name}");
        Console.WriteLine($"Description: {packageInfo.Description ?? "N/A"}");
        Console.WriteLine($"Icon Path: {packageInfo.Icon ?? "N/A"}");
        Console.WriteLine($"Preview Image Path: {packageInfo.PreviewImage ?? "N/A"}");
        Console.WriteLine($"Version: {packageInfo.Version}");
        Console.WriteLine($"Minimum AWT Version: {packageInfo.MinimumAwtVersion}");
        Console.WriteLine($"Maximum AWT Version: {packageInfo.MaximumAwtVersion ?? "N/A"}");
        Console.WriteLine($"Package Type: {(packageInfo.PackageType == "1" ? "Plugin" : "Theme")}");
        Console.WriteLine($"License: {packageInfo.License ?? "N/A"}");
        Console.WriteLine($"License URL: {packageInfo.LicenseUrl ?? "N/A"}");
        Console.WriteLine($"Author: {packageInfo.Author ?? "N/A"}");
        Console.WriteLine($"System Package: {(packageInfo.SystemPackage ? "Yes" : "No")}");
        Console.WriteLine("----------------------------------");
    }
    
    private static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1).ToLowerInvariant();
    }

}