
using System.Web.Mvc;
//using System.Net.Http; DelegatingHandler
using System.Web.Http.Controllers;
using Dice.DTO;
using Dice.Bll.Interfaces;

using Newtonsoft.Json;
//using System.Linq;
using System.Collections.Generic;
using System;
using System.Web;
//using System.Web.Http.Filters;

namespace DiceWebAPI.Filter
{
    public class AuthorizationAttribute : System.Web.Http.AuthorizeAttribute
    {
        IPlayerBll playerBll;
        IPlayerSessionBll playerSessionBll;
        //private enum Method
        //{
        //    LoginPlayer = 0,
        //    RegistratePlayer = 1,         
        //}
        public AuthorizationAttribute()
        {
            playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
            playerSessionBll = DependencyResolver.Current.GetService<IPlayerSessionBll>();
        }
        //public AuthorizationAttribute(HttpContent content)
        //{
        //    playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
        //    playerSessionBll = DependencyResolver.Current.GetService<IPlayerSessionBll>();
        //}
        public string PasswordCode { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            
            //CookieHeaderValue CookieValue = actionContext.Request.Headers..FirstOrDefault();
            var a=HttpContext.Current.Request.Headers;
            int a1 = 1;
            int b = 2;
            int c = 3;
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            //piti stugvi tenc PasswordCode-ov mard ka te che.......
            // filterContext.HttpContext.Request.Cookies["mnnm"];
        }
        protected override bool IsAuthorized(HttpActionContext httpContext)
        {
            var a = httpContext.Request;
            //stex menak stugi vor METHOD==login or registration....u mnacac@ normal dzeverov
            return true;
        }

        //protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //    PlayerDTO form;
        //    int method;
        //    string token;

        //    CookieHeaderValue CookieValue = request.Headers.GetCookies().FirstOrDefault();
        //    if (CookieValue !=null && CookieValue.Cookies.Count != 0)
        //    {
        //        CookieState form_state = CookieValue.Cookies.Where(x => x.Name == "form").FirstOrDefault();
        //        form =form_state==null ? null : JsonConvert.DeserializeObject<PlayerDTO>(form_state.Value);

        //        CookieState method_state = CookieValue.Cookies.Where(x => x.Name == "method").FirstOrDefault();
        //        method = method_state==null ? -1: Int32.Parse(method_state.Value);

        //        CookieState token_state = CookieValue.Cookies.Where(x => x.Name == "token").FirstOrDefault();
        //        token = token_state==null ? null : JsonConvert.DeserializeObject<string>(token_state.Value);

        //        if (token!=null && method == -1 && form==null)
        //        {
        //            PlayerSessionDTO playerSessionDTO= playerSessionBll.GetPlayerSesion(token);
        //            if (playerSessionDTO == null)
        //                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        //            return await base.SendAsync(request, cancellationToken);
        //        }
        //        if ((Method)method==Method.LoginPlayer)
        //        {
        //            PlayerDTO playerDTO = playerBll.GetPlayerByUserName(form.UserName);
        //            if (playerDTO == null)
        //                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        //        }
        //        if ((Method)method == Method.RegistratePlayer)
        //        {
        //            PlayerDTO playerDTO=playerBll.GetPlayerByUserName(form.UserName);
        //            if (playerDTO != null)
        //                return new HttpResponseMessage(HttpStatusCode.Conflict);
        //        }
        //    }

        //    return await base.SendAsync(request, cancellationToken);
        //}

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