using System.Collections.Generic;
using FeatureGenieService.ServiceModel.Types;
using ServiceStack;

namespace FeatureGenieService.ServiceModel
{
    [Route("/features/{ApplicationName}")]
    public class Features : IReturn<FeaturesResponse>
    {
        public string ApplicationName { get; set; }
    }

    public class FeaturesResponse : IHasResponseStatus
    {
        public List<ApplicationFeature> Features { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}