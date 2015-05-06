using System;
using System.Reflection;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public class AuditLogRepository : BaseRepository, IAuditLogRepository
    {
        public void LogFeatureAudit(Feature oldFeature, Feature newFeature, string username)
        {
            Type objType = oldFeature.GetType();
            var featureId = Math.Max(oldFeature.FeatureId, newFeature.FeatureId);
            foreach (PropertyInfo propertyInfo in objType.GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    var oldValue = propertyInfo.GetValue(oldFeature, null) ?? string.Empty;
                    var newValue = propertyInfo.GetValue(newFeature, null) ?? string.Empty;
                    if (!Equals(oldValue, newValue))
                    {
                        var featureLog = new FeatureAuditLog()
                        {
                            FeatureId = featureId,
                            FieldName = propertyInfo.Name,
                            OldValue = oldValue.ToString(),
                            NewValue = newValue.ToString(),
                            User = username
                        };
                        Db.Execute(@"INSERT INTO genie.[FeatureAuditLog] (FeatureId, FieldName, OldValue, NewValue, [User]) VALUES (@FeatureId, @FieldName, @OldValue, @NewValue, @User)", featureLog);
                    }
                }
            }
        }

        public void LogConfigurationAudit(ConfigurationSetting oldConfigurationSetting, ConfigurationSetting newConfigurationSetting, string username)
        {
            Type objType = oldConfigurationSetting.GetType();
            var configurationId = Math.Max(oldConfigurationSetting.ConfigurationId, newConfigurationSetting.ConfigurationId);
            foreach (PropertyInfo propertyInfo in objType.GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    var oldValue = propertyInfo.GetValue(oldConfigurationSetting, null) ?? string.Empty;
                    var newValue = propertyInfo.GetValue(newConfigurationSetting, null) ?? string.Empty;
                    if (!Equals(oldValue, newValue))
                    {
                        var configurationLog = new ConfigurationAuditLog()
                        {
                            ConfigurationId = configurationId,
                            FieldName = propertyInfo.Name,
                            OldValue = oldValue.ToString(),
                            NewValue = newValue.ToString(),
                            User = username
                        };
                        Db.Execute(@"INSERT INTO genie.[ConfigurationAuditLog] (ConfigurationId, FieldName, OldValue, NewValue, [User]) VALUES (@ConfigurationId, @FieldName, @OldValue, @NewValue, @User)", configurationLog);
                    }
                }
            }
        }
    }
}