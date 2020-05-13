using EDzController.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EDzController.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Exercise> Exercises { get; set; }
        
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRole>().HasKey(ur => new {ur.UserId, ur.RoleId});
            builder.Entity<User>()
                .HasMany(u => u.Assignments)
                .WithOne(user => user.User);
            builder.Entity<Exercise>()
                .HasMany(u => u.Assignments)
                .WithOne(exercise => exercise.Exercise);
        }
    }
}