using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DanieleVentorino.Startup))]
namespace DanieleVentorino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
