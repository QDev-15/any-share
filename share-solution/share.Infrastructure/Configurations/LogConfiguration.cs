using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using share.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Level);
            builder.Property(x => x.Message);
            builder.Property(x => x.CreatedAt);
            builder.HasIndex(x => x.CreatedAt).HasDatabaseName("IX_Logs_CreatedAt");
        }
    }
}
