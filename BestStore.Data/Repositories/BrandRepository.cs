using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Data.Interfaces;
using BestStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BestStore.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private BestStoreDbContext _dbContext = null;

        public BrandRepository(BestStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Brand brand)
        {
            if (null == brand)
                return -1;
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return brand.BrandID;
        }

        public async Task DeleteAsync(int brandID)
        {
            var brand = await _dbContext.Brands
                .SingleOrDefaultAsync(b => b.BrandID == brandID);

            if (brand != null)
            {
                _dbContext.Brands.Remove(brand);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Brand> GetAsync(int brandID)
        {
            return await _dbContext.Brands.Where(b => b.BrandID == brandID).SingleOrDefaultAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Brands.CountAsync();
        }
        public async Task<List<Brand>> GetAllAsync()
        {
            return await _dbContext.Brands.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsAsync(int brandID, string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.Products.Where
                (p => p.BrandID == brandID && (String.IsNullOrEmpty(filter) ||
                p.ProductName.Contains(filter) || p.Description.Contains(filter)))
                .Select(p => new { Product = p, })
                .Skip(pageSize * pageCount)
                .Take(pageSize)
                .ToListAsync();

            return results.Select(p => p.Product);
        }
        public async Task UpdateAsync(Brand brand)
        {
            if (null == brand)
                return;
            _dbContext.Brands.Update(brand);
            await _dbContext.SaveChangesAsync();
        }
    }
}
