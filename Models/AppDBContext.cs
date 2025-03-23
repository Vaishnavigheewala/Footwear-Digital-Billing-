using BillingSystemMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set;}
        public DbSet<CategoryMaster> CategoryMasters { get; set;}
        public DbSet<ProductMaster> ProductMasters { get; set;}
        public DbSet<StockMaster> Stock { get; set; }
        public DbSet<SizeMaster> sizeMasters { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set;}
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderShipping> orderShippings { get; set; }
        public DbSet<GuranteeAndWarranty> guranty { get; set;}

       
        public DbSet<Cart> Cart {  get; set; }
    }
}
