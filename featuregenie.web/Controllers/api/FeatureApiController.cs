using System.Web.Http;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers.api
{
    [RoutePrefix("api/Feature")]
    public class FeatureApiController : ApiController
    {
        private readonly FeatureRepository _repository;

        public FeatureApiController()
        {
            // inject
            _repository = new FeatureRepository();
        }

        [Route("{id:int}")]
        public object Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        [Route]
        public void Post(Feature feature)
        {
            _repository.Create(feature);
        }

        [HttpPut]
        [Route]
        public void Put(Feature feature)
        {
            _repository.Update(feature);
        }

        [HttpDelete]
        [Route]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_repository != null)
                {
                    _repository.Dispose();
                }
            }
        }
    }
}