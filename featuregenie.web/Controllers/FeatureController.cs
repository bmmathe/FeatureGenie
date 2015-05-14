using System;
using System.Web.Mvc;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers
{ 
    public class FeatureController : Controller
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public FeatureController(IFeatureRepository featureRepository, IAuditLogRepository auditLogRepository)
        {
            _featureRepository = featureRepository;
            _auditLogRepository = auditLogRepository;
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieRead)]
        public ActionResult _Features(int id)
        {
            return PartialView(new FeaturesViewModel(){Features=_featureRepository.GetAll(id), ApplicationId = id});
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Create(int applicationId)
        {
            ViewBag.Action = "Create";
            return PartialView("_FeatureModal", new Feature(){ApplicationId = applicationId, IsEnabled = true});
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            return PartialView("_FeatureModal", _featureRepository.Get(id));
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Upsert(Feature feature)
        {
            var oldFeature = new Feature();
            if (feature.FeatureId > 0)
            {
                oldFeature = _featureRepository.Get(feature.FeatureId);
                _featureRepository.Update(feature);
            }
            else
            {
                feature.FeatureId = _featureRepository.Create(feature);
            }
            _auditLogRepository.LogFeatureAudit(oldFeature, feature, User.Identity.Name);
            return PartialView("_Features", new FeaturesViewModel(){ApplicationId = feature.ApplicationId, Features =_featureRepository.GetAll(feature.ApplicationId)});
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieRead)]
        public ActionResult Details(int id)
        {
            return Json(_featureRepository.Get(id), JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Delete(int id)
        {
            var applicationId = _featureRepository.GetApplicationId(id);
            var oldFeature = _featureRepository.Get(id);
            _featureRepository.Delete(id);
            _auditLogRepository.LogFeatureAudit(oldFeature, new Feature(), User.Identity.Name);
            return PartialView("_Features", new FeaturesViewModel() { ApplicationId = applicationId, Features = _featureRepository.GetAll(applicationId) });
        }            

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _featureRepository.Dispose();
                _auditLogRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}