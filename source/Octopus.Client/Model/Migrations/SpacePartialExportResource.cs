using System.Collections.Generic;

namespace Octopus.Client.Model.Migrations
{
    public class SpacePartialExportResource : Resource
    {
        [Writeable]
        public string PackageId { get; set; }
        [Writeable]
        public string PackageVersion { get; set; }
        [Writeable]
        public string Password { get; set; }
        [Writeable]
        public List<string> Projects { get; set; }
        [Writeable]
        public bool IncludeApiKeys { get; set; }
        [Writeable]
        public bool IncludeCertificates { get; set; }
        [Writeable]
        public bool IncludeCertificateConfigurations { get; set; }
        [Writeable]
        public bool IncludeEvents { get; set; }
        [Writeable]
        public bool IncludeLicense { get; set; }
        [Writeable]
        public bool IncludeMachines { get; set; }
        [Writeable]
        public bool IncludeReleases { get; set; }
        [Writeable]
        public bool IncludeSmtpConfiguration { get; set; }
        [Writeable]
        public bool IncludeSubscriptions { get; set; }
        [Writeable]
        public bool IncludeTaskLogs { get; set; }
        [Writeable]
        public bool IncludeTeams { get; set; }
        [Writeable]
        public bool IncludeTenants { get; set; }
        [Writeable]
        public bool IncludeUsers { get; set; }
        [Writeable]
        public bool IncludeUserRoles { get; set; }
        [Writeable]
        public bool EncryptPackage { get; set; }
        [Writeable]
        public string DestinationApiKey { get; set; }
        [Writeable]
        public string DestinationPackageFeed { get; set; }
        [Writeable]
        public string SuccessCallbackUri { get; set; }
        [Writeable]
        public string FailureCallbackUri { get; set; }
        public string TaskId { get; set; }
    }
}
