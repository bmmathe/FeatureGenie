using ServiceStack;
using FeatureGenieService.ServiceModel;

namespace FeatureGenieService.ServiceInterface
{
    public class SettingsService : Service
    {
        public object Get(Settings request)
        {
            using (var redis = RedisManager.GetClient())
            {
                return redis.GetValue(string.Format("urn:Settings:{0}", request.ApplicationName));
            }
        }
    }
}
