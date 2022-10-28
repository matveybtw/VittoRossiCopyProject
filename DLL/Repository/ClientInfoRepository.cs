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
    public class ClientInfoRepository:IRepository<ClientInfo>
    {
        private readonly ShopContext _shopContext;
        public ClientInfoRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task AddAsync(ClientInfo entity)
        {
            _shopContext.ClientInfos.Add(entity);
            await _shopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _shopContext.ClientInfos.Remove(_shopContext.ClientInfos.Find(id));
            await _shopContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientInfo>> GetAllAsync()
        {
            return await _shopContext.ClientInfos.ToListAsync();
        }

        public async Task<ClientInfo> GetAsync(int id)
        {
            return await _shopContext.ClientInfos.FindAsync(id);
        }

        public async Task UpdateAsync(int id, ClientInfo entity)
        {
            var e = await _shopContext.ClientInfos.FindAsync(id);
            e.Email=entity.Email;
            e.Client = entity.Client;
            e.Surname=entity.Surname;
            e.Name=entity.Name;
            e.PhoneNumber=entity.PhoneNumber;
            _shopContext.Entry(e).State = EntityState.Modified;
            await _shopContext.SaveChangesAsync();
        }
    }
}
