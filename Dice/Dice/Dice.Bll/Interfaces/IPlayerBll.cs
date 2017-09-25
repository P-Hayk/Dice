
using Dice.DTO;

namespace Dice.Bll.Interfaces
{
    public interface IPlayerBll
    {
        PlayerDTO AddPlayer(PlayerDTO player);
        PlayerSessionDTO LoginPlayer(LoginDetails input);

        PlayerDTO GetPlayer(PlayerDTO player);
        PlayerDTO GetPlayerByUserName(string UserName);
    }
}
