using Microsoft.Owin;
using Owin;
using UnitOfWorkExample.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace UnitOfWorkExample.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
