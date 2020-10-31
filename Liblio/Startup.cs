using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Liblio.Startup))]
namespace Liblio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
