using System.Web.Mvc;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IAuditLogRepository _auditLogRepository;
        
        public ConfigurationController(IConfigurationRepository configurationRepository, IAuditLogRepository auditLogRepository)
        {
            _configurationRepository = configurationRepository;
            _auditLogRepository = auditLogRepository;
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieRead)]
        public ActionResult _ConfigurationSettings(int id)
        {
            return PartialView(new ConfigurationSettingsViewModel() { ApplicationId=id, Settings=_configurationRepository.GetAll(id)});
        }

        [HttpPost]
        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Upsert(ConfigurationSetting setting)
        {
            var oldConfigurationSetting = new ConfigurationSetting();
            if (setting.ConfigurationId > 0)
            {
                oldConfigurationSetting = _configurationRepository.Get(setting.ConfigurationId);
                _configurationRepository.Update(setting);
            }
            else
            {
                setting.ConfigurationId = _configurationRepository.Create(setting);
            }
            _auditLogRepository.LogConfigurationAudit(oldConfigurationSetting, setting, User.Identity.Name);
            return PartialView("_ConfigurationSettings", new ConfigurationSettingsViewModel() {ApplicationId = setting.ApplicationId, Settings = _configurationRepository.GetAll(setting.ApplicationId)});
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Delete(int id)
        {
            var applicationId = _configurationRepository.GetApplicationId(id);
            var oldConfigurationSetting = _configurationRepository.Get(id);
            _configurationRepository.Delete(id);
            _auditLogRepository.LogConfigurationAudit(oldConfigurationSetting, new ConfigurationSetting(), User.Identity.Name);
            return PartialView("_ConfigurationSettings", new ConfigurationSettingsViewModel() { ApplicationId = applicationId, Settings = _configurationRepository.GetAll(applicationId) });
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Create(int applicationId)
        {
            ViewBag.Action = "Create";
            return PartialView("_ConfigurationSettingModal", new ConfigurationSetting(){ApplicationId = applicationId});
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieAdmin)]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            return PartialView("_ConfigurationSettingModal", _configurationRepository.Get(id));
        }

        [AuthorizeUser(AccessLevel = FeatureGenieRole.FeatureGenieRead)]
        public ActionResult Details(int id)
        {
            return Json(_configurationRepository.Get(id), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _configurationRepository.Dispose();
                _auditLogRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}