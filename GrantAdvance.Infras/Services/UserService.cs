using GrantAdvance.Domain.Models;
using GrantAdvance.Domain.ViewModel;
using GrantAdvance.Infras.Security.Interface;
using GrantAdvance.Infras.Services.Interface;
using GrantAdvance.Infras.Repositories.Interface;
using GrantAdvance.Data.Context;

namespace GrantAdvance.Infras.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
         IUserRepository userRepository,
         IPasswordHasher passwordHasher,
         IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponseViewModel> CreateUserAsync(User user)
        {
            var existingUser = await _userRepository.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return new UserResponseViewModel(false, "Email already in use.", null);
            }


            user.Password = _passwordHasher.HashPassword(user.Password);
            user.DateCreate = DateTime.UtcNow;
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return new UserResponseViewModel(true, null, user);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }
    }
}
