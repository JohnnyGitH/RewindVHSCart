using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RewindVHSDemo.Startup))]
namespace RewindVHSDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
