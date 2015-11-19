using System;

namespace FeatureGenieService.ServiceModel.Types
{
    public class ApplicationFeature
    {
        public string FeatureName { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Ratio { get; set; }        
    }
}