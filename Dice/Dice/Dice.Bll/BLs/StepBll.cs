using Dice.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dice.DTO;
using Ninject;
using Dice.DAL.Interfaces;
using Dice.DAL;
using AutoMapper;

namespace Dice.Bll.BLs
{
    public class StepBll : BaseBll, IStepBll
    {

        [Inject]
        public IUnitOfWork unitOfWork { get; set; }

        public StepDTO RoleDice(StepDTO stepDTO)
        {
            Game currentGame = unitOfWork.GameRepo.Get(stepDTO.GameId);

            if (currentGame == null)
                throw new DiceException(1, "");

            int stepsCount = 0;

            if (currentGame.Rounds.Count != 0)
                stepsCount = currentGame.Rounds.LastOrDefault().Steps.Count;

            Random r = new Random();

            if (stepsCount % 2 == 0 && currentGame.FirstPlayerId == stepDTO.PlayerId)
            {
                if (currentGame.Rounds.Count == 3)
                    throw new DiceException(1, "GameOver");

                Round round = new Round
                {
                    GameId = stepDTO.GameId,
                    Steps = new List<Step> {
                        new Step
                        {
                            FirstDice = r.Next(1, 7),
                            SecondDice =r.Next(1,7)
                        }
                    }
                };
                unitOfWork.RoundRepo.Add(round);

            }

            else if (stepsCount % 2 != 0 && currentGame.SecondPlayerId == stepDTO.PlayerId)
            {
                currentGame.Rounds.Last().Steps.Add(
                    new Step
                    {
                        FirstDice = r.Next(1, 7),
                        SecondDice = r.Next(1, 7)
                    });
            }
            else
                throw new DiceException(1, "");

            unitOfWork.Save();

            stepDTO.FirstDice = currentGame.Rounds.Last().Steps.Last().FirstDice;
            stepDTO.SecondDice = currentGame.Rounds.Last().Steps.Last().SecondDice;

            return stepDTO;
        }
    }
}
