using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContestApp.Startup))]
namespace ContestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
