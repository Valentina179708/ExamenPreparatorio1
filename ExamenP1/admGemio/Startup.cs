using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admGemio.Startup))]
namespace admGemio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
