using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octopus.Client.Model;

namespace Octopus.Client.Repositories.Async
{
    public interface IOctopusServerNodeRepository : IModify<OctopusServerNodeResource>, IDelete<OctopusServerNodeResource>, IGet<OctopusServerNodeResource>, IFindByName<OctopusServerNodeResource>
    {
        Task<List<TaskResource>> GetTasks(OctopusServerNodeResource node, int skip = 0, int? take = null,
            string taskState = null);

        Task<int> GetTaskCount(OctopusServerNodeResource node, string taskState = null);
    }

    class OctopusServerNodeRepository : BasicRepository<OctopusServerNodeResource>, IOctopusServerNodeRepository
    {
        public OctopusServerNodeRepository(IOctopusAsyncClient client)
            : base(client, "OctopusServerNodes")
        {
        }

        public Task<List<TaskResource>> GetTasks(OctopusServerNodeResource node, int skip = 0, int? take = null, string taskState = null)
        {
            return Client.Get<List<TaskResource>>(node.Link("Tasks"), new { skip, take, taskState });
        }

        public async Task<int> GetTaskCount(OctopusServerNodeResource node, string taskState = null)
        {
            var result = await Client.Get<dynamic>(node.Link("TaskCount"), new { taskState });
            return (int)result.Count;
        }
    }
}
