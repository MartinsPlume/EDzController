﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDzController.Domain.Models;

namespace EDzController.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, IEnumerable<ERole> userRoles);

        Task<User> FindByEmailAsync(string email);

        public IQueryable<object> GetUsers();
    }
}