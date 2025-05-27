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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Alias).IsRequired().IsUnicode().HasMaxLength(500);
            builder.Property(c => c.IsActive).IsRequired(true).HasDefaultValue(false);
            builder.Property(c => c.IsDeleted).IsRequired(true).HasDefaultValue(false);
            builder.HasIndex(c => c.Name).HasDatabaseName("IX_Categories_Name");
            builder.HasIndex(c => c.Alias).HasDatabaseName("IX_Categories_Alias");
            builder.HasIndex(c => c.IsActive).HasDatabaseName("IX_Categories_IsActive");
            builder.HasMany(c => c.Articles)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); // Khi xóa Category, set null Articles
            builder.HasMany(c => c.Childrens)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // Khi xóa Category, Cần xóa hết Childrens
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Childrens)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // Khi xóa Category, Cần xóa hết Childrens
        }
    }
}
