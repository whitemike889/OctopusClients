using System;

namespace Octopus.Client.Model
{
    public class MetricResource : Resource, INamedResource
    {
        [Writeable]
        public string Name { get; set; }

        [Writeable]
        public string Type { get; set; }

        [Writeable]
        public string NodeId { get; set; }

        [Writeable]
        public DateTimeOffset CreatedTime { get; set; }

        [Writeable]
        public ReportingType ReportingType { get; set; }

        [Writeable]
        public TextReportData ReportData { get; set; }
    }

    public class TextReportData
    {
        public string[] Labels { get; set; }
        public TextReportSeries[] Series { get; set; }
    }

    public class TextReportSeries
    {
        public string Label { get; set; }
        public string[] Data { get; set; }
    }

    public enum ReportingType
    {
        ApiStats,
    }
}
