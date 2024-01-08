using GrantAdvance.Data.Context;
using GrantAdvance.Domain.Models;
using GrantAdvance.Infras.Repositories.Interface;

namespace GrantAdvance.Infras.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.User.Add(user);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return  _context.User.FirstOrDefault( x => x.Email.Equals(email));
        }
    }
}
