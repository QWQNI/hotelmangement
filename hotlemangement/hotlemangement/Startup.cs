using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hotlemangement.Startup))]
namespace hotlemangement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
