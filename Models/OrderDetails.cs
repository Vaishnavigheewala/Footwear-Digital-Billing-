using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class OrderDetails
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Discount { get; set; }
        public string PromoCode { get; set; }
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal Amount must be greater than 0")]
        public double SubTotal { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductMaster? Product { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderMaster? orderdetail { get; set; }
        public Boolean  ActiveFlag { get; set; }
    }
}
