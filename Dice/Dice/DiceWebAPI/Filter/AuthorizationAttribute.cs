using Dice.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiceWebAPI.Filter
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        IPlayerBll playerBll;
        public AuthorizationAttribute()
        {
            playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
        }
        public string PasswordCode { get; set; }
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    //piti stugvi tenc PasswordCode-ov mard ka te che.......
        //   // filterContext.HttpContext.Request.Cookies["mnnm"];
        //}
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return true;
        }
        }
}