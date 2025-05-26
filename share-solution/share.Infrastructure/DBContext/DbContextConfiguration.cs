using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.DBContext
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Lấy connection string từ appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ShareDbContext>(options =>
            {
                options.UseSqlServer(connectionString); // hoặc UseNpgsql, UseMySql,...
            });

            return services;
        }
    }
}
