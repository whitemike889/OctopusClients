using System;
using System.Collections.Generic;
using System.IO;
using Octopus.Client.Model;

namespace Octopus.Client.Repositories
{
    public interface IActionTemplateRepository : ICreate<ActionTemplateBaseResource>, IModify<ActionTemplateBaseResource>, IDelete<ActionTemplateBaseResource>, IGet<ActionTemplateBaseResource>, IFindByName<ActionTemplateBaseResource>, IGetAll<ActionTemplateBaseResource>
    {
        List<ActionTemplateSearchResource> Search();
        ActionTemplateBaseResource GetVersion(ActionTemplateBaseResource resource, int version);
        ActionUpdateResultResource[] UpdateActions(ActionTemplateBaseResource actionTemplate, ActionsUpdateResource update);
        void SetLogo(ActionTemplateBaseResource resource, string fileName, Stream contents);
    }

    class ActionTemplateRepository : BasicRepository<ActionTemplateBaseResource>, IActionTemplateRepository
    {
        public ActionTemplateRepository(IOctopusClient client) : base(client, "ActionTemplates")
        {
        }

        public List<ActionTemplateSearchResource> Search()
        {
            return Client.Get<List<ActionTemplateSearchResource>>(Client.RootDocument.Link("ActionTemplatesSearch"));
        }

        public ActionTemplateBaseResource GetVersion(ActionTemplateBaseResource resource, int version)
        {
            return Client.Get<ActionTemplateBaseResource>(resource.Links["Versions"], new {version});
        }

        public ActionUpdateResultResource[] UpdateActions(ActionTemplateBaseResource actionTemplate, ActionsUpdateResource update)
        {
            return Client.Post<ActionsUpdateResource, ActionUpdateResultResource[]>(actionTemplate.Links["ActionsUpdate"], update, new { actionTemplate.Id });
        }

        public void SetLogo(ActionTemplateBaseResource resource, string fileName, Stream contents)
        {
            Client.Post(resource.Link("Logo"), new FileUpload { Contents = contents, FileName = fileName }, false);
        }
    }
}