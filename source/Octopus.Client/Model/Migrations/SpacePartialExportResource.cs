using System.Collections.Generic;

namespace Octopus.Client.Model.Migrations
{
    public class SpacePartialExportResource : Resource
    {
        public string PackageIdentifier { get; set; }
        public string Password { get; set; }
        public List<string> Projects { get; set; }
        public bool IncludeApiKeys { get; set; }
        public bool IncludeCertificates { get; set; }
        public bool IncludeCertificateConfigurations { get; set; }
        public bool IncludeEvents { get; set; }
        public bool IncludeLicense { get; set; }
        public bool IncludeMachines { get; set; }
        public bool IncludeReleases { get; set; }
        public bool IncludeSmtpConfiguration { get; set; }
        public bool IncludeSubscriptions { get; set; }
        public bool IncludeTaskLogs { get; set; }
        public bool IncludeTeams { get; set; }
        public bool IncludeTenants { get; set; }
        public bool IncludeUsers { get; set; }
        public bool IncludeUserRoles { get; set; }
        public bool EncryptPackage { get; set; }
        public string DestinationApiKey { get; set; }
        public string DestinationPackageFeed { get; set; }
        public string SuccessCallbackUri { get; set; }
        public string FailureCallbackUri { get; set; }
        public string TaskId { get; set; }
    }
}
