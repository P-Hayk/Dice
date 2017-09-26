using AutoMapper;
using Dice.Bll.Interfaces;
using Dice.DAL;
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
    public class PlayerSessionBll : BaseBll, IPlayerSessionBll
    {

        [Inject]
        public IUnitOfWork unitOfWork { get; set; }


        public PlayerSessionDTO AddPlayerSesion(int playerId)
        {
            Player player=unitOfWork.PlayerRepo.Get(playerId);
            if (player == null)
                return null;

            PlayerSessionDTO playerSessionDTO = new PlayerSessionDTO
            {
                PlayerId = playerId,
                Token = Guid.NewGuid().ToString(),
                StartTime = DateTime.Now,
                EndTime = DateTime.MinValue
            };

            player = null;
            Mapper.Initialize(x => x.CreateMap<PlayerSessionDTO, PlayerSession>());
            PlayerSession playerSession = Mapper.Map<PlayerSession>(playerSessionDTO);

            unitOfWork.PlayerSessionRepo.Add(playerSession);
            unitOfWork.Save();

            playerSessionDTO.Id = playerSession.Id;
            return playerSessionDTO;
        }

        public PlayerSessionDTO GetPlayerSesion(int playerId)
        {
            throw new NotImplementedException();
        }

        public PlayerSessionDTO GetPlayerSesion(string token)
        {
            PlayerSession playerSession= unitOfWork.PlayerSessionRepo.GetPlayerSession(token);

            Mapper.Initialize(x => x.CreateMap<PlayerSession, PlayerSessionDTO>());
            PlayerSessionDTO playerSessionDTO = Mapper.Map<PlayerSessionDTO>(playerSession);

            return playerSessionDTO;
        }
    }
}

