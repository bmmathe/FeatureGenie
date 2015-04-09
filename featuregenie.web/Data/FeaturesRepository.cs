using System.Collections.Generic;
using System.Linq;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public class FeaturesRepository : BaseRepository
    {
        public List<Feature> GetAll(int applicationId)
        {
            return Db.Query<Feature>(@"SELECT * FROM genie.Feature WHERE ApplicationId = @ApplicationId", new{ApplicationId=applicationId}).ToList();
        }
        public Feature Get(int id)
        {
            return Db.Query<Feature>(@"SELECT * FROM genie.Feature WHERE FeatureId = @FeatureId", new { FeatureId = id }).First();
        }

        public void Create(Feature feature)
        {
            Db.Execute(@"INSERT INTO genie.Feature (ApplicationId, Name, Description, IsEnabled, StartTime, EndTime, Ratio) VALUES (@ApplicationId, @Name, @Description, @IsEnabled, @StartTime, @EndTime, @Ratio)", feature);
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