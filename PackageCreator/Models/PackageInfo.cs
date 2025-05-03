namespace PackageCreator.Models
{
    public class PackageInfo
    {
        public int? StoreId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? PreviewImage { get; set; }
        public string? Version { get; set; }
        public string MinimumAwtVersion { get; set; }
        public string? MaximumAwtVersion { get; set; }
        public string PackageType { get; set; } // "Plugin" or "Theme"
        public string? License { get; set; }
        public string? LicenseUrl { get; set; }
        public string? Author { get; set; }
        public bool SystemPackage { get; set; }
    }
}