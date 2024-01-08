using GrantAdvance.Domain.Models.Security;
using GrantAdvance.Infras.Security.Interface;
using GrantAdvance.Infras.Services.Interface;

namespace GrantAdvance.Infras.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticateService(
            IUserService userService,
            IPasswordHasher passwordHasher,
            ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _passwordHasher = passwordHasher;
            _userService = userService;
        }

        // Create the acces token
        public async Task<TokenResponse> CreateAccessTokenAsync(string email, string password)
        {
            // get the user by email
            var user = await _userService.FindByEmailAsync(email);

            if (user == null || !_passwordHasher.PasswordMatches(password, user.Password))
            {
                return new TokenResponse(false, "Invalid credentials.", null);
            }

            var token = _tokenHandler.CreateAccessToken(user);

            return new TokenResponse(true, null, token);
        }

        // refresh the token
        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = _tokenHandler.TakeRefreshToken(refreshToken, userEmail);

            if (token == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            if (token.IsExpired())
            {
                return new TokenResponse(false, "Expired refresh token.", null);
            }

            var user = await _userService.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            var accessToken = _tokenHandler.CreateAccessToken(user);
            return new TokenResponse(true, null, accessToken);
        }

        public void RevokeRefreshToken(string refreshToken, string userEmail)
        {
            _tokenHandler.RevokeRefreshToken(refreshToken, userEmail);
        }
    }
}
