using GrantAdvance.Domain.Models;

namespace GrantAdvance.Domain.ViewModel
{
    public class UserResponseViewModel : BaseResponse
    {
        public User? User { get; private set; }

        public UserResponseViewModel(bool success, string? message, User? user) : base(success, message)
        {
            User = user;
        }
    }
}
