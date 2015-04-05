using System.Web.Http;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers.api
{
    [RoutePrefix("api/Feature")]
    public class FeatureController : ApiController
    {
        private readonly FeaturesRepository _repository;

        public FeatureController()
        {
            // inject
            _repository = new FeaturesRepository();
        }

        public object Get(int id)
        {
            return _repository.Get(id);
        }

        public void Post(Feature feature)
        {
            _repository.Create(feature);
        }

        public void Put(Feature feature)
        {
            _repository.Update(feature);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}