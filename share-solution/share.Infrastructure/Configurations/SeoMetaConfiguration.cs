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
    public class SeoMetaConfiguration : IEntityTypeConfiguration<SeoMeta>
    {
        public void Configure(EntityTypeBuilder<SeoMeta> builder)
        {
            builder.ToTable("SeoMetas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MetaTitle)
                .HasMaxLength(300);

            builder.Property(x => x.MetaDescription)
                .HasMaxLength(1000);

            builder.Property(x => x.MetaKeywords)
                .HasMaxLength(500);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(x => x.Article)
                .WithOne(a => a.SeoMeta)
                .HasForeignKey<SeoMeta>(x => x.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ArticleId).IsUnique(); // đảm bảo 1-1
        }
    }
}
