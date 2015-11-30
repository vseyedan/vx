using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Anbar.Startup))]
namespace Anbar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
