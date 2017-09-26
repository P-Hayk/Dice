using Dice.Bll.Interfaces;
using DiceWebAPI.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.Linq;
using Dice.DTO;

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
                case (int)GameMethod.CreateGame://"CreateGame":
                    return CreateGame(JsonConvert.DeserializeObject<GameDTO>(request.RequestData));
                case (int)GameMethod.JoinToGame://"JoinToGame":
                    return JoinToGame(JsonConvert.DeserializeObject<GameDTO>(request.RequestData));
            }
            throw new Exception();
        }


        private BaseResponse CreateGame(GameDTO gameDTO)
        {
            var gameDto = gameBll.AddGame(gameDTO);

            Hub.Clients.All.game(gameDto);
            return new BaseResponse { ResponseObject = gameDto };
        }

        private BaseResponse JoinToGame(GameDTO gameDTO)
        {
            var gameDto = gameBll.JoinToGame(gameDTO);
            var firstPlayerConID = GameHub.Connections.GetConnection(gameDTO.FirstPlayerID);
            var secondPlayerConID = GameHub.Connections.GetConnection((int)gameDTO.SecondPlayerID);
            Hub.Groups.Add(firstPlayerConID, gameDto.Id.ToString());
            Hub.Groups.Add(secondPlayerConID, gameDto.Id.ToString());
            return new BaseResponse { ResponseObject = gameDto };
        }

    }
}
