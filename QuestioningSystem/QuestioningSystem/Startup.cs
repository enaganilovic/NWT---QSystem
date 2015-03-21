using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuestioningSystem.Startup))]
namespace QuestioningSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
