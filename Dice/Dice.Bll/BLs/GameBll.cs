using Dice.Bll.Interfaces;
using Dice.BLL.Entities;
using Dice.DAL;
using Dice.DAL.Interfaces;
using Ninject;
using System;

namespace Dice.Bll.BLs
{
    public class GameBll : BaseBll, IGameBll
    {
        [Inject]
        public IUnitOfWork unitOfWork { get; set; }


        public GameDTO AddGame(GameDTO gameDTO)
        {
            Game game = new Game { FirstPlayerId = gameDTO.FirstPlayerID };
            game.StartTime = DateTime.Now;
            game.EndTime = DateTime.Now;

            game =  unitOfWork.GameRepo.AddGame(game);
            gameDTO.Id = game.Id;
            gameDTO.SecondPlayerID = game.SecondPlayerId;
            return gameDTO;
        }

        public int JoinToGame(GameDTO gameDTO)
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

                return game.Id;
            }

            else
                throw new DiceException("WrongGameId");

        }

    }
}
