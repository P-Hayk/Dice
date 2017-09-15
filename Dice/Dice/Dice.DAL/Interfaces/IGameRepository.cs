using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DAL.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Game AddGame(Game game);
    }
}
