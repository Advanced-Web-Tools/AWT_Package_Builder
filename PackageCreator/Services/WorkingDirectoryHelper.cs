using System.Runtime.InteropServices;

namespace PackageCreator.Services;

public static class WorkingDirectoryHelper
{
    public static string GetDefaultPackagesDirectory()
    {
        var userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string documentsPath;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            documentsPath = Path.Combine(userHome, "Documents", "AWT", "Packages");
        else
            documentsPath = Path.Combine(userHome, "documents", "AWT", "Packages");

        if (!Directory.Exists(documentsPath))
        {
            Directory.CreateDirectory(documentsPath);
            Console.WriteLine($"Created default packages directory at: {documentsPath}");
        }

        return documentsPath;
    }
}