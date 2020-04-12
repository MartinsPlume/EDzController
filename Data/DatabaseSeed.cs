using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDzController.Domain.Models.User;
using EDzController.Domain.Security.Hashing;

namespace EDzController.Data
{
    public class DatabaseSeed
    {

        public static void Seed(AppDbContext context, IPasswordHasher passwordHasher)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any()) return;
            var roles = new List<Role>
            {
                new Role {Name = ERole.Student.ToString()},
                new Role {Name = ERole.Teacher.ToString()},
                new Role {Name = ERole.Administrator.ToString()}
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}