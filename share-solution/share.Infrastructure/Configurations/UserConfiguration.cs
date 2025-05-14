using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using share.Domain.Entities;

namespace share.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.IsActive).IsRequired(true).HasDefaultValue(false);
            builder.Property(u => u.IsActive).IsRequired(true).HasDefaultValue(false);
            builder.HasMany(u => u.Comments).WithOne(x => x.User).HasForeignKey(x=> x.UserId);
            builder.HasMany(u => u.Roles)
                    .WithMany(r => r.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRoles",
                        j => j
                            .HasOne<Role>()
                            .WithMany()
                            .HasForeignKey("RoleId")
                            .OnDelete(DeleteBehavior.Cascade), // Khi xóa Role, xóa luôn UserRoles
                        j => j
                            .HasOne<User>()
                            .WithMany()
                            .HasForeignKey("UserId")
                            .OnDelete(DeleteBehavior.Cascade), // Khi xóa User, xóa luôn UserRoles
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");
                            j.ToTable("UserRoles");
                        }
                    );
        }
    }
}
