using System.Collections.Generic;
using System.Linq;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public interface IApplicationsRepository
    {
        List<Application> GetAll();
        void Add(Application application);
        void Dispose();
    }

    public class ApplicationsRepository : BaseRepository, IApplicationsRepository
    {
        public List<Application> GetAll()
        {
            return Db.Query<Application>(@"SELECT ApplicationId, Name FROM genie.Application").ToList();
        }

        public void Add(Application application)
        {
            Db.Execute(@"INSERT INTO [genie].[Application] ([Name], [Description]) VALUES (@Name, @Description)",
                new {application.Name, application.Description});
        }
    }
}