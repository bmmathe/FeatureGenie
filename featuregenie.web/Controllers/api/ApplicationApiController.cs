using System.Web.Http;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers.api
{
    [RoutePrefix("api/Application")]
    public class ApplicationApiController : ApiController
    {
        private readonly ApplicationsRepository _repository;

        public ApplicationApiController()
        {
            // inject
            _repository = new ApplicationsRepository();
        }

        [Route("{applicationName}")]
        public object Get(string applicationName)
        {
            return _repository.Get(applicationName);
        }     

        [HttpPost]
        [Route]
        public void Post(Application application)
        {
            _repository.Create(application);
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