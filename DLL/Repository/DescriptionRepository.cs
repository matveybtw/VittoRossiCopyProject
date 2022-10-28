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
    public class DescriptionRepository : IRepository<Description>
    {
        private readonly ShopContext _shopContext;
        public DescriptionRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task AddAsync(Description entity)
        {
            _shopContext.Descriptions.Add(entity);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _shopContext.Descriptions.Remove(_shopContext.Descriptions.Find(id));
            await _shopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Description>> GetAllAsync()
        {
            return await _shopContext.Descriptions.ToListAsync();
        }

        public async Task<Description> GetAsync(int id)
        {
            return await _shopContext.Descriptions.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Description entity)
        {
            var e = await _shopContext.Descriptions.FindAsync(id);
            e.Product = entity.Product;
            e.Name = entity.Name;
            e.Value = entity.Value;
            _shopContext.Entry(e).State = EntityState.Modified;
            await _shopContext.SaveChangesAsync();
        }
    }
}
