using GrantAdvance.Domain.Models;
using GrantAdvance.Domain.ViewModel;

namespace GrantAdvance.Infras.Services.Interface
{
    public interface IUserService
    {
        Task<UserResponseViewModel> CreateUserAsync(User user);
        Task<User?> FindByEmailAsync(string email);
    }
}
