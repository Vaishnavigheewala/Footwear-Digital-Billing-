using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Models
{ 
   public class Cart
        {
            [Key]
            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CartId { get; set; }

            public int UserId { get; set; }
            [ForeignKey("UserId")]
            public virtual UserMaster? User { get; set; }

            public int ProductId { get; set; }
            [ForeignKey("ProductId")]
            public virtual ProductMaster? Product { get; set; }

            public int Quantity { get; set; }

            [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
            public double Price { get; set; }

            [NotMapped]
            public double SubTotal
            {
                get { return Quantity * Price; }
            }

            public string PromoCode { get; set; }

            public int Discount { get; set; }

           
        }
    }



