using Dice.Bll.Interfaces;
using Dice.DAL;
using Dice.DAL.Interfaces;
using Dice.DTO;
using Ninject;
using System;
using System.Collections.Generic;

namespace Dice.Bll.BLs
{
    public class GameBll : BaseBll, IGameBll
    {
        [Inject]
        public IUnitOfWork unitOfWork { get; set; }


        public GameDTO AddGame(GameDTO gameDTO)
        {
            Game game = new Game
            {
                FirstPlayerId = gameDTO.FirstPlayerID                 
            };
            game.StartTime = DateTime.Now;
            game.EndTime = DateTime.Now;

            game = unitOfWork.GameRepo.AddGame(game);
            gameDTO.Id = game.Id;
            gameDTO.SecondPlayerID = game.SecondPlayerId;
            return gameDTO;
        }

        public GameDTO JoinToGame(GameDTO gameDTO)
        {
            if (gameDTO.Id > 0)
            {
                Game game = unitOfWork.GameRepo.Get(gameDTO.Id);
                if (game != null)
                {
                    game.SecondPlayerId = gameDTO.SecondPlayerID;
                }
                else
                {
                    throw new DiceException("GameNotFound");
                }
                unitOfWork.Save();
                gameDTO.Id = game.Id;
                return gameDTO;
            }

            else
                throw new DiceException("WrongGameId");

        }

    }
}
