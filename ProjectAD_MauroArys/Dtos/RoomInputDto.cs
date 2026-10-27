using System.ComponentModel.DataAnnotations;

namespace ProjectAD_MauroArys.Dtos
{
    public class RoomInputDto
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Naam moet tussen 1 en 200 tekens zijn.")]
        public string Name { get; set; } = "";

        [Range(1, int.MaxValue, ErrorMessage = "Capacity moet groter zijn dan 0.")]
        public int Capacity { get; set; }

        [Range(0, 50, ErrorMessage = "Floor moet tussen 0 en 50 liggen.")]
        public int Floor { get; set; }
    }
}
