using KapitalMedya.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KapitalMedya.Persistence.Contexts
{
    public class KapitalMedyaDbContext : DbContext
    {
        public KapitalMedyaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); }

        public DbSet<Appartment> Appartments { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
