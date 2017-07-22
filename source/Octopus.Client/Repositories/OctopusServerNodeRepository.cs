using System;
using Octopus.Client.Model;
using System.Collections.Generic;

namespace Octopus.Client.Repositories
{
    public interface IOctopusServerNodeRepository : IModify<OctopusServerNodeResource>, IDelete<OctopusServerNodeResource>, IGet<OctopusServerNodeResource>, IFindByName<OctopusServerNodeResource>
    {
        List<TaskResource> GetTasks(OctopusServerNodeResource node, int skip = 0, int? take = null,
            string taskState = null);

        int GetTaskCount(OctopusServerNodeResource node, string taskState = null);
    }
    
    class OctopusServerNodeRepository : BasicRepository<OctopusServerNodeResource>, IOctopusServerNodeRepository
    {
        public OctopusServerNodeRepository(IOctopusClient client)
            : base(client, "OctopusServerNodes")
        {
        }

        public int GetTaskCount(OctopusServerNodeResource node, string taskState = null)
        {
            var result = Client.Get<dynamic>(node.Link("TaskCount"), new { taskState });
            return result.Count;
        }

        public List<TaskResource> GetTasks(OctopusServerNodeResource node, int skip = 0, int? take = default(int?), string taskState = null)
        {
            return Client.Get<List<TaskResource>>(node.Link("Tasks"), new { skip, take, taskState });
        }
    }
}