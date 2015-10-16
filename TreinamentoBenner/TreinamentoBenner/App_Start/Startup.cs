using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TreinamentoBenner.Startup))]
namespace TreinamentoBenner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
