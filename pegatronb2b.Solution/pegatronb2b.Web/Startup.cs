using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pegatronb2b.Web.Startup))]
namespace pegatronb2b.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
