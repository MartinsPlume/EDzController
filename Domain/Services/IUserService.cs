using System.Collections.Generic;
using EDzController.Domain.Models;
using EDzController.Domain.Services.Communication;
using System.Threading.Tasks;

namespace EDzController.Domain.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);

        Task<User> FindByEmailAsync(string email);
        IEnumerable<UserInfo> GetStudents();
    }
}