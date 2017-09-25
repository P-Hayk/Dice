
using System.Web.Mvc;
using System.Net.Http;
using System.Threading;
using System.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

using Dice.DTO;
using Dice.Bll.Interfaces;

using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DiceWebAPI.Filter
{
    public class AuthorizationAttribute : DelegatingHandler
    {
        IPlayerBll playerBll;
        private enum Method
        {
            LoginPlayer = 0,
            RegistratePlayer = 1,         
        }
        public AuthorizationAttribute()
        {
            playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
        }
        public AuthorizationAttribute(HttpContent content)
        {
            playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
        }
        public string PasswordCode { get; set; }


        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            PlayerDTO form;
            int method;
            string token;

            CookieHeaderValue CookieValue = request.Headers.GetCookies().FirstOrDefault();
            if (CookieValue !=null && CookieValue.Cookies.Count != 0)
            {
                CookieState form_state = CookieValue.Cookies.Where(x => x.Name == "form").FirstOrDefault();
                form = JsonConvert.DeserializeObject<PlayerDTO>(form_state?.Value);

                CookieState method_state = CookieValue.Cookies.Where(x => x.Name == "method").FirstOrDefault();
                method = method_state==null ? -1: Int32.Parse(method_state.Value);

                CookieState token_state = CookieValue.Cookies.Where(x => x.Name == "Token").FirstOrDefault();
                token = token_state?.Value;

                if (method == -1)
                {

                }
                if ((Method)method==Method.LoginPlayer)
                {
                    PlayerDTO playerDTO = playerBll.GetPlayerByUserName(form.UserName);
                    if (playerDTO == null)
                        return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                if ((Method)method == Method.RegistratePlayer)
                {
                    PlayerDTO playerDTO=playerBll.GetPlayerByUserName(form.UserName);
                    if (playerDTO != null)
                        return new HttpResponseMessage(HttpStatusCode.Conflict);
                }
            }

            return await base.SendAsync(request, cancellationToken);
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