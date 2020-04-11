using System.Threading.Tasks;
using EDzController.Domain.Models.User;
using EDzController.Domain.Services.Communication;

namespace EDzController.Domain.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}