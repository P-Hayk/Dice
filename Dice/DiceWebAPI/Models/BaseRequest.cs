using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWebAPI.Models
{
    public class BaseRequest
    {
        public string Controller { get; set; }

        public string Method { get; set; }

        public string Token { get; set; }

        public string RequestData { get { return JsonConvert.SerializeObject(RequestObject); } }

        public object RequestObject { get; set; }
    }
}