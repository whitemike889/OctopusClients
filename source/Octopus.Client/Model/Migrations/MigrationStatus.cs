using System;

namespace Octopus.Client.Model.Migrations
{
    [AttributeUsage(AttributeTargets.Field)]
    sealed class FriendlyName : Attribute
    {
        public string Name { get; }

        public FriendlyName(string name)
        {
            Name = name;
        }
    }

    public enum MigrationStatus
    {
        [FriendlyName("Unknown")]
        Unknown,

        [FriendlyName("Export has started")]
        ExportStarted,

        [FriendlyName("Export has succeeded")]
        ExportSucceeded,

        [FriendlyName("Export has failed")]
        ExportFailed,

        [FriendlyName("Import has started")]
        ImportStarted,

        [FriendlyName("Import has succeeded")]
        ImportSucceeded,

        [FriendlyName("Import has failed")]
        ImportFailed,

        [FriendlyName("Complete")]
        Complete,
    }
}
