using System.Collections.Generic;

namespace featuregenie.client
{
    public interface IConfigurationSettingsManager
    {
        IEnumerable<ConfigurationSetting> GetAllSettings(int applicationId);
        IEnumerable<ConfigurationSetting> GetAllSettings(string applicationName);
    }
}