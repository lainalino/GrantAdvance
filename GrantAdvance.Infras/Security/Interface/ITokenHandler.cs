using GrantAdvance.Domain.Models.Security;
using GrantAdvance.Domain.Models;

namespace GrantAdvance.Infras.Security.Interface
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        RefreshToken? TakeRefreshToken(string token, string userEmail);
        void RevokeRefreshToken(string token, string userEmail);
    }
}
