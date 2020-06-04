using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameTracker.Startup))]
namespace GameTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
