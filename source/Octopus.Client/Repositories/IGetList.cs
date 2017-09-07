using System.Collections.Generic;

namespace Octopus.Client.Repositories
{
    public interface IGetList<TResource>
    {
        List<TResource> Get(params string[] ids);
    }
}