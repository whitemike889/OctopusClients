using System.Threading.Tasks;
using Octopus.Client.Model;
using Octopus.Client.Util;

namespace Octopus.Client.Repositories.Async
{
    public interface ICommunityActionTemplateRepository : IGet<CommunityActionTemplateResource>
    {
    }

    class CommunityActionTemplateRepository : BasicRepository<CommunityActionTemplateResource>, ICommunityActionTemplateRepository
    {
        public CommunityActionTemplateRepository(IOctopusAsyncRepository repository) : base(repository, "CommunityActionTemplates")
        {
        }
    }
    
    public interface ICommunityActionTemplateInstallationRepository
    {
        Task<ActionTemplateResource> GetInstalledTemplate(CommunityActionTemplateResource resource);
        Task Install(CommunityActionTemplateResource resource);
        Task UpdateInstallation(CommunityActionTemplateResource resource);
    }

    class CommunityActionTemplateInstallationRepository : ICommunityActionTemplateInstallationRepository
    {
        private readonly IOctopusAsyncRepository repository;

        public CommunityActionTemplateInstallationRepository(IOctopusAsyncRepository repository)
        {
            this.repository = repository;
        }

        public Task Install(CommunityActionTemplateResource resource)
        {
            var baseLink = resource.Links["Installation"];
            var link = repository.Scope.Apply(spaceId => baseLink.AppendSpaceId(spaceId),
                () => throw new SpaceScopedOperationInSystemContextException(),
                () => baseLink.ToString()); // Link without a space id acts on the default space
            return repository.Client.Post(link);
        }

        public Task UpdateInstallation(CommunityActionTemplateResource resource)
        {
            var baseLink = resource.Links["Installation"];
            var link = repository.Scope.Apply(spaceId => baseLink.AppendSpaceId(spaceId),
                () => throw new SpaceScopedOperationInSystemContextException(),
                () => baseLink.ToString()); // Link without a space id acts on the default space
            return repository.Client.Put(link);
        }

        public Task<ActionTemplateResource> GetInstalledTemplate(CommunityActionTemplateResource resource)
        {
            var baseLink = resource.Links["InstalledTemplate"];
            var link = repository.Scope.Apply(spaceId => baseLink.AppendSpaceId(spaceId),
                () => throw new SpaceScopedOperationInSystemContextException(),
                () => baseLink.ToString()); // Link without a space id acts on the default space
            return repository.Client.Get<ActionTemplateResource>(link);
        }
    }
}