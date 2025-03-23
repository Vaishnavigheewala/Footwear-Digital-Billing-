using BillingSystem.Models;
using BillingSystem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Repository.Implementation
{
    public class ProductRepostory : IProductRepository
    {

        private readonly AppDBContext _context;

        public ProductRepostory(AppDBContext context)
        {
            this._context = context;
        }

        public bool Add(ProductMaster product)
        {
            try
            {
                _context.ProductMasters.Add(product);
                _context.SaveChanges();
                return true;

            }catch (Exception ex) { 

                return false;
            }
        }

        public async Task<IEnumerable<ProductMaster>> GetProducts()
        {
            return await _context.ProductMasters.AsNoTracking().ToListAsync();
        }

        public async Task DeleteAsync(ProductMaster product)
        {
            _context.ProductMasters.Remove(product);
            await _context.SaveChangesAsync();  
        }

        public Task<ProductMaster> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

      

        public async Task UpdateAsync(ProductMaster product)
        {
            _context.ProductMasters.Update(product);
            await _context.SaveChangesAsync();        }
    }
}
