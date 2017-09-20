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
            Random r = new Random();
            stepDTO.FirstDice = r.Next(1, 7);
            stepDTO.SecondDice = r.Next(1, 7);
            Mapper.Initialize(x => x.CreateMap<StepDTO, Step>());
            Step step = Mapper.Map<Step>(stepDTO);
            step = unitOfWork.StepRepo.Add(step);
            Mapper.Initialize(x => x.CreateMap<Step, StepDTO>());
            stepDTO = Mapper.Map<StepDTO>(step);
            return stepDTO;
        }
    }
}
