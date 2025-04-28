
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public static class InferaStructureServicesRegistration
    {
        public static IServiceCollection AddInferaStructureServices(this IServiceCollection Services , IConfiguration Configuration)
        {
           Services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           Services.AddScoped<IDataSeeding, DataSeeding>();
           Services.AddScoped<IUintOfWork, UnitOfWork>();
            Services.AddScoped<IBasketRepository, BasketRepository>();
            Services.AddSingleton<IConnectionMultiplexer>((_)=>
            {
               return  ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RedisConnection"));
            });
           
          

            return Services;
        }
    }   
}
