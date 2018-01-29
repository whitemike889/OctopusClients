using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Octopus.Client.Model;

namespace Octopus.Client.Repositories.Async
{
    public interface ICompositeActionTemplateRepository : ICreate<CompositeActionTemplateResource>, IModify<CompositeActionTemplateResource>, IDelete<CompositeActionTemplateResource>, IGet<CompositeActionTemplateResource>, IFindByName<CompositeActionTemplateResource>, IGetAll<CompositeActionTemplateResource>
    {
        Task<List<CompositeActionTemplateSearchResource>> Search();
        Task<CompositeActionTemplateResource> GetVersion(CompositeActionTemplateResource resource, int version);
        Task<CompositeActionUpdateResultResource[]> UpdateActions(CompositeActionTemplateResource actionTemplate, CompositeActionsUpdateResource update);
        Task SetLogo(CompositeActionTemplateResource resource, string fileName, Stream contents);
    }

    class CompositeActionTemplateRepository : BasicRepository<CompositeActionTemplateResource>, ICompositeActionTemplateRepository
    {
        public CompositeActionTemplateRepository(IOctopusAsyncClient client) : base(client, (string) "CompositeActionTemplates")
        {
        }

        public Task<List<CompositeActionTemplateSearchResource>> Search()
        {
            return Client.Get<List<CompositeActionTemplateSearchResource>>(Client.RootDocument.Link("CompositeActionTemplatesSearch"));
        }

        public Task<CompositeActionTemplateResource> GetVersion(CompositeActionTemplateResource resource, int version)
        {
            return Client.Get<CompositeActionTemplateResource>(resource.Links["Versions"], new { version });
        }

        public Task<CompositeActionUpdateResultResource[]> UpdateActions(CompositeActionTemplateResource actionTemplate, CompositeActionsUpdateResource update)
        {
            throw new NotImplementedException();
        }
        public Task SetLogo(CompositeActionTemplateResource resource, string fileName, Stream contents)
        {
            return Client.Post(resource.Link("Logo"), new FileUpload { Contents = contents, FileName = fileName }, false);
        }
    }
}