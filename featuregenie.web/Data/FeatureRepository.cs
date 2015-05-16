using System.Collections.Generic;
using System.Linq;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public interface IFeatureRepository
    {
        List<Feature> GetAll(int applicationId);
        Feature Get(int id);
        int Create(Feature feature);
        void Update(Feature feature);
        void Delete(int id);
        int GetApplicationId(int featureId);
        void Dispose();
    }

    public class FeatureRepository : BaseRepository, IFeatureRepository
    {
        public List<Feature> GetAll(int applicationId)
        {
            return Db.Query<Feature>(@"SELECT * FROM genie.Feature WHERE ApplicationId = @ApplicationId", new{ApplicationId=applicationId}).ToList();
        }
        public Feature Get(int id)
        {
            return Db.Query<Feature>(@"SELECT * FROM genie.Feature WHERE FeatureId = @FeatureId", new { FeatureId = id }).First();
        }

        public Feature Get(int applicationId, string featureName)
        {
            return Db.Query<Feature>(@"SELECT * FROM genie.Feature WHERE ApplicationId = @ApplicationId AND Name = @FeatureName", new {ApplicationId = applicationId, FeatureName = featureName}).FirstOrDefault();
        }

        public int Create(Feature feature)
        {
            string sql = @"DECLARE @OutputTbl TABLE (ID INT) INSERT INTO genie.Feature (ApplicationId, Name, [Description], IsEnabled, StartTime, EndTime, Ratio) OUTPUT INSERTED.FeatureId INTO @OutputTbl(ID) VALUES (@ApplicationId, @Name, @Description, @IsEnabled, @StartTime, @EndTime, @Ratio) SELECT * FROM @OutputTbl";
            return Db.Query<int>(sql, feature).Single();
        }

        public void Update(Feature feature)
        {
            Db.Execute(@"UPDATE genie.Feature SET Name = @Name, Description = @Description, IsEnabled = @IsEnabled, StartTime = @StartTime, EndTime = @EndTime, Ratio = @Ratio WHERE FeatureId = @FeatureId", feature);
        }

        public void Delete(int id)
        {
            Db.Execute(@"DELETE FROM genie.Feature WHERE FeatureId = @FeatureId", new { FeatureId = id });
        }

        public int GetApplicationId(int featureId)
        {
            return
                Db.Query<int>(
                    @"SELECT ApplicationId FROM genie.Feature WHERE FeatureId = @FeatureId",
                    new { FeatureId = featureId }).First();
        }
    }
}