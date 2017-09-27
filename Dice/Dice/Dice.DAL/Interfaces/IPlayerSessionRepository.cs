using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Interfaces
{
    public interface IPlayerSessionRepository :IBaseRepository<PlayerSession>
    {

        PlayerSession Add(PlayerSession playerSession);

        PlayerSession GetPlayerSession(string token);

        int DeleteAllPlayerSessions(int playerid);
    }
}
