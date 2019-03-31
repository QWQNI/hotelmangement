using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hotelmangement.Startup))]
namespace hotelmangement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
