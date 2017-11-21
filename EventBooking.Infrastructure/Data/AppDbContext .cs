using Microsoft.EntityFrameworkCore;
using EventBooking.Core.Entities.DatabaseModels;

namespace EventBooking.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Rights> Rights { get; set; }
    }
}
