using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projecto.Startup))]
namespace Projecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
