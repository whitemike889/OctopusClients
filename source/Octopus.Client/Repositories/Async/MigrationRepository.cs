using System.Threading.Tasks;
using Octopus.Client.Model.Migrations;

namespace Octopus.Client.Repositories.Async
{
    public interface IMigrationRepository
    {
        Task<SpacePartialExportResource> SpacePartialExport(SpacePartialExportResource resource);
        Task<SpaceImportResource> SpaceImport(SpaceImportResource resource);
    }

    class MigrationRepository : IMigrationRepository
    {
        readonly IOctopusAsyncClient client;

        public MigrationRepository(IOctopusAsyncClient client)
        {
            this.client = client;
        }

        public async Task<SpacePartialExportResource> SpacePartialExport(SpacePartialExportResource resource)
        {
            return await client.Create(client.RootDocument.Link("MigrationsSpacePartialExport"), resource).ConfigureAwait(false);
        }

        public async Task<SpaceImportResource> SpaceImport(SpaceImportResource resource)
        {
            return await client.Create(client.RootDocument.Link("MigrationsSpaceImport"), resource).ConfigureAwait(false);
        }
    }
}
