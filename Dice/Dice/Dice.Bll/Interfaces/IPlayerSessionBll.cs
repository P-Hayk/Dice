
using Dice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.Bll.Interfaces
{
    public interface IPlayerSessionBll
    {
        PlayerSessionDTO AddPlayerSesion(int playerId);
        PlayerSessionDTO GetPlayerSesion(int playerId);
        PlayerSessionDTO GetPlayerSesion(string token);
    }
}
