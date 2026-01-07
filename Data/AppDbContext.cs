using Microsoft.EntityFrameworkCore;
using AgendamentoPro.Models;

namespace AgendamentoPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
