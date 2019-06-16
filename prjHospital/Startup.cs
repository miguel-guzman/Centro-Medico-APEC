using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prjHospital.Startup))]
namespace prjHospital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
