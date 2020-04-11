using System.Collections.Generic;
using System.Threading.Tasks;
using EDzController.Domain.Models.User;

namespace EDzController.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, IEnumerable<ERole> userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}