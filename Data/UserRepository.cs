using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDzController.Domain.Models;
using EDzController.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EDzController.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, IEnumerable<ERole> userRoles)
        {
            var roleNames = userRoles.Select(r => r.ToString()).ToList();
            var roles = await _context.Roles.Where(r => roleNames.Contains(r.Name)).ToListAsync();

            foreach (var role in roles) user.UserRoles.Add(new UserRole {RoleId = role.Id});

            _context.Users.Add(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public IQueryable<object> GetUsers()
        {
            IQueryable<object> users = _context.Users
                .Select(u => new
                {
                    u.Id, u.Email, UserRole = u.UserRoles.Select(role => role.Role.Name).FirstOrDefault()
                });

            return users;
        }
    }
}