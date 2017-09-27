using System;
using AutoMapper;
using Dice.Bll.Interfaces;
using Dice.DAL;
using Dice.DAL.Interfaces;
using Ninject;
using Dice.DTO;

namespace Dice.Bll.BLs
{
    public class PlayerBll : BaseBll, IPlayerBll
    {
        [Inject]
        public IUnitOfWork unitOfWork { get; set; }

        public PlayerSessionDTO AddPlayer(PlayerDTO playerDTO)
        {
            ValidatePlayer(playerDTO);
            playerDTO.IsActive = true;
            Mapper.Initialize(x => x.CreateMap<PlayerDTO, Player>());
            Player player = Mapper.Map<Player>(playerDTO);

            Player response = unitOfWork.PlayerRepo.Add(player);
            //Mapper.Initialize(x => x.CreateMap<Player, PlayerDTO>());
            //PlayerDTO result = Mapper.Map<PlayerDTO>(response);

            var ps = unitOfWork.PlayerSessionRepo.Add(
               new PlayerSession
               {
                   PlayerId = player.Id,
                   StartTime = DateTime.Now,
                   EndTime = DateTime.MinValue,
                   Token = Guid.NewGuid().ToString()
               });
            Mapper.Initialize(x => x.CreateMap<PlayerSession, PlayerSessionDTO>());
            PlayerSessionDTO result = Mapper.Map<PlayerSessionDTO>(ps);

            return result;
        }

        public PlayerDTO GetPlayer(PlayerDTO input)
        {
            PlayerDTO result = null;

            var player = unitOfWork.PlayerRepo.Get(input.Id);
            if(player != null)
            {
                Mapper.Initialize(x => x.CreateMap<Player, PlayerDTO>());
                result = Mapper.Map<PlayerDTO>(player);
            }
            return result;

        }
        public PlayerDTO GetPlayerByUserName(string UserName)
        {
            PlayerDTO result = null;

            var player = unitOfWork.PlayerRepo.Get(UserName);
            if (player != null)
            {
                Mapper.Initialize(x => x.CreateMap<Player, PlayerDTO>());
                result = Mapper.Map<PlayerDTO>(player);
            }
            return result;

        }

        public PlayerSessionDTO LoginPlayer(LoginDetails input)
        {
            var player = unitOfWork.PlayerRepo.Get(input.UserName);
            if (player == null)
                throw new DiceException("UserNotFound");

            if (player.PasswordHash != input.Password)
                throw new DiceException("WrongUserName");

            int playerid=unitOfWork.PlayerSessionRepo.DeleteAllPlayerSessions(player.Id);

            var ps = unitOfWork.PlayerSessionRepo.Add(
                new PlayerSession
                {
                    PlayerId = player.Id,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.MinValue,
                    Token = Guid.NewGuid().ToString()
                });
            Mapper.Initialize(x => x.CreateMap<PlayerSession, PlayerSessionDTO>());
            PlayerSessionDTO playerSessionDTO = Mapper.Map<PlayerSessionDTO>(ps);

            return playerSessionDTO;
        }

        private void ValidatePlayer(PlayerDTO playerDTO)
        {
            Player player = unitOfWork.PlayerRepo.Get(playerDTO.UserName);
            if (player != null)
                throw new DiceException(404,"UserNameExist");
            if (string.IsNullOrWhiteSpace(playerDTO.PasswordHash) || string.IsNullOrWhiteSpace(playerDTO.UserName) || string.IsNullOrWhiteSpace(playerDTO.FirstName))
                throw new DiceException("InvalidPlayerInfo");

        }


    }
}
