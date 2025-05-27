using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using share.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.EFCore.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.ToTable("Advertisements");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.RedirectUrl).IsRequired().HasMaxLength(1000);
            builder.Property(a => a.ImageUrl).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Position).IsRequired().HasMaxLength(500);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(false);
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.UpdatedAt).IsRequired();
            builder.HasIndex(a => a.IsActive).HasDatabaseName("IX_Advertisements_IsActive");
            builder.HasIndex(a => a.Position).HasDatabaseName("IX_Advertisements_Position");
            builder.HasIndex(a => a.CreatedAt).HasDatabaseName("IX_Advertisements_CreatedAt");
        }
    }
}
