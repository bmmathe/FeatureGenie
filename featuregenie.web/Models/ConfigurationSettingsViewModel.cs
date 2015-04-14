using System.Collections.Generic;

namespace featuregenie.web.Models
{
    public class ConfigurationSettingsViewModel
    {
        public int ApplicationId { get; set; }
        public List<ConfigurationSetting> Settings { get; set; }
    }
}