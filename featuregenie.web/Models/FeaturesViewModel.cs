using System.Collections.Generic;

namespace featuregenie.web.Models
{
    public class FeaturesViewModel
    {
        public int ApplicationId { get; set; }
        public List<Feature> Features { get; set; }
    }
}