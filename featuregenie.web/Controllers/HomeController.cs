using System.Collections.Generic;
using System.Web.Mvc;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers
{    
    public class HomeController : Controller
    {
        private readonly FeaturesRepository _featureRepository;
        private readonly ApplicationsRepository _applicationRepository;

        public HomeController()
        {
            _featureRepository = new FeaturesRepository(); 
            _applicationRepository = new ApplicationsRepository();            
        }

        [AuthorizeUser(AccessLevel = "FeatureGenie Read")]
        public ActionResult Index()
        {
            var model = new HomeViewModel();
            model.Applications = _applicationRepository.GetAll();
            return View(model);
        }
        
        [AuthorizeUser(AccessLevel = "FeatureGenie Admin")]
        public ActionResult Delete(int id)
        {
            _featureRepository.Delete(id);
            return RedirectToAction("Index");
        }        

        

        [HttpPost]
        public ActionResult CreateApplication(Application model)
        {
            _applicationRepository.Add(model);
            return PartialView("_Features", new List<Feature>());
        }

        [HttpPost]
        public ActionResult _Features(int id)
        {
            return PartialView(_featureRepository.GetAll(id));
        }

        public ActionResult _CreateApplicationModal()
        {
            return PartialView();
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
                _featureRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}