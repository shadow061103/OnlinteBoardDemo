using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlinteBoardDemo.Startup))]
namespace OnlinteBoardDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
