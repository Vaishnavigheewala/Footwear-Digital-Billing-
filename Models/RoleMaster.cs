using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Models
{
    public class RoleMaster
    {
        [Key]
        [Required]
        
        public int RoleId { get; set; }
        [StringLength(100)]
        public string RoleName { get; set; }
        public Boolean ActiveFlag { get; set; }
    }
}
