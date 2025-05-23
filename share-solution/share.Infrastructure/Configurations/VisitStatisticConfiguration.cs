using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using share.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.Configurations
{
    public class VisitStatisticConfiguration : IEntityTypeConfiguration<VisitStatistic>
    {
        public void Configure(EntityTypeBuilder<VisitStatistic> builder)
        {
            builder.ToTable("VisitStatistics");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.ViewCount)
                .IsRequired();

            builder.Property(x => x.Url)
                .HasMaxLength(1000);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasIndex(x => new { x.Date, x.Url })
                .IsUnique()
                .HasDatabaseName("IX_VisitStatistics_Date_Url");
        }
    }
}
