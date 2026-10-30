using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Data
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);

    }
}
