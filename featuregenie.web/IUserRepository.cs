using System.Collections.Generic;

namespace featuregenie.web
{
    public interface IUserRepository
    {
        List<string> GetRoles(string username);
    }
}