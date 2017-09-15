using Dice.Bll.Interfaces;
using Dice.BLL.Entities;
using DiceWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace DiceWebAPI.Controllers
{
    public class PlayerController
    {
        private IPlayerSessionBll playerSessionBll;
        private IPlayerBll playerBll;
        public PlayerController()
        {
            playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
            playerSessionBll = DependencyResolver.Current.GetService<IPlayerSessionBll>();
        }

        public BaseResponse InvokeFunction(BaseRequest request)
        {
            switch (request.Method)
            {
                case "LoginPlayer":
                    return LoginPlayer(JsonConvert.DeserializeObject<LoginDetails>(request.RequestData));
                case "RegistratePlayer":
                    return RegistratePlayer(JsonConvert.DeserializeObject<PlayerDTO>(request.RequestData));
            }
            throw new Exception();
        }

        private BaseResponse LoginPlayer(LoginDetails input)
        {
            var plSession = playerBll.LoginPlayer(input);            
            return new BaseResponse { ResponseCode = 0, ResponseObject = plSession };
        }

        private BaseResponse RegistratePlayer(PlayerDTO player)
        {

            int playerID = playerBll.AddPlayer(player);

            return new BaseResponse() { ResponseObject = playerID };
        }

    }
}