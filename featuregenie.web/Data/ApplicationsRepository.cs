using System.Collections.Generic;
using System.Linq;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public interface IApplicationsRepository
    {
        List<Application> GetAll();
        void Create(Application application);
        void Dispose();
    }

    public class ApplicationsRepository : BaseRepository, IApplicationsRepository
    {
        public List<Application> GetAll()
        {
            return Db.Query<Application>(@"SELECT ApplicationId, Name FROM genie.Application").ToList();
        }

        public void Create(Application application)
        {
            Db.Execute(@"INSERT INTO [genie].[Application] ([Name], [Description]) VALUES (@Name, @Description)",
                new {application.Name, application.Description});
        }

        public Application Get(string applicationName)
        {
            return Db.Query<Application>(@"SELECT * FROM genie.Application WHERE Name = @Name", new {Name = applicationName}).FirstOrDefault();
        }
    }
}