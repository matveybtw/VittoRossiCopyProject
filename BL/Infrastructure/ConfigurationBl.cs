using BL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Infrastructure
{
    public static class ConfigurationBl
    {
        public static void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ShopContext>(o => { o.UseSqlServer(configuration.GetConnectionString("DefConnection"), b => b.MigrationsAssembly("VittoRossiCopyProject(Domain)")); });
        }
    }
}
 