using System;

namespace featuregenie.web.Models
{
    public class FeatureModal
    {
        public int FeatureModal_FeatureId { get; set; }
        public string FeatureModal_Name { get; set; }
        public string FeatureModal_Description { get; set; }
        public bool FeatureModal_IsEnabled { get; set; }
        public DateTime? FeatureModal_StartTime { get; set; }
        public DateTime? FeatureModal_EndTime { get; set; }
        public decimal? FeatureModal_Ratio { get; set; }
        public int FeatureModal_ApplicationId { get; set; }        
    }

    public static class FeatureModalExtensions
    {
        public static Feature ConvertToFeature(this FeatureModal featureModal)
        {
            return new Feature()
            {
                ApplicationId = featureModal.FeatureModal_ApplicationId,
                Name = featureModal.FeatureModal_Name,
                Description = featureModal.FeatureModal_Description,
                FeatureId = featureModal.FeatureModal_FeatureId,
                StartTime = featureModal.FeatureModal_StartTime,
                EndTime = featureModal.FeatureModal_EndTime,
                IsEnabled = featureModal.FeatureModal_IsEnabled,
                Ratio = featureModal.FeatureModal_Ratio
            };
        }

        public static FeatureModal ConvertToFeatureModal(this Feature feature)
        {
            return new FeatureModal()
            {
                FeatureModal_ApplicationId = feature.ApplicationId,
                FeatureModal_Name = feature.Name,
                FeatureModal_Description = feature.Description,
                FeatureModal_FeatureId = feature.FeatureId,
                FeatureModal_StartTime = feature.StartTime,
                FeatureModal_EndTime = feature.EndTime,
                FeatureModal_IsEnabled = feature.IsEnabled,
                FeatureModal_Ratio = feature.Ratio
            };
        }
    }
}