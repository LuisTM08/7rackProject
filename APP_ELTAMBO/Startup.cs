using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APP_ELTAMBO.Startup))]
namespace APP_ELTAMBO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
