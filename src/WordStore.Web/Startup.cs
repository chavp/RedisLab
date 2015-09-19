using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordStore.Web.Startup))]
namespace WordStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
