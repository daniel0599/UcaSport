using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UcaSport.Startup))]
namespace UcaSport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
