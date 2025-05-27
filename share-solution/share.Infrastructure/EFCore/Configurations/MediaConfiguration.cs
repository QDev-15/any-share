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
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Medias");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FileName)
                .IsRequired();
            builder.Property(m => m.FilePath)
                .IsRequired();
            builder.Property(m => m.FileType).IsRequired();
            builder.Property(m => m.FileSize)
                .IsRequired();

        }
    }
}
