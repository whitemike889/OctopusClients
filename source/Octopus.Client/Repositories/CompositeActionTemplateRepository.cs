using System;
using System.Collections.Generic;
using System.IO;
using Octopus.Client.Model;

namespace Octopus.Client.Repositories
{
    public interface ICompositeActionTemplateRepository : ICreate<CompositeActionTemplateResource>, IModify<CompositeActionTemplateResource>, IDelete<CompositeActionTemplateResource>, IGet<CompositeActionTemplateResource>, IFindByName<CompositeActionTemplateResource>, IGetAll<CompositeActionTemplateResource>
    {
        List<CompositeActionTemplateSearchResource> Search();
        CompositeActionTemplateResource GetVersion(CompositeActionTemplateResource resource, int version);
        CompositeActionUpdateResultResource[] UpdateActions(CompositeActionTemplateResource actionTemplate, CompositeActionsUpdateResource update);
        void SetLogo(CompositeActionTemplateResource resource, string fileName, Stream contents);
    }

    class CompositeActionTemplateRepository : BasicRepository<CompositeActionTemplateResource>, ICompositeActionTemplateRepository
    {
        public CompositeActionTemplateRepository(IOctopusClient client) : base(client, "CompositeActionTemplates")
        {
        }

        public List<CompositeActionTemplateSearchResource> Search()
        {
            return Client.Get<List<CompositeActionTemplateSearchResource>>(Client.RootDocument.Link("CompositeActionTemplatesSearch"));
        }

        public CompositeActionTemplateResource GetVersion(CompositeActionTemplateResource resource, int version)
        {
            return Client.Get<CompositeActionTemplateResource>(resource.Links["Versions"], new {version});
        }

        public CompositeActionUpdateResultResource[] UpdateActions(CompositeActionTemplateResource actionTemplate, CompositeActionsUpdateResource update)
        {
            return Client.Post<CompositeActionsUpdateResource, CompositeActionUpdateResultResource[]>(actionTemplate.Links["CompositeActionsUpdate"], update, new { actionTemplate.Id });
        }

        public void SetLogo(CompositeActionTemplateResource resource, string fileName, Stream contents)
        {
            Client.Post(resource.Link("Logo"), new FileUpload { Contents = contents, FileName = fileName }, false);
        }
    }
}