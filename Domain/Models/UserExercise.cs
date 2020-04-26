using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDzController.Domain.Models
{
    [Table("UserExercises")]
    public class UserExercise
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }
    }
}
