using ProjectAD_MauroArys.Dtos;

namespace ProjectAD_MauroArys.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<TokenDto?> LoginAsync(LoginDto dto);
    }
}
