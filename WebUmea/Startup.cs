using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUmea.Startup))]
namespace WebUmea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
