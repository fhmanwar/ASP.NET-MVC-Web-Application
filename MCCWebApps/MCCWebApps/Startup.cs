using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCCWebApps.Startup))]
namespace MCCWebApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
