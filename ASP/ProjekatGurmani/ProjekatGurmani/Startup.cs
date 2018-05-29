using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjekatGurmani.Startup))]
namespace ProjekatGurmani
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
