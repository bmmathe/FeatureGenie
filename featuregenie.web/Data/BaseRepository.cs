using System;
using System.Configuration;
using System.Data.SqlClient;

namespace featuregenie.web.Data
{
    public class BaseRepository : IDisposable
    {
        private SqlConnection _connection;
        public SqlConnection Db
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeatureGenieDb"].ConnectionString);
                    _connection.Open();
                }
                return _connection;
            }
            set { _connection = value; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Db != null)
                {
                    Db.Dispose();
                    Db = null;
                }
            }            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}