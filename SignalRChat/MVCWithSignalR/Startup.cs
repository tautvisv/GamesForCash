using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWithSignalR.Startup))]
namespace MVCWithSignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
