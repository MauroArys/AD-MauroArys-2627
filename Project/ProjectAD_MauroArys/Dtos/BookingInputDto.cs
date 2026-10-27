using System.ComponentModel.DataAnnotations;

namespace ProjectAD_MauroArys.Dtos
{
    public class BookingInputDto
    {
        [Required]
        public string Title { get; set; } = "";

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string BookedBy { get; set; } = "";
    }
}
