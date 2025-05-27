using Microsoft.EntityFrameworkCore;
using share.Domain.Entities;
using share.Infrastructure.EFCore.Configurations;
using share.Infrastructure.EFCore.SeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.EFCore.DBContext
{
    public class ShareDbContext : DbContext
    {
        public ShareDbContext(DbContextOptions<ShareDbContext> options)
        : base(options)
        {
        }

        // DbSet declarations
        public DbSet<Advertisement> Advertisements { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<Like> Likes { set; get; }
        public DbSet<Localization> Localizations { set; get; }
        public DbSet<Log> Logs { set; get; }
        public DbSet<Media> Medias { set; get; }
        public DbSet<Message> Messages { set; get; }
        public DbSet<Rating> Ratings { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<SeoMeta> SeoMetas { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<VisitStatistic> VisitStatistics { set; get; }

        // OnModelCreating: Apply configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configuration classes
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new LocalizationConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SeoMetaConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VisitStatisticConfiguration());


            // seeData Configuration
            SeeDataConfiguration.SeeData(modelBuilder);
        }
    }
}
