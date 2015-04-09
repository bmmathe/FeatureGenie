using System.Collections.Generic;
using System.Linq;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public class ConfigurationRepository : BaseRepository, IConfigurationRepository
    {
        public List<ConfigurationSetting> GetAll(int applicationId)
        {
            return Db.Query<ConfigurationSetting>(@"SELECT * FROM genie.[Configuration] WHERE ApplicationId = @ApplicationId", new { ApplicationId = applicationId }).ToList();
        }
        public ConfigurationSetting Get(int id)
        {
            return Db.Query<ConfigurationSetting>(@"SELECT * FROM genie.[Configuration] WHERE ConfigurationId = @ConfigurationId", new { ConfigurationId = id }).First();
        }

        public void Create(ConfigurationSetting setting)
        {
            Db.Execute(@"INSERT INTO genie.[Configuration] (ApplicationId, ValueTypeId, Name, [Value]) VALUES (@ApplicationId, @ValueTypeId, @Name, @Value)", setting);
        }

        public void Update(ConfigurationSetting setting)
        {
            Db.Execute(@"UPDATE genie.[Configuration] SET ValueTypeId = @ValueTypeId, Name = @Name, [Value] = @Value WHERE ConfigurationId = @ConfigurationId", setting);
        }

        public void Delete(int id)
        {
            Db.Execute(@"DELETE FROM genie.[Configuration] WHERE ConfigurationId = @ConfigurationId", new { ConfigurationId = id });
        }

        public int GetApplicationId(int configurationSettingId)
        {
            return
                Db.Query<int>(
                    @"SELECT ApplicationId FROM genie.ConfigurationSetting WHERE ConfigurationSettingId = @ConfigurationSettingId",
                    new {ConfigurationSettingId = configurationSettingId}).First();
        }
    }
}