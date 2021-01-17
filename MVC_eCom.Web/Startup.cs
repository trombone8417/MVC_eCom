using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_eCom.Web.Startup))]
namespace MVC_eCom.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
