using System.Collections.Generic;

namespace featuregenie.client
{
    public interface IConfigurationSettingsManager
    {
        string GetAllSettings(string applicationName);
    }
}