using Dice.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Http.Controllers;
using System.Net.Http;
using Dice.DTO;
//using System.Web.Http.Filters;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http.Headers;

namespace DiceWebAPI.Filter
{
    public class AuthorizationAttribute : DelegatingHandler
    {
        IPlayerBll playerBll;
        public AuthorizationAttribute()
        {
            playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
        }
        public AuthorizationAttribute(HttpContent content)
        {
            playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
        }
        public string PasswordCode { get; set; }


        protected async override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            CookieHeaderValue x =request.Headers.GetCookies().FirstOrDefault();
            CookieHeaderValue z = request.Headers.GetCookies("asd").FirstOrDefault();
            var k = request.Headers.GetCookies("form");
            if (false)
            {
                HttpResponseMessage message = new HttpResponseMessage();
                //message.Content = "aa";
                return message;
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    //piti stugvi tenc PasswordCode-ov mard ka te che.......
        //    // filterContext.HttpContext.Request.Cookies["mnnm"];
        //}
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    var a = httpContext.Request;
        //    //stex menak stugi vor METHOD==login or registration....u mnacac@ normal dzeverov
        //    return true;
        //}
        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    var form = HttpContext.Current.Request.ReadEntityBodyMode;//Cookies["form"];
        //    //PlayerDTO model = JsonConvert.DeserializeObject<PlayerDTO>(prop1);
        //    var abc = HttpContext.Current.Request.RequestContext;
        //    var x = HttpContext.Current;
        //    var y=HttpContext.Current.Response;
        //}
    }
}