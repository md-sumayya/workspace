using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapiapp.Domain;
using dotnetapiapp.Repository;
using dotnetapiapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapiapp.Extentions
{
    public static class ServiceCollection
    {
        public static void AddProcessor(this IServiceCollection services){
            services.AddScoped<IAccountProcessor,AccountProcessor>();
        }

        public static void AddRepository(this IServiceCollection services){
            services.AddScoped<IAccountRepository,AccountRepository>();
        }

        public static void AddOrderDbContext(this IServiceCollection services,WebApplicationBuilder builder){
            services.AddDbContext<OrderDeliveryDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("OrderDB");
                options.UseSqlServer(connectionString);
            });
        }
    }
}