using Dice.Bll.Interfaces;
using Dice.DAL.Interfaces;
using Dice.DTO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.Bll.BLs
{
    public class RoundBll : IRoundBll
    {
        [Inject]
        public IUnitOfWork unitOfWork { get; set; }

        public RoundDTO AddRound(RoundDTO roundDTO)
        {
            throw new NotImplementedException();
        }
    }
}
