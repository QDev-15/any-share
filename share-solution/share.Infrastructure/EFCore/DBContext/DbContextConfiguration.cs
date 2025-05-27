using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using share.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.EFCore.DBContext
{
    public static class DbContextConfiguration
    {
        /// <summary>
        /// add dbconfig the same IService, In the file programm.cs: builder.Services.AddShareDbContext(builder.Configuration);
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddShareDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Lấy connection string từ appsettings.json
            var connectionString = configuration.GetConnectionString(Contants.ConnectionStringName);

            services.AddDbContext<ShareDbContext>(options =>
            {
                options.UseSqlServer(connectionString); // hoặc UseNpgsql, UseMySql,...
            });

            return services;
        }
    }
}
