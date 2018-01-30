using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstGitProject.Startup))]
namespace FirstGitProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
