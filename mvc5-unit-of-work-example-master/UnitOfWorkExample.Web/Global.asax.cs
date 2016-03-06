using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace UnitOfWorkExample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Users module covers it:

            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var roleCokie = Request.Cookies["COOKIE!!!!"];

            if (authCookie != null)
            {
                try
                {
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (authTicket != null)
                    {
                        var identity = new FormsIdentity(authTicket);
                        var principal = roleCokie == null ? new RolePrincipal("RoleProvider", identity) : new RolePrincipal(identity, roleCokie.Value);
                        Context.User = principal;
                    }
                }
                catch
                {
                    Session.Clear();
                    FormsAuthentication.SignOut();
                }
            }
        }
    }
}
