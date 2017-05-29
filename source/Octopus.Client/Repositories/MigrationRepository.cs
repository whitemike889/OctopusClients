using Octopus.Client.Model.Migrations;

namespace Octopus.Client.Repositories
{
    public interface IMigrationRepository
    {
        SpacePartialExportResource SpacePartialExport(SpacePartialExportResource resource);
        SpaceImportResource SpaceImport(SpaceImportResource resource);
    }

    class MigrationRepository : IMigrationRepository
    {
        readonly IOctopusClient client;

        public MigrationRepository(IOctopusClient client)
        {
            this.client = client;
        }

        public SpacePartialExportResource SpacePartialExport(SpacePartialExportResource resource)
        {
            return client.Create(client.RootDocument.Link("MigrationsSpacePartialExport"), resource);
        }

        public SpaceImportResource SpaceImport(SpaceImportResource resource)
        {
            return client.Create(client.RootDocument.Link("MigrationsSpaceImport"), resource);
        }
    }
}
