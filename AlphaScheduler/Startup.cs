using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlphaScheduler.Startup))]
namespace AlphaScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
