using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiceWebAPI.Models
{
    public class BaseResponse
    {

        public int ResponseCode { get; set; }

        public object ResponseObject { get; set; }
    }
}