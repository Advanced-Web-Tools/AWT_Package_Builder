using PackageCreator.Models;

namespace PackageCreator.Services;

public class PhpFileGenerator
{
    public static void CreatePhpFiles(string basePath, PackageInfo packageInfo)
    {
        // Create main.php
        var mainPhpPath = Path.Combine(basePath, packageInfo.Name, "main.php");
        var mainPhpContent = GenerateMainPhpContent(packageInfo.Name);
        File.WriteAllText(mainPhpPath, mainPhpContent);
        Console.WriteLine($"Created main.php at: {mainPhpPath}");

        // Create install.php
        var installPhpPath = Path.Combine(basePath, packageInfo.Name, "install.php");
        var installPhpContent = GenerateInstallPhpContent(packageInfo.Name);
        File.WriteAllText(installPhpPath, installPhpContent);
        Console.WriteLine($"Created install.php at: {installPhpPath}");

        // Create Router file
        var routerPath = Path.Combine(basePath, packageInfo.Name, "routes", $"{packageInfo.Name}Router.php");
        var routerContent = GenerateRouterContent(packageInfo.Name);
        File.WriteAllText(routerPath, routerContent);
        Console.WriteLine($"Created {packageInfo.Name}Router.php at: {routerPath}");

        // Create ControllerAPI file
        var controllerApiPath =
            Path.Combine(basePath, packageInfo.Name, "controllers", $"{packageInfo.Name}ControllerAPI.php");
        var controllerApiContent = GenerateControllerApiContent(packageInfo.Name);
        File.WriteAllText(controllerApiPath, controllerApiContent);
        Console.WriteLine($"Created {packageInfo.Name}ControllerAPI.php at: {controllerApiPath}");

        // Create Controller file
        var controllerPath = Path.Combine(basePath, packageInfo.Name, "controllers", "controller",
            $"{packageInfo.Name}Controller.php");
        var controllerContent = GenerateControllerContent(packageInfo.Name);
        File.WriteAllText(controllerPath, controllerContent);
        Console.WriteLine($"Created {packageInfo.Name}Controller.php at: {controllerPath}");
    }

    private static string GenerateMainPhpContent(string name)
    {
        return $@"<?php

use packages\runtime\api\RuntimeLinkerAPI;
use packages\runtime\handler\enums\ERuntimeFlags;

final class {name} extends RuntimeLinkerAPI
{{
    public function setup(): void
    {{
        // Setup logic here
    }}

    public function main(): void
    {{
        // Main logic here
    }}
}}";
    }

    private static string GenerateInstallPhpContent(string name)
    {
        return $@"<?php

use database\creator\ColumnCreator;
use database\creator\TableWizard;
use packages\installer\interface\IPackageInstall;

class {name}Install implements IPackageInstall
{{
    private TableWizard $dbWizard;
    private ColumnCreator $columnCreator;

    public function postInstall(int $packageID, string $packageName): bool
    {{
        // Post install logic here
        return true;
    }}
}}";
    }

    private static string GenerateRouterContent(string name)
    {
        return $@"<?php

use packages\runtime\api\RuntimeRouterAPI;
use router\Router;

final class {name}Router extends RuntimeRouterAPI
{{
    public function setup(): void
    {{
        // Setup logic here
    }}

    public function main(): void
    {{
        // Main logic here
    }}
}}";
    }

    private static string GenerateControllerApiContent(string name)
    {
        return $@"<?php

use controller\Controller;
use packages\runtime\api\RuntimeControllerAPI;

final class {name}ControllerAPI extends RuntimeControllerAPI
{{
    public function setup(): void
    {{
        // Setup logic here
    }}

    public function main(): void
    {{
        // Main logic here
    }}
}}";
    }

    private static string GenerateControllerContent(string name)
    {
        return $@"<?php

use controller\Controller;
use view\View;

class {name}Controller extends Controller
{{
    public function index(array|string $params): View
    {{
        return $this->view($params);
    }}
}}";
    }
}