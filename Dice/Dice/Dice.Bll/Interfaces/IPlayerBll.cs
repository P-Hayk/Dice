
using Dice.DTO;

namespace Dice.Bll.Interfaces
{
    public interface IPlayerBll
    {
        int AddPlayer(PlayerDTO player);
        PlayerSessionDTO LoginPlayer(LoginDetails input);
    }
}
