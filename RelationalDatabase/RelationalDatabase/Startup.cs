using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RelationalDatabase.Startup))]
namespace RelationalDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
