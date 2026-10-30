using Microsoft.EntityFrameworkCore;
using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}
