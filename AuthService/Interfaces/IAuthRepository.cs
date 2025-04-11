using AuthService.Models;

namespace AuthService.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> CreateAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
