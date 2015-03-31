using System.Collections.Generic;

namespace featuregenie.web.Models
{
    public class FeaturesViewModel
    {
        public string Notification { get; set; }
        public List<Feature> Features { get; set; }
    }
}