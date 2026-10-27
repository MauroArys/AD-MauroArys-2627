using System.ComponentModel.DataAnnotations;

namespace ProjectAD_MauroArys.Dtos
{
    public class RoomQueryDto
    {
        public int? Capacity { get; set; }
        public int? Floor { get; set; }

        public string? Search { get; set; }

        [RegularExpression("^(name|capacity|floor)$", ErrorMessage = "Sorteren kan enkel op 'name', 'capacity' of 'floor'.")]
        public string? SortBy { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Pagina moet minstens 1 zijn.")]
        public int Page { get; set; } = 1;

        [Range(1, 50, ErrorMessage = "PageSize moet tussen 1 en 50 liggen.")]
        public int PageSize { get; set; } = 10;
    }
}
