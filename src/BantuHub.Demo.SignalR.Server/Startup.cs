using Owin;

namespace BantuHub.Demo.SignalR.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        } 
    }
}