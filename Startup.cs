using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(centricTeam4.Startup))]
namespace centricTeam4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
