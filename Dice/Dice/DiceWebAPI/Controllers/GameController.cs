using Dice.Bll.Interfaces;
using Dice.BLL.Entities;
using DiceWebAPI.Models;
using DiceWebAPI.Util;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.Linq;

namespace DiceWebAPI.Controllers
{
    public class GameController : BaseController
    {
        private IGameBll gameBll;

        public GameController()
        {
            gameBll = DependencyResolver.Current.GetService<IGameBll>();
        }

        public BaseResponse InvokeFunction(BaseRequest request)
        {
            switch (request.Method)
            {
                case "CreateGame":
                    return CreateGame(JsonConvert.DeserializeObject<GameDTO>(request.RequestData));
                case "JoinToGame":
                    return JoinToGame(JsonConvert.DeserializeObject<GameDTO>(request.RequestData));
            }
            throw new Exception();
        }


        private BaseResponse CreateGame(GameDTO gameDTO)
        {
            var gameDto = gameBll.AddGame(gameDTO);

            var context = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            context.Clients.All.game(gameDto);
            return new BaseResponse { ResponseObject = gameDto };
        }

        private BaseResponse JoinToGame(GameDTO gameDTO)
        {
            var gameID = gameBll.JoinToGame(gameDTO);
            var conID = GameHub.Connections.GetConnections(gameDTO.FirstPlayerID).LastOrDefault();
            Hub.Clients.Client(conID).game1(gameDTO);
            return new BaseResponse { ResponseObject = gameID };
        }

    }
}
