namespace Octopus.Client.Model.Migrations
{
    public class SpaceImportResource : Resource
    {
        public string PackageId { get; set; }
        public string PackageVersion { get; set; }
        public string Password { get; set; }
        public bool IsEncryptedPackage { get; set; }
        public bool IsDryRun { get; set; }
        public bool OverwriteExisting { get; set; }
        public string SuccessCallbackUri { get; set; }
        public string FailureCallbackUri { get; set; }
        public string TaskId { get; set; }
    }
}
