using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using featuregenie.web.Data;
using featuregenie.web.Models;

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

        [HttpPost]
        public ActionResult _ConfigurationSettings(int id)
        {
            return PartialView(new ConfigurationSettingsViewModel() { ApplicationId=id, Settings=_configurationRepository.GetAll(id)});
        }

        [HttpPost]
        public ActionResult Upsert(ConfigurationSetting setting)
        {
            if (setting.ConfigurationId > 0)
            {
                _configurationRepository.Update(setting);
            }
            else
            {
                _configurationRepository.Create(setting);
            }
            return PartialView("_ConfigurationSettings", new ConfigurationSettingsViewModel() {ApplicationId = setting.ApplicationId, Settings = _configurationRepository.GetAll(setting.ApplicationId)});
        }

        public ActionResult Delete(int id)
        {
            var applicationId = _configurationRepository.GetApplicationId(id);
            _configurationRepository.Delete(id);
            return PartialView("_ConfigurationSettings", _configurationRepository.GetAll(applicationId));
        }

        public ActionResult Create(int applicationId)
        {
            return PartialView("_ConfigurationSettingModal", new ConfigurationSetting(){ApplicationId = applicationId});
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_ConfigurationSettingModal", _configurationRepository.Get(id));
        }

        public ActionResult Details(int id)
        {
            return Json(_configurationRepository.Get(id), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _configurationRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}