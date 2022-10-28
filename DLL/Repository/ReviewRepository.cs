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
    public class ReviewRepository:IRepository<Review>
    {
        private readonly ShopContext _shopContext;
        public ReviewRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task AddAsync(Review entity)
        {
            _shopContext.Reviews.Add(entity);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _shopContext.Reviews.Remove(_shopContext.Reviews.Find(id));
            await _shopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _shopContext.Reviews.ToListAsync();
        }

        public async Task<Review> GetAsync(int id)
        {
            return await _shopContext.Reviews.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Review entity)
        {
            var e = await _shopContext.Reviews.FindAsync(id);
            e.Content=entity.Content;
            e.Client=entity.Client;
            e.Product=entity.Product;
            _shopContext.Entry(e).State = EntityState.Modified;
            await _shopContext.SaveChangesAsync();
        }
    }
}
