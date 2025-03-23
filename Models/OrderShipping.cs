using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class OrderShipping
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact Number must be 10 digits")]
        public int PhoneNo { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        public string ShippingStatus { get; set; }
        public DateTime ShippingDateTime {  get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderMaster? ordershipping { get; set; }
        public Boolean ActiveFlag { get; set; }
       
    }
}
