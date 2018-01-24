﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestStore.Models;

namespace BestStore.Data.Interfaces
{
    public interface ICartItemRepository
    {
        Task<int> AddAsync(CartItem cartItem);
        Task<int> AddAsync(string sessionID, string userID, Guid productID, int amount);
        Task<int> DeleteAsync(Guid cartItemID);
        Task<int> UpdateAnonymousCartItem(string sessionID, string userID);
        Task<int> UpdateAsync(CartItem cartItem);
        Task<List<CartItem>> GetCartItemsAsync(string sessionID, string userID, int pageSize, int pageCount);
        Task<List<CartItem>> GetCartItemsAsync(string sessionID, int pageSize, int pageCount);
        Task<CartItem> GetByID(Guid id);
    }
}
