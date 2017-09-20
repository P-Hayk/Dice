using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(DiceWebAPI.Startup))]

namespace DiceWebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            var config = new HubConfiguration();
            config.EnableJSONP = true;
                        app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR(config);

            //app.Map("/api/signalr", map =>
            //{
            //    map.UseCors(CorsOptions.AllowAll);
            //    map.RunSignalR(new HubConfiguration
            //    {
            //        EnableDetailedErrors = true,
            //        EnableJSONP = true
               
            //    });
            //});
            
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
