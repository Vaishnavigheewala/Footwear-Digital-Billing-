using BillingSystem.Models;


namespace BillingSystem.Repository.Abstract
{
    public interface IProductRepository
    {
        bool Add(ProductMaster product);

        Task<ProductMaster> FindByIdAsync(int id);
        Task UpdateAsync(ProductMaster product);
        Task DeleteAsync(ProductMaster product);
        Task<IEnumerable<ProductMaster>> GetProducts();

    }
}
