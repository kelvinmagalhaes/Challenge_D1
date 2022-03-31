using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Challenge_D1.Startup))]
namespace Challenge_D1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
