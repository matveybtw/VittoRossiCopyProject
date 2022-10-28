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
    public class ClientRepository:IRepository<Client>
    {
        private readonly ShopContext _shopContext;
        public ClientRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task AddAsync(Client entity)
        {
            _shopContext.Clients.Add(entity);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _shopContext.Clients.Remove(_shopContext.Clients.Find(id));
            await _shopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _shopContext.Clients.ToListAsync();
        }

        public async Task<Client> GetAsync(int id)
        {
            return await _shopContext.Clients.FindAsync(id);
        }

        public async Task UpdateAsync(int id, Client entity)
        {
            var e = await _shopContext.Clients.FindAsync(id);
            e.Login = entity.Login;
            e.Password = entity.Password;
            e.ClientInfo = entity.ClientInfo;
            _shopContext.Entry(e).State = EntityState.Modified;
            await _shopContext.SaveChangesAsync();
        }
    }
}
