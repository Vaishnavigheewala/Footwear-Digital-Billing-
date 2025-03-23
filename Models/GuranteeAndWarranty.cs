using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class GuranteeAndWarranty
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string TermsAndConditions { get; set; }
        public String Duration { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductMaster? Product { get; set; }
        public Boolean ActiveFlag { get; set; }
    }
}
