
namespace Octopus.Client.Model
{
    public class MetricResource : Resource, INamedResource
    {
        [Writeable]
        public string Name { get; set; }

        [Writeable]
        public string NodeId { get; set; }

        [Writeable]
        public string CreatedTime { get; set; }

        [Writeable]
        public MetricType Type { get; set; }

        [Writeable]
        public CsvReportData CsvReportData { get; set; }
    }

    public class CsvReportData
    {
        [Writeable]
        public string CsvLabels { get; set; }

        [Writeable]
        public string CsvValues { get; set; }
    }

    public enum MetricType
    {
        ApiStats,
    }
}
