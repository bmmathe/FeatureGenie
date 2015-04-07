using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using featuregenie.web.Data;

namespace featuregenie.web.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationController(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        // GET: Configuration
        public ActionResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _configurationRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}