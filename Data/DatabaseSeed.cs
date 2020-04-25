using System.Collections.Generic;
using System.Linq;
using EDzController.Domain.Models;
using EDzController.Domain.Security.Hashing;

namespace EDzController.Data
{
    public class DatabaseSeed
    {
        public static void Seed(AppDbContext context, IPasswordHasher passwordHasher)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
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
}