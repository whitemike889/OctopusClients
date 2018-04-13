using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Octopus.Client.Model;

namespace Octopus.Client.Repositories.Async
{
    public interface IActionTemplateRepository : ICreate<ActionTemplateBaseResource>, IModify<ActionTemplateBaseResource>, IDelete<ActionTemplateBaseResource>, IGet<ActionTemplateBaseResource>, IFindByName<ActionTemplateBaseResource>, IGetAll<ActionTemplateBaseResource>
    {
        Task<List<ActionTemplateSearchResource>> Search();
        Task<ActionTemplateBaseResource> GetVersion(ActionTemplateBaseResource resource, int version);
        Task<ActionUpdateResultResource[]> UpdateActions(ActionTemplateBaseResource actionTemplate, ActionsUpdateResource update);
        Task SetLogo(ActionTemplateBaseResource resource, string fileName, Stream contents);
    }

    class ActionTemplateRepository : BasicRepository<ActionTemplateBaseResource>, IActionTemplateRepository
    {
        public ActionTemplateRepository(IOctopusAsyncClient client) : base(client, "ActionTemplates")
        {
        }

        public Task<List<ActionTemplateSearchResource>> Search()
        {
            return Client.Get<List<ActionTemplateSearchResource>>(Client.RootDocument.Link("ActionTemplatesSearch"));
        }

        public Task<ActionTemplateBaseResource> GetVersion(ActionTemplateBaseResource resource, int version)
        {
            return Client.Get<ActionTemplateBaseResource>(resource.Links["Versions"], new { version });
        }

        public Task<ActionUpdateResultResource[]> UpdateActions(ActionTemplateBaseResource actionTemplate, ActionsUpdateResource update)
        {
            return Client.Post<ActionsUpdateResource, ActionUpdateResultResource[]>(actionTemplate.Links["ActionsUpdate"], update, new { actionTemplate.Id });
        }
        public Task SetLogo(ActionTemplateBaseResource resource, string fileName, Stream contents)
        {
            return Client.Post(resource.Link("Logo"), new FileUpload { Contents = contents, FileName = fileName }, false);
        }
    }
}