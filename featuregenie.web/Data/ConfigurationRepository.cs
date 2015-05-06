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

        public int Create(ConfigurationSetting setting)
        {
            string sql = @"DECLARE @OutputTbl TABLE (ID INT) INSERT INTO genie.[Configuration] (ApplicationId, ValueTypeId, Name, [Value]) OUTPUT INSERTED.ConfigurationId INTO @OutputTbl(ID) VALUES (@ApplicationId, @ValueTypeId, @Name, @Value) SELECT * FROM @OutputTbl";
            return Db.Query<int>(sql, setting).Single(); 
                //Db.Execute(@"INSERT INTO genie.[Configuration] (ApplicationId, ValueTypeId, Name, [Value]) VALUES (@ApplicationId, @ValueTypeId, @Name, @Value)", setting);
        }

        public void Update(ConfigurationSetting setting)
        {
            Db.Execute(@"UPDATE genie.[Configuration] SET ValueTypeId = @ValueTypeId, Name = @Name, [Value] = @Value WHERE ConfigurationId = @ConfigurationId", setting);
        }

        public void Delete(int id)
        {
            Db.Execute(@"DELETE FROM genie.[Configuration] WHERE ConfigurationId = @ConfigurationId", new { ConfigurationId = id });
        }

        public int GetApplicationId(int configurationId)
        {
            return
                Db.Query<int>(
                    @"SELECT ApplicationId FROM genie.Configuration WHERE ConfigurationId = @ConfigurationId",
                    new { ConfigurationId = configurationId }).First();
        }
    }
}