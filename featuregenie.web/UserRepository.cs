using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace featuregenie.web
{
    public class UserRepository : IUserRepository
    {
        public List<string> GetRoles(string username)
        {
            var roles = new List<string>();
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["Ents"].ConnectionString))
            {
                db.Open();
                roles = db.Query<string>(@"SELECT r.descr FROM ent_persons p
JOIN dbo.ent_personroles pr ON pr.person = p.person
JOIN dbo.ent_roles r ON r.[role] = pr.[role]
WHERE userlogin = @UserId AND personstatus = 'A'
AND pr.begindate < GETDATE() AND pr.enddate > GETDATE()", new { UserId = username }).ToList();
            }
            return roles;
        }
    }

    public class FakeUserRepository : IUserRepository
    {
        public List<string> GetRoles(string username)
        {
            var users = new List<string> { "FeatureGenie Admin" };
            return users;
        }
    }
}