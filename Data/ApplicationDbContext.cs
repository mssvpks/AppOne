
using Microsoft.EntityFrameworkCore;
using AppOne.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace AppOne.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

        public DbSet<Documentations> Documentations { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<SiteAdmin> SiteAdmins { get; set; }
        public DbSet<Health> HealthRecords { get; set; }
    }
}
