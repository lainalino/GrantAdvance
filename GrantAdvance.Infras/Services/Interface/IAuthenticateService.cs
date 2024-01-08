using GrantAdvance.Domain.Models.Security;

namespace GrantAdvance.Infras.Services.Interface
{
    public interface IAuthenticateService
    {
        Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken, string userEmail);
    }
}
