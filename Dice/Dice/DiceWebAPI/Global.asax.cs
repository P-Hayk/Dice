using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;

namespace DiceWebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //  GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                //Context.Request.Headers.GetCook

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                string[] userRoles = authTicket.UserData.Split(new Char[] { ',' });
                GenericPrincipal userPrincipal = new GenericPrincipal(new GenericIdentity(authTicket.Name), userRoles);
                HttpContext.Current.User = userPrincipal; //How do I reference this in the program?
            }
        }
    }
}
