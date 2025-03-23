using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class OrderMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string TransactionId { get; set; }
        public string PaymentType { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Total Amount must be greater than 0")]
        public double TotalAmount { get; set; }
        public int PaymentStatus { get; set; }

        public int UserId { get; set;}
        [ForeignKey("UserId")]
        public virtual UserMaster? User { get; set; }

        public Boolean ActiveFlag { get; set; }
    }
}
