using GrantAdvance.Domain.Models;
namespace GrantAdvance.Infras.Repositories.Interface
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> FindByEmailAsync(string email);
    }
}
