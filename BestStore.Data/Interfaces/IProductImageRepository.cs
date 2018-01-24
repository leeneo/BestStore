using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Models;

namespace BestStore.Data.Interfaces
{
    public interface IProductImageRepository
    {
        Task<int> AddAsync(ProductImage productImage);
        Task<int> DeleteAsync(int productImageID);
        Task UpdateAsync(ProductImage productImage);
        Task<ProductImage> GetAsync(int productImageID);
        Task<List<ProductImage>> GetProductImages(Guid productID);
    }
}
