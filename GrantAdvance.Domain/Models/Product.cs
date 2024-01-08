using System.ComponentModel.DataAnnotations;

namespace GrantAdvance.Domain.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
