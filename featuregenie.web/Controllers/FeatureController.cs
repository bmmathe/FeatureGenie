using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using featuregenie.web.Data;
using featuregenie.web.Models;

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

        [HttpPost]
        public ActionResult _Features(int id)
        {
            return PartialView(_featureRepository.GetAll(id));
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = "FeatureGenie Admin")]
        public ActionResult Create(FeatureModal feature)
        {
            _featureRepository.Create(feature.ConvertToFeature());
            return PartialView("_Features", _featureRepository.GetAll(feature.FeatureModal_ApplicationId));
        }
  
        public ActionResult Details(int id)
        {
            return Json(_featureRepository.Get(id), JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(AccessLevel = "FeatureGenie Admin")]
        public ActionResult Delete(int id)
        {
            var applicationId = _featureRepository.GetApplicationId(id);
            _featureRepository.Delete(id);
            return PartialView("_Features", _featureRepository.GetAll(applicationId));
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = "FeatureGenie Admin")]
        public ActionResult Edit(FeatureModal feature)
        {
            _featureRepository.Update(feature.ConvertToFeature());
            return PartialView("_Features", _featureRepository.GetAll(feature.FeatureModal_ApplicationId));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _featureRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}