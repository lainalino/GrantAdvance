using System.ComponentModel.DataAnnotations;

namespace GrantAdvance.Domain.Models;
public class User : BaseEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

}