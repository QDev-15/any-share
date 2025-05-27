using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using share.Common;

namespace share.Infrastructure.EFCore.DBContext
{
    public class ShareDbContextFactory : IDesignTimeDbContextFactory<ShareDbContext>
    {
        public ShareDbContext CreateDbContext(string[] args)
        {
            // Lấy config từ file appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // hoặc thư mục chứa file json
                .AddJsonFile("appSettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString(Contants.ConnectionStringName);

            var optionsBuilder = new DbContextOptionsBuilder<ShareDbContext>();
            optionsBuilder.UseSqlServer(connectionString); // Đúng DB provider của bạn

            return new ShareDbContext(optionsBuilder.Options);
        }
    }
}
