using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskMgt.Models;

namespace TaskMgt.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().HasData
            (
                new ApplicationRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new ApplicationRole() { Name = "User", ConcurrencyStamp = "1", NormalizedName = "User" }

            );
        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
