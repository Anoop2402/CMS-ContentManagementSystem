using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMSViewEngine1.Startup))]
namespace CMSViewEngine1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
