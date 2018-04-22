using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(beerWebProject.Startup))]
namespace beerWebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
