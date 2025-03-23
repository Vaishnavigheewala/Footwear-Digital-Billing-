using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class UserMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }//SupplierName or UserName

        [DataType(DataType.Password, ErrorMessage = "Enter valid Password")]
        public string Password { get; set; }
        [StringLength(200)]
        public string Address { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact Number must be 10 digits")]
        public long ContactNo { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual RoleMaster? Role { get; set; }
        public bool ActiveFlag{ get; set; }
       
    }
}
