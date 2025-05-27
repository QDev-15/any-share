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
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Content).IsRequired(false);
            builder.Property(a => a.Source).IsRequired(false);
            builder.Property(a => a.Author).IsRequired(false);
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.UpdatedAt).IsRequired(false);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(false);
            builder.HasIndex(a => a.IsActive).HasDatabaseName("IX_Article_IsActive");
            builder.HasIndex(a => a.CreatedAt).HasDatabaseName("IX_Article_CreatedAt");
            builder.HasIndex(a => a.Title).HasDatabaseName("IX_Article_Title");
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); // Khi xóa Category, set null cho Article
            builder.HasOne(x => x.SeoMeta)
                .WithOne(x => x.Article)
                .HasForeignKey<SeoMeta>(x => x.ArticleId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Article, xóa luôn SeoMeta
            builder.HasMany(u => u.Comments)
                .WithOne(x => x.Article)
                     .HasForeignKey(x => x.ArticleId)
                     .OnDelete(DeleteBehavior.Cascade); // Khi xóa Article, xóa luôn Comment
            builder.HasMany(u => u.Likes)
                .WithOne(Article => Article.Article)
                     .HasForeignKey(Article => Article.ArticleId)
                     .OnDelete(DeleteBehavior.Cascade); // Khi xóa Article, xóa luôn Like
            builder.HasMany(u => u.Ratings)
                .WithOne(Article => Article.Article)
                     .HasForeignKey(Article => Article.ArticleId)
                     .OnDelete(DeleteBehavior.Cascade); // Khi xóa Article, xóa luôn Rating
            builder.HasMany(u => u.Tags).WithMany(r => r.Articles)
                   .UsingEntity<Dictionary<string, object>>(
                       "ArticleTags",
                       j => j
                           .HasOne<Tag>()
                           .WithMany()
                           .HasForeignKey("TagId")
                           .OnDelete(DeleteBehavior.Cascade), // Khi xóa Role, xóa luôn UserRoles
                       j => j
                           .HasOne<Article>()
                           .WithMany()
                           .HasForeignKey("ArticleId")
                           .OnDelete(DeleteBehavior.Cascade), // Khi xóa User, xóa luôn UserRoles
                       j =>
                       {
                           j.HasKey("TagId", "ArticleId");
                           j.ToTable("ArticleTags");
                       }
                   );
        }
    }
}
