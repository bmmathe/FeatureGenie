using System.Web.Http;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers.api
{
    [RoutePrefix("api/Configuration")]
    public class ConfigurationApiController : ApiController
    {
        private readonly ConfigurationRepository _repository;

        public ConfigurationApiController()
        {
            // inject
            _repository = new ConfigurationRepository();
        }

        [Route("{id:int}")]
        public object Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("AllSettings/{applicationId:int}")]
        public object GetAll(int applicationId)
        {
            return _repository.GetAll(applicationId);
        }

        [Route("AllSettings/{applicationId:string}")]
        public object GetAll(string applicationName)
        {
            return _repository.GetAll(applicationName);
        }

        [HttpPost]
        [Route]
        public void Post(ConfigurationSetting setting)
        {
            _repository.Create(setting);
        }

        [HttpPut]
        [Route]
        public void Put(ConfigurationSetting setting)
        {
            _repository.Update(setting);
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