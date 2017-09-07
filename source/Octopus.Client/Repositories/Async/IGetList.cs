    using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octopus.Client.Repositories.Async
{
    public interface IGetList<TResource>
    {
        Task<List<TResource>> Get(params string[] ids);
    }
}