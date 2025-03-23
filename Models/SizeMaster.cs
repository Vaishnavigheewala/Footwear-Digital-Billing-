using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class SizeMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Size { get; set; }
        public string SizeName { get; set; }
        public Boolean ActiveFlag { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductMaster? productsize { get; set; }
    }
}
