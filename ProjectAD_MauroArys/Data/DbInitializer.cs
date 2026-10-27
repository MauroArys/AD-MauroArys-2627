using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Rooms.Any())
                return;

            var roomA = new Room { Name = "Vergaderzaal A", Capacity = 8, Floor = 1 };
            var roomB = new Room { Name = "Vergaderzaal B", Capacity = 4, Floor = 1 };

            roomA.Bookings.Add(new Booking
            {
                Title = "Teammeeting",
                StartTime = DateTime.UtcNow.AddHours(1),
                EndTime = DateTime.UtcNow.AddHours(2),
                BookedBy = "admin"
            });

            roomB.Bookings.Add(new Booking
            {
                Title = "Planning",
                StartTime = DateTime.UtcNow.AddHours(3),
                EndTime = DateTime.UtcNow.AddHours(4),
                BookedBy = "admin"
            });

            context.Rooms.AddRange(roomA, roomB);
            context.SaveChanges();
        }
    }
}
