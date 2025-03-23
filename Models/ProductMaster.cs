using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace BillingSystem.Models
{
    public class ProductMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(200)]
        public string ProductDescription { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        public string SkuNo { get; set; }//serial No

        public string ProductImage { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryMaster? CategoryMaster { get; set; }
        public Boolean ActiveFlag { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
