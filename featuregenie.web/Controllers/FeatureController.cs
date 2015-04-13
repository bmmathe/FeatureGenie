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
            return PartialView(new FeaturesViewModel(){Features=_featureRepository.GetAll(id), ApplicationId = id});
        }

        public ActionResult Create(int applicationId)
        {
            return PartialView("_FeatureModal", new Feature(){ApplicationId = applicationId, IsEnabled = true});
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_FeatureModal", _featureRepository.Get(id));
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = "FeatureGenie Admin")]
        public ActionResult Upsert(Feature feature)
        {
            if (feature.FeatureId > 0)
            {
                _featureRepository.Update(feature);
            }
            else
            {
                _featureRepository.Create(feature);                
            }
            return PartialView("_Features", new FeaturesViewModel(){ApplicationId = feature.ApplicationId, Features =_featureRepository.GetAll(feature.ApplicationId)});
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _featureRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}