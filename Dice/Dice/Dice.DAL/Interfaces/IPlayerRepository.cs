using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Player Add(Player player);
        Player Get(string userName);
    }
}
