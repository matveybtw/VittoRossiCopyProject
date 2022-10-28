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
    public class OrderRepository:IRepository<Order>
    {
        private readonly ShopContext _shopContext;
        public OrderRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task AddAsync(Order entity)
        {
            _shopContext.Orders.Add(entity);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _shopContext.Orders.Remove(_shopContext.Orders.Find(id));
            await _shopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _shopContext.Orders.ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _shopContext.Orders.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Order entity)
        {
            var e = await _shopContext.Orders.FindAsync(id);
            e.Client=entity.Client;
            e.Products = entity.Products;
            _shopContext.Entry(e).State = EntityState.Modified;
            await _shopContext.SaveChangesAsync();
        }
    }
}