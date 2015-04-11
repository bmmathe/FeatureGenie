namespace featuregenie.web.Models
{
    public class ConfigurationSettingModal
    {
        public int ConfigurationSettingModal_ConfigurationId { get; set; }
        public int ConfigurationSettingModal_ApplicationId { get; set; }
        public int ConfigurationSettingModal_ValueTypeId { get; set; }
        public string ConfigurationSettingModal_Name { get; set; }
        public string ConfigurationSettingModal_Value { get; set; }
    }

    public static class ConfigurationSettingModalExtensions
    {
        public static ConfigurationSetting ConvertToConfigurationSetting(this ConfigurationSettingModal configurationSettingModal)
        {
            return new ConfigurationSetting()
            {
                ApplicationId = configurationSettingModal.ConfigurationSettingModal_ApplicationId,
                Name = configurationSettingModal.ConfigurationSettingModal_Name,
                Value = configurationSettingModal.ConfigurationSettingModal_Value,
                ValueTypeId = configurationSettingModal.ConfigurationSettingModal_ValueTypeId,
                ConfigurationId = configurationSettingModal.ConfigurationSettingModal_ConfigurationId,                
            };
        }

        public static ConfigurationSettingModal ConvertToFeatureModal(this ConfigurationSetting configurationSetting)
        {
            return new ConfigurationSettingModal()
            {
                ConfigurationSettingModal_ApplicationId = configurationSetting.ApplicationId,
                ConfigurationSettingModal_Name = configurationSetting.Name,
                ConfigurationSettingModal_Value = configurationSetting.Value,
                ConfigurationSettingModal_ValueTypeId = configurationSetting.ValueTypeId,
                ConfigurationSettingModal_ConfigurationId = configurationSetting.ConfigurationId,       
            };
        }
    }
}