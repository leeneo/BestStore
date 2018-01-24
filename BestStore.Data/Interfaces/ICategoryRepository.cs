﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Models;

namespace BestStore.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> AddAsync(Category category);
        Task DeleteAsync(int categoryID);
        Task<Category> GetAsync(int categoryID);
        Task<int> GetCount();
        Task<IEnumerable<Product>> GetProductsAsync(int categoryID, string filter, int pageSize, int pageCount);
        Task<int> UpdateAsync(Category category);
    }
}
