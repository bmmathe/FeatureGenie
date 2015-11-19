using ServiceStack;

namespace FeatureGenieService.ServiceModel
{
    [Route("/settings/{ApplicationName}")]
    public class Settings : IReturn<string>
    {
        public string ApplicationName { get; set; }
    }    
}
