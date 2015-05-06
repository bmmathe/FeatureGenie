using System;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public interface IAuditLogRepository : IDisposable
    {
        void LogFeatureAudit(Feature oldFeature, Feature newFeature, string username);
        void LogConfigurationAudit(ConfigurationSetting oldConfigurationSetting, ConfigurationSetting newConfigurationSetting, string username);
    }
}