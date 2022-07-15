using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RolePanel.Startup))]
namespace RolePanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
