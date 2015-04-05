using System;

namespace featuregenie.client
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Ratio { get; set; }
    }
}
