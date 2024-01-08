
namespace GrantAdvance.Domain.Models.Security
{
    public class AccessToken : JsonWebToken
    {
        public RefreshToken RefreshToken { get; private set; }

        public AccessToken(string token, long expiration, RefreshToken refreshToken) : base(token, expiration)
        {
            RefreshToken = refreshToken
                ?? throw new ArgumentNullException("Specify a valid refresh token.");
        }
    }
}
