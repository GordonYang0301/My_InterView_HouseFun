using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleCURDWeb.Startup))]
namespace SimpleCURDWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
