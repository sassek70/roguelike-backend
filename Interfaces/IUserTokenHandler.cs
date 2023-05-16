

using DuckGame.Models.PlayerInfo;

namespace DuckGame.Interfaces
{

    public interface IUserTokenHandler
        {
            string CreateToken(User user);
            string ValidateToken(string token);
        }
}