using System;
using System.Threading.Tasks;

namespace Octopus.Client.Repositories.Async
{
    public interface IGet<TResource>
    {
        Task<TResource> Get(string idOrHref);
        
        Task<TResource> Refresh(TResource resource);
    }
}