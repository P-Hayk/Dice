using Dice.Bll.Interfaces;
using Dice.DTO;
using DiceWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace DiceWebAPI.Controllers
{
    public class PlayerController: BaseController
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
                case (int)Method.LoginPlayer:
                    return LoginPlayer(JsonConvert.DeserializeObject<LoginDetails>(request.RequestData));
                case (int)Method.RegistratePlayer:
                    return RegistratePlayer(JsonConvert.DeserializeObject<PlayerDTO>(request.RequestData));
            }
            throw new Exception();
        }

        private BaseResponse LoginPlayer(LoginDetails input)
        {
            PlayerSessionDTO plSession = playerBll.LoginPlayer(input);            
            return new BaseResponse
            {
                ResponseCode = 0,
                ResponseObject = CreateResponse(plSession.Token, plSession.PlayerId)
            };
        }

        private BaseResponse RegistratePlayer(PlayerDTO playerDTO)
        {
            PlayerSessionDTO plSession = playerBll.AddPlayer(playerDTO);

            return new BaseResponse()
            {
                ResponseCode = 0,
                ResponseObject = CreateResponse(plSession.Token, plSession.PlayerId)
            };
        }

        private Object CreateResponse(string token,int playerid)
        {
            return new { token = token, playerid = playerid };
        }

    }
}