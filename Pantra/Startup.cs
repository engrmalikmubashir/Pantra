using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pantra.Startup))]
namespace Pantra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
