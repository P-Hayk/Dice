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

            Round currentRound = currentGame.Rounds.ToList().Find(x => !x.EndTime.HasValue);

            Random r = new Random();

            if (currentRound == null && currentGame.FirstPlayerId == stepDTO.PlayerId)
            {
                if (currentGame.Rounds.Count == 3)
                    throw new DiceException(1, "GameOver");

                Round round = new Round
                {
                    GameId = stepDTO.GameId,
                    StartTime = DateTime.Now,
                    Steps = new List<Step> {
                        new Step
                        {
                            FirstDice = r.Next(1, 7),
                            SecondDice =r.Next(1,7),
                        }
                    }
                };
                unitOfWork.RoundRepo.Add(round);
                stepDTO.FirstDice = round.Steps.Last().FirstDice;
                stepDTO.SecondDice = round.Steps.Last().SecondDice;

            }

            else if (currentRound != null && currentGame.SecondPlayerId == stepDTO.PlayerId)
            {

                currentRound.Steps.Add(
                    new Step
                    {
                        FirstDice = r.Next(1, 7),
                        SecondDice = r.Next(1, 7)
                    });
                currentRound.EndTime = DateTime.Now;

                stepDTO.FirstDice = currentRound.Steps.Last().FirstDice;
                stepDTO.SecondDice = currentRound.Steps.Last().SecondDice;

            }
            else
                throw new DiceException(1, "");

            unitOfWork.Save();

            return stepDTO;
        }
    }
}
