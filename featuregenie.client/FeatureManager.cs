using System;
using System.Configuration;
using System.Linq;
using FeatureGenieService.ServiceModel;
using ServiceStack;

namespace featuregenie.client
{
    public class FeatureManager : IFeatureManager
    {
        public bool IsFeatureEnabled(string applicationName, string featureName)
        {
            var enabled = false;
            using (var serviceClient = new JsonServiceClient(ConfigurationManager.AppSettings["FeatureGenieBaseUri"]))
            {
                var features = serviceClient.Get<FeaturesResponse>(new Features() { ApplicationName = applicationName });
                var feature = features.Features.SingleOrDefault(f => f.FeatureName == featureName);
                if (feature != null && feature.IsEnabled)
                {
                    enabled = true;

                    if (feature.StartTime.HasValue && feature.StartTime >= DateTime.Now)
                        enabled = false;

                    if (feature.EndTime.HasValue && feature.EndTime <= DateTime.Now)
                        enabled = false;

                }
            }

            return enabled;
        }
    }
}
