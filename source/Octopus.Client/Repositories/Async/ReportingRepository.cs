using Octopus.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octopus.Client.Repositories.Async
{
    public interface IReportingRepository
    {
        Task<ReportDeploymentCountOverTimeResource[]> DeploymentsCountedByWeek(string projectId);
        Task<MetricResource[]> ApiStats();
    }

    class ReportingRepository : BasicRepository<MetricResource>, IReportingRepository
    {
        public ReportingRepository(IOctopusAsyncClient client)
            : base(client, null) // Not a collection
        {
        }

        public Task<ReportDeploymentCountOverTimeResource[]> DeploymentsCountedByWeek(string projectId)
        {
            return Client.Get<ReportDeploymentCountOverTimeResource[]>(Client.RootDocument.Link("Reporting/DeploymentsCountedByWeek"), new { projectId });
        }

        public Task<MetricResource[]> ApiStats()
        {
            return Client.Get<MetricResource[]>(Client.RootDocument.Link("Reporting/ApiStats"));
        }
    }
}
