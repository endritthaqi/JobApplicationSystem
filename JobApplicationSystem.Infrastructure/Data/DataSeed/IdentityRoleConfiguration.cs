using JobApplicationSystem.Domain.StaticData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem.Infrastructure.Data.DataSeed
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Name = UserRoles.Admin, NormalizedName = UserRoles.Admin.ToUpper() },
                new IdentityRole { Name = UserRoles.RegistredUser, NormalizedName = UserRoles.RegistredUser.ToUpper() },
                new IdentityRole { Name = UserRoles.Punedhenesi, NormalizedName = UserRoles.Punedhenesi.ToUpper() }
            );
        }
    }

}
