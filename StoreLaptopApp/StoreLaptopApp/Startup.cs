using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreLaptopApp.Startup))]
namespace StoreLaptopApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
