using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Data.Interfaces;
using BestStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BestStore.Data.Repositories {
    // 定义IProductRepository 商品接口;后面会由ProductRepository对象来继承;
    public class ProductRepository : IProductRepository {
        private BestStoreDbContext _dbContext = null;
        public ProductRepository(BestStoreDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync (Product prod) {
            if (null == prod)
                return Guid.Empty;
            _dbContext.Products.Add (prod);
            await _dbContext.SaveChangesAsync ();
            return prod.ProductID;

            throw new NotImplementedException ();
        }

        public async Task DeleteAsync (Guid productID) {
            var prod = await _dbContext.Products.SingleOrDefaultAsync (p => p.ProductID == productID);
            if (prod == null) {
                _dbContext.Products.Remove (prod);
                await _dbContext.SaveChangesAsync ();
            }

            throw new NotImplementedException ();
        }

        public async Task<List<Product>> GetAllAsync () {
            return await _dbContext.Products.ToListAsync ();
            throw new NotImplementedException ();
        }

        public async Task<Product> GetAsync (Guid prodID) {
            return await _dbContext.Products.Where (p => p.ProductID == prodID).SingleOrDefaultAsync ();
            throw new NotImplementedException ();
        }

        public async Task<IEnumerable<Product>> GetPopularProductsAsync (int count) {
            var results = await _dbContext.Products
                .Select (p => new { Product = p, })
                .Take (count)
                .ToListAsync ();
            return results.Select (p => p.Product);
            throw new NotImplementedException ();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync (string filter, int pagesize, int pagecount) {
            var results = await _dbContext.Products.Where (p => (String.IsNullOrEmpty (filter) || p.ProductName.Contains (filter) || p.Description.Contains (filter)))
                .Select (p => new { Product = p, })
                .Skip (pagesize * pagecount)
                .Take (pagesize).ToListAsync ();
            return results.Select (p => p.Product);
        }

        public async Task<Guid> UpdateAsync (Product prod) {
            if (null == prod)
                return Guid.Empty;
            _dbContext.Products.Update (prod);
            await _dbContext.SaveChangesAsync ();
            return prod.ProductID;
            throw new NotImplementedException ();
        }
    }
}