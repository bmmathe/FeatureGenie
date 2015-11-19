using ServiceStack;
using FeatureGenieService.ServiceModel;

namespace FeatureGenieService.ServiceInterface
{
    public class FeatureService : Service
    {
        public object Any(Features request)
        {
            using (var redis = RedisManager.GetClient())
            {
                return redis.GetValue(string.Format("urn:Features:{0}", request.ApplicationName));
            }
        }
    }
}