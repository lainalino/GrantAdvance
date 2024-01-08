
namespace GrantAdvance.Domain.Models.Security
{
    public class TokenEmail
    {
        public string Email { get; set; } = null!;
        public RefreshToken RefreshToken { get; set; } = null!;
    }

}
