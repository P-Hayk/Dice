
using Dice.DTO;

namespace Dice.Bll.Interfaces
{
    public interface IPlayerBll
    {
        PlayerSessionDTO AddPlayer(PlayerDTO player);
        PlayerSessionDTO LoginPlayer(LoginDetails input);

        PlayerDTO GetPlayer(PlayerDTO player);
        PlayerDTO GetPlayerByUserName(string UserName);
    }
}
