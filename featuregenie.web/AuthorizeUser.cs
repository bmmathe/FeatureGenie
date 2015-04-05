using System.Web;
using System.Web.Mvc;

namespace featuregenie.web
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {        
        public IUserRepository UserRepository { get; set; }
        public string AccessLevel { get; set; }

        public AuthorizeUserAttribute()
        {
            UserRepository = DependencyResolver.Current.GetService<IUserRepository>();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            if (UserRepository.GetRoles(httpContext.User.Identity.Name).Contains(AccessLevel))
            {
                return true;
            }
            return false;
        }       
    }
}