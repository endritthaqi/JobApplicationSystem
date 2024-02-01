using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobApplicationSystem.Domain.Entity;

namespace JobApplicationSystem.Infrastructure.Data.DataSeed
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "ekipaGURIenisthaqi",
                    UserName = "enisthaqi",
                    FirstName = "Enis",
                    LastName = "Thaqi",
                    Gender = "Male",
                    Nationality = "Albanian",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "enisthaqi5@gmail.com",
                    NormalizedEmail = "ENISTHAQI5@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "enisthaqi"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser
                {
                    Id = "teamgrootendritthaqi542225",
                    UserName = "EndritThaqi",
                    FirstName = "Endrit",
                    LastName = "Thaqi",
                    Gender = "Male",
                    Nationality = "Albanian",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "endritthaqi@gmail.com",
                    NormalizedEmail = "ENDRITTHAQI@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "endritthaqi"),
                    SecurityStamp = Guid.NewGuid().ToString()
                });
        }
    }
}