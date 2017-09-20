using Dice.Bll.Interfaces;
using Dice.DTO;
using DiceWebAPI.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace DiceWebAPI.Controllers
{
    public class StepController : BaseController
    {

        private IStepBll stepBll;

        public StepController()
        {
            stepBll = DependencyResolver.Current.GetService<IStepBll>();
        }

        public BaseResponse InvokeFunction(BaseRequest request)
        {
            switch (request.Method)
            {
                case "RoleDice":
                    return RoleDice(JsonConvert.DeserializeObject<StepDTO>(request.RequestData));

            }
            throw new Exception();
        }

        private BaseResponse RoleDice(StepDTO stepDTO)
        {
            stepDTO = stepBll.RoleDice(stepDTO);
            Hub.Clients.Group(stepDTO.GameId.ToString()).animate(stepDTO);
            return new BaseResponse() { ResponseObject = stepDTO };
        }
    }
}
