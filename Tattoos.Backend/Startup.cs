using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tattoos.Backend.Startup))]
namespace Tattoos.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
