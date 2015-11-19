using System.Configuration;
using FeatureGenieService.ServiceModel;
using ServiceStack;

namespace featuregenie.client
{
    public class ConfigurationSettingsManager : IConfigurationSettingsManager
    {
        public string GetAllSettings(string applicationName)
        {
            using (var serviceClient = new JsonServiceClient(ConfigurationManager.AppSettings["FeatureGenieBaseUri"]))
            {
                return serviceClient.Get(new Settings() {ApplicationName = applicationName});
            }            
        }        
    }
}
