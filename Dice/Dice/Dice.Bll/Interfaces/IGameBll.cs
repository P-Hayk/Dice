
using Dice.DTO;

namespace Dice.Bll.Interfaces
{
    public interface IGameBll
    {
        GameDTO AddGame(GameDTO gameDTO);

        GameDTO JoinToGame(GameDTO gameDTO);
    }
}
