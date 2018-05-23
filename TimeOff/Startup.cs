using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeOff.Startup))]
namespace TimeOff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
