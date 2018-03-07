using System.Collections.Generic;
using System.Threading.Tasks;
using BestStore.Models;

namespace BestStore.Data.Interfaces
{
    public interface IBrandRepository
    {
        Task<int> AddAsync(Brand brand);
        Task DeleteAsync(int brandID);
        Task<Brand> GetAsync(int brandID);
        Task<List<Brand>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<IEnumerable<Product>> GetProductsAsync(int brandId, string filter, int pageSize, int pageCount);
        Task UpdateAsync(Brand brand);
    }
}
