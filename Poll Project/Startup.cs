using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Poll_Project.Startup))]
namespace Poll_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
