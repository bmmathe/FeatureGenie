using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace featuregenie.client
{
    public class ConfigurationSettingsManager : IConfigurationSettingsManager
    {
        public IEnumerable<ConfigurationSetting> GetAllSettings(int applicationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["FeatureGenieBaseUri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(string.Format("api/Configuration/AllSettings/{0}", applicationId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<IEnumerable<ConfigurationSetting>>().Result;
                    return result;
                }
            }
            return new List<ConfigurationSetting>();
        }

        public IEnumerable<ConfigurationSetting> GetAllSettings(string applicationName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["FeatureGenieBaseUri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(string.Format("api/Configuration/AllSettings/{0}", applicationName)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<IEnumerable<ConfigurationSetting>>().Result;
                    return result;
                }
            }
            return new List<ConfigurationSetting>();
        }
    }
}
