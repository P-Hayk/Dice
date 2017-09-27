using Dice.Bll;
using Dice.Bll.Interfaces;
using DiceWebAPI.Filter;
using DiceWebAPI.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace DiceWebAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MainController : ApiController
    {

        // POST: api/Main
        public BaseResponse Post([FromBody]BaseRequest request)
        {
            try
            {
                return GetResponse(request);
            }
            catch (DiceException ex)
            {

                return new BaseResponse { ResponseCode = ex.Id, ResponseObject = ex.Message };
            }
            catch (Exception ex)
            {
                return new BaseResponse { ResponseObject = ex.Message };
            }

        }
        private enum a
        {
            aaa=0
        }
        private BaseResponse GetResponse(BaseRequest request)
        {
            //if (request.Method != "RegistratePlayer" && request.Method != "LoginPlayer")
            //    CheckToken(request.Token);
            switch (request.Controller)
            {
                case (int)ControllerName.Player:
                    return new PlayerController().InvokeFunction(request);
                case (int)ControllerName.Game:
                    return new GameController().InvokeFunction(request);
                case (int)ControllerName.Step:
                    return new StepController().InvokeFunction(request);

            }
            throw new Exception();
        }

        //private void CheckToken(string token)
        //{
        //    //var playerSessionBll = DependencyResolver.Current.GetService<IPlayerSessionBll>();
        //    //playerSessionBll.CheckToken(token);
        //}
    }
}
