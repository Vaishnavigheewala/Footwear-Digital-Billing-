using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class StockMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
        public int SellQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime Date { get; set; }
        public Boolean ActiveFlag { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public  virtual ProductMaster? productquantity {  get; set; }


    }
}
