using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Democracy1.Startup))]
namespace Democracy1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
