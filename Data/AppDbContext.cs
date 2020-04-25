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

        public DbSet<Log> Logs { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRole>().HasKey(ur => new {ur.UserId, ur.RoleId});
            builder.Entity<UserLog>().HasKey(ul => new {ul.UserId, ul.LogId});
            builder.Entity<UserExercise>().HasKey(ue => new { ue.UserId, ue.ExerciseId });
        }
    }
}