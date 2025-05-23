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
    public class LocalizationConfiguration : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.ToTable("Localizations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Key).UseIdentityColumn();
            builder.Property(x => x.Value);
            builder.HasOne(x => x.Language).WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => new { x.Key, x.LanguageId }).IsUnique();

        }
    }
}
