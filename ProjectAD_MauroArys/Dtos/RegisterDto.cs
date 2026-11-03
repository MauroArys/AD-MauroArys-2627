using System.ComponentModel.DataAnnotations;

namespace ProjectAD_MauroArys.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; } = "";
        [Required]
        
        [MinLength(6)]
        public string Password { get; set; } = "";
    }
}
