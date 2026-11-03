using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Rooms.Any())
                return;

            // 1. Zalen toevoegen
            var roomA = new Room { Name = "Vergaderzaal A", Capacity = 8, Floor = 1 };
            var roomB = new Room { Name = "Vergaderzaal B", Capacity = 4, Floor = 1 };
            var roomC = new Room { Name = "Brainstormruimte", Capacity = 12, Floor = 2 };
            var roomD = new Room { Name = "Directiekamer", Capacity = 6, Floor = 3 };

            context.Rooms.AddRange(roomA, roomB, roomC, roomD);
            context.SaveChanges(); 

            // 2. Bookings toevoegen (met correcte datums uit de opdracht)
            var booking1 = new Booking
            {
                RoomId = roomA.Id,
                Title = "Teamoverleg",
                StartTime = new DateTime(2026, 3, 2, 9, 0, 0),
                EndTime = new DateTime(2026, 3, 2, 10, 0, 0),
                BookedBy = "admin"
            };

            var booking2 = new Booking
            {
                RoomId = roomA.Id,
                Title = "Sprintreview",
                StartTime = new DateTime(2026, 3, 2, 14, 0, 0),
                EndTime = new DateTime(2026, 3, 2, 15, 30, 0),
                BookedBy = "admin"
            };

            var booking3 = new Booking
            {
                RoomId = roomC.Id,
                Title = "Marketing brainstorm",
                StartTime = new DateTime(2026, 3, 3, 10, 0, 0),
                EndTime = new DateTime(2026, 3, 3, 12, 0, 0),
                BookedBy = "admin"
            };

            context.Bookings.AddRange(booking1, booking2, booking3);
            context.SaveChanges();

            var eq = new List<Equipment>
            {
                new Equipment { Name = "Beamer", RoomId = roomA.Id },
                new Equipment { Name = "Whiteboard", RoomId = roomA.Id },
                new Equipment { Name = "Videoconferentie", RoomId = roomC.Id },
                new Equipment { Name = "TV-scherm", RoomId = roomD.Id }
            };

            context.Equipment.AddRange(eq);
            context.SaveChanges();
        }
    }
}
