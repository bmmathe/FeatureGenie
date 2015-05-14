using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers
{    
    public class HomeController : Controller
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IApplicationsRepository _applicationRepository;

        public HomeController(IFeatureRepository featureRepository, IApplicationsRepository applicationsRepository)
        {
            _featureRepository = featureRepository; 
            _applicationRepository = applicationsRepository;            
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieRead)]
        public ActionResult Index()
        {
            var model = new HomeViewModel();
            model.Applications = _applicationRepository.GetAll();
            model.Applications.Insert(0, new Application(){ApplicationId = 0, Name = "--Select Application--"});
            return View(model);
        }
        
        
        [HttpPost]
        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult CreateApplication(Application model)
        {
            _applicationRepository.Add(model);
            var applications = _applicationRepository.GetAll();
            var viewModel = new HomeViewModel()
            {
                Applications = applications,
                SelectedApplicationId = applications.Single(x => x.Name == model.Name).ApplicationId
            };
            
            return PartialView("_Applications", viewModel);
        }       

        public ActionResult _ApplicationModal()
        {
            return PartialView(new Application());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _featureRepository.Dispose();
                _applicationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}