using FinalProject.Domain.Interfaces;
using FinalProject.Infraestructure.Database;
using FinalProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    public static class Installer
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContextFinalProject>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStringsFinalProject"));
            });

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        }
    }
}
