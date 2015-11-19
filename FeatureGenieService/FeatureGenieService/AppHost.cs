using System.Collections.Generic;
using System.Configuration;
using Funq;
using ServiceStack;
using FeatureGenieService.ServiceInterface;
using ServiceStack.Redis;

namespace FeatureGenieService
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("FeatureGenieService", typeof(FeatureService).Assembly)
        {

        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {                        
            this.Plugins.Add(new CorsFeature());
            var l = new List<string>();
            l.Add(ConfigurationManager.ConnectionStrings["Redis"].ConnectionString);
            container.Register<IRedisClientsManager>(c => new RedisManagerPool(l, new RedisPoolConfig() { MaxPoolSize = 40 }));
        }
    }
}