using System.ComponentModel.DataAnnotations;

namespace GrantAdvance.Domain.ViewModel
{
    public class UserCredentialsViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string? Email { get; init; }

        [Required]
        [StringLength(32)]
        public string? Password { get; init; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
    }
}
