using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlugueService.Startup))]
namespace AlugueService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
