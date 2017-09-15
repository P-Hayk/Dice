using AutoMapper;
using Dice.Bll.Interfaces;
using Dice.DAL;
using Dice.DAL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dice.Bll.BLs
{
    public class PlayerSessionBll : BaseBll, IPlayerSessionBll
    {

        [Inject]
        public IUnitOfWork unitOfWork { get; set; }


        public string AddPlayerSesion(int playerId)
        {
            PlayerSession ps = new PlayerSession
            {
                PlayerId = playerId,
                Token = Guid.NewGuid().ToString(),
                EndTime = DateTime.Now.AddHours(1)
            };

            unitOfWork.PlayerSessionRepo.Add(ps);
            return ps.Token;
        }
    }
}

