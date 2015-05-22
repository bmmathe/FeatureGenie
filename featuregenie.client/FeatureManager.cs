using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace featuregenie.client
{
    public class FeatureManager : IFeatureManager
    {
        public bool IsFeatureEnabled(int applicationId, string featureName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["FeatureGenieBaseUri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(string.Format("api/Feature/IsFeatureEnabled/{0}/{1}", applicationId, featureName)).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<bool>().Result;                    
                }
            }

            return false;
        }
    }
}
