using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Workshop5webformwithAuthentication.Startup))]
namespace Workshop5webformwithAuthentication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
