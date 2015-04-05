using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace featuregenie.client
{
    public class FeatureManager : IFeatureManager
    {
        public bool IsFeatureEnabled(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["FeatureGenieBaseUri"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(string.Format("api/Feature/{0}", name)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var feature = response.Content.ReadAsAsync<Feature>().Result;
                    if (feature.IsEnabled)
                    {
                        if (feature.StartTime.HasValue && feature.StartTime >= DateTime.Now)                        
                            return false;                        

                        if (feature.EndTime.HasValue && feature.EndTime <= DateTime.Now)
                            return false;

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
