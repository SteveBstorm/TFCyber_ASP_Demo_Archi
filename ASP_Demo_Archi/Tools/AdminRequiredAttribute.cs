using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_Demo_Archi.Tools
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AdminRequiredFilter)) { }
       
    }

    public class AdminRequiredFilter : IAuthorizationFilter
    {
        private readonly SessionManager _session;

        public AdminRequiredFilter(SessionManager session)
        {
            _session = session;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!(_session.CurrentUser!= null && _session.CurrentUser.IsAdmin))
            {
                context.Result = new RedirectToRouteResult(new {action = "Index", Controller = "Home"});
            }
        }
    }
}
