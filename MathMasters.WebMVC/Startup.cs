using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MathMasters.WebMVC.Startup))]
namespace MathMasters.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
