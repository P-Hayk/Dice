using Dice.BLL.Entities;

namespace Dice.Bll.Interfaces
{
    public interface IGameBll
    {
        GameDTO AddGame(GameDTO gameDTO);

        int JoinToGame(GameDTO gameDTO);
    }
}
