using Dice.BLL.Entities;

namespace Dice.Bll.Interfaces
{
    public interface IPlayerBll
    {
        int AddPlayer(PlayerDTO player);
        PlayerSessionDTO LoginPlayer(LoginDetails input);
    }
}
