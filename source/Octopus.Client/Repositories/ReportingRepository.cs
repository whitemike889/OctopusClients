using Octopus.Client.Model;

namespace Octopus.Client.Repositories
{
    public interface IReportingRepository
    {
        ReportDeploymentCountOverTimeResource[] DeploymentsCountedByWeek(string projectId);
        MetricResource[] ApiStats();
    }

    class ReportingRepository : BasicRepository<MetricResource>, IReportingRepository
    {
        public ReportingRepository(IOctopusClient client)
            : base(client, null) // Not a collection
        {
        }

        public ReportDeploymentCountOverTimeResource[] DeploymentsCountedByWeek(string projectId)
        {
            return Client.Get<ReportDeploymentCountOverTimeResource[]>(Client.RootDocument.Link("Reporting/DeploymentsCountedByWeek"), new { projectId });
        }

        public MetricResource[] ApiStats()
        {
            return Client.Get<MetricResource[]>(Client.RootDocument.Link("Reporting/ApiStats"));
        }
    }
}
