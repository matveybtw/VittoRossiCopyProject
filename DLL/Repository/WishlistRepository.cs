using BL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class WishlistRepository:IRepository<Wishlist>
    {
        private readonly ShopContext _shopContext;
        public WishlistRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task AddAsync(Wishlist entity)
        {
            _shopContext.Wishlists.Add(entity);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _shopContext.Wishlists.Remove(_shopContext.Wishlists.Find(id));
            await _shopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Wishlist>> GetAllAsync()
        {
            return await _shopContext.Wishlists.ToListAsync();
        }

        public async Task<Wishlist> GetAsync(int id)
        {
            return await _shopContext.Wishlists.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Wishlist entity)
        {
            var e = await _shopContext.Wishlists.FindAsync(id);
            e.Client=entity.Client;
            e.Products=entity.Products;
            _shopContext.Entry(e).State = EntityState.Modified;
            await _shopContext.SaveChangesAsync();
        }
    }
}
