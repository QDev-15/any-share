using Microsoft.EntityFrameworkCore;
using share.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.EFCore.SeeData
{
    public static class SeeDataConfiguration
    {
        public static void SeeData(ModelBuilder modelBuilder)
        {
            // Seed Language
            var languageEnId = Guid.NewGuid();
            var languageViId = Guid.NewGuid();

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = languageEnId,
                    Code = "en",
                    Name = "English",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Language
                {
                    Id = languageViId,
                    Code = "vi",
                    Name = "Tiếng Việt",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
            );

            // Seed Localization
            modelBuilder.Entity<Localization>().HasData(
                new Localization
                {
                    Id = Guid.NewGuid(),
                    Key = "Home.Title",
                    Value = "Welcome",
                    LanguageId = languageEnId,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Localization
                {
                    Id = Guid.NewGuid(),
                    Key = "Home.Title",
                    Value = "Chào mừng",
                    LanguageId = languageViId,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
            );
        }
    }
}
