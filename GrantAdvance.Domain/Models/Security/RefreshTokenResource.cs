using System.ComponentModel.DataAnnotations;

namespace GrantAdvance.Domain.Models.Security
{
    public record RefreshTokenResource
    {
        [Required]
        public string? Token { get; init; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string? UserEmail { get; init; }
    }
}
