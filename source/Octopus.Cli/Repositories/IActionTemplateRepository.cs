using System.Threading.Tasks;
using Octopus.Client.Model;

namespace Octopus.Cli.Repositories
{
    public interface IActionTemplateRepository
    {
        Task<ActionTemplateBaseResource> Get(string idOrHref);
        Task<ActionTemplateBaseResource> Create(ActionTemplateBaseResource resource);
        Task<ActionTemplateBaseResource> Modify(ActionTemplateBaseResource resource);

        Task<ActionTemplateBaseResource> FindByName(string name);
    }
}
