using Microsoft.EntityFrameworkCore;
using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Dtos
{
    public static class RoomQueryExtensions
    {
        public static IQueryable<Room> ApplyQuery(this IQueryable<Room> rooms, RoomQueryDto query)
        {
            if (query.Capacity is not null)
                rooms = rooms.Where(r => r.Capacity == query.Capacity);

            if (query.Floor is not null)
                rooms = rooms.Where(r => r.Floor == query.Floor);

            if (!string.IsNullOrWhiteSpace(query.Search))
                rooms = rooms.Where(r => EF.Functions.Like(r.Name, $"%{query.Search}%"));

            rooms = query.SortBy switch
            {
                "capacity" => rooms.OrderBy(r => r.Capacity),
                "floor" => rooms.OrderBy(r => r.Floor),
                _ => rooms.OrderBy(r => r.Name)
            };

            return rooms
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize);
        }
    }
}
