using Dice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.Bll.Interfaces
{
    public interface IStepBll
    {
        StepDTO RoleDice(StepDTO stepDTO);
    }
}
