using System.Collections.Generic;

namespace Octopus.Client.Model.Migrations
{
    public class MigrationResource : Resource
    {
        public MigrationStatus Status { get; set; }
        public string SourceServerUri { get; set; }
        public string SourceApiKey { get; set; }
        public string SourceTaskId { get; set; }
        public string DestinationServerUri { get; set; }
        public string DestinationApiKey { get; set; }
        public string DestinationTaskId { get; set; }
        public string PackageId { get; set; }
        public string PackageVersion { get; set; }
        public string Password { get; set; }
        public List<string> ProjectNames { get; set; }
        public bool IgnoreCertificates { get; set; }
        public bool IgnoreMachines { get; set; }
        public bool IgnoreDeployments { get; set; }
        public bool IgnoreTenants { get; set; }
        public bool IncludeTaskLogs { get; set; }
        public bool IsDryRun { get; set; }
    }
}
