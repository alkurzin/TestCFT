using Microsoft.EntityFrameworkCore;
using TestCFT.DAL.Entities;

namespace TestCFT.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Application> Applications { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
