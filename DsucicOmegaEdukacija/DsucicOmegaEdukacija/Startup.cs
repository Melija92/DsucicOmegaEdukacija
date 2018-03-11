using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DsucicOmegaEdukacija.Startup))]

namespace DsucicOmegaEdukacija
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}
