using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeCare.Startup))]
namespace WeCare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
