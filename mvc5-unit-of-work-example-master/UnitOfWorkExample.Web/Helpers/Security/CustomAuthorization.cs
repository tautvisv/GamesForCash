using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace UnitOfWorkExample.Web.Helpers.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CustomAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new NullReferenceException("HttpContext is null.");
            }
//            httpContext.User = new GenericPrincipal(new GenericIdentity("user", "type"), "roles".Split(new []{","}, StringSplitOptions.RemoveEmptyEntries));
            return base.AuthorizeCore(httpContext);
        }
    }
}