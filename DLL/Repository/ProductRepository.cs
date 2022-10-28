using BL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class ProductRepository:IRepository<Product>
    {
        private readonly ShopContext _shopContext;
        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task AddAsync(Product entity)
        {
            _shopContext.Products.Add(entity);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _shopContext.Products.Remove(_shopContext.Products.Find(id));
            await _shopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _shopContext.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _shopContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Product entity)
        {
            var e = await _shopContext.Products.FindAsync(id);
            e.Reviews = entity.Reviews;
            e.Image = entity.Image;
            e.Name=entity.Name; 
            e.Price=entity.Price;
            e.Descriptions=entity.Descriptions;
            e.Guarantee=entity.Guarantee;
            _shopContext.Entry(e).State = EntityState.Modified;
            await _shopContext.SaveChangesAsync();
        }
    }
}
