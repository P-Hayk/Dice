using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWebAPI.Controllers
{
    public abstract class BaseController
    {
        Lazy<IHubContext> hub = new Lazy<IHubContext>(
           () => GlobalHost.ConnectionManager.GetHubContext<GameHub>()
       );
        protected IHubContext Hub
        {
            get { return hub.Value; }
        }
    }
}