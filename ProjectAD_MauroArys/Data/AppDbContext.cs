using Microsoft.EntityFrameworkCore;
using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlite("Data Source=meetingrooms.db");
            options.LogTo(Console.WriteLine, LogLevel.Information);
        }

       
    }
}
