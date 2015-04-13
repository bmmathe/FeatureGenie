using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace featuregenie.web.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        [Required]
        [DisplayName("Feature Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Ratio { get; set; }
        public int ApplicationId { get; set; }
    }
}