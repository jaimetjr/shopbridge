using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; } = null!;

        [Required]
        public DateTime ModifiedAt { get; set; }

        [Required]
        [MaxLength(50)]
        public string ModifiedBy { get; set; } = null!;
    }
}
