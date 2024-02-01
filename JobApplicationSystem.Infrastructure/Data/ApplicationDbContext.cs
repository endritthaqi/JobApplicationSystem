using JobApplicationSystem.Domain.Entity;
using JobApplicationSystem.Infrastructure.Data.DataSeed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply your configurations here
            builder.ApplyConfiguration(new IdentityRoleConfiguration());

            // If you have other configurations, apply them here
            // builder.ApplyConfiguration(new AnotherEntityConfiguration());
        }
    }
}