using System;

namespace Octopus.Client.Repositories
{
    public interface IGet<TResource>
    {
        TResource Get(string idOrHref);
        
        TResource Refresh(TResource resource);
    }
}