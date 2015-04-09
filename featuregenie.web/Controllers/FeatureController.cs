using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using featuregenie.web.Data;

namespace featuregenie.web.Controllers
{
    public class FeatureController : Controller
    {
        private readonly FeaturesRepository _featureRepository;

        public FeatureController()
        {
            _featureRepository = new FeaturesRepository();
        }
        // GET: Feature
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var applicationId = _featureRepository.GetApplicationId(id);
            _featureRepository.Delete(id);
            return PartialView("_ConfigurationSettings", _featureRepository.GetAll(applicationId));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _featureRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}