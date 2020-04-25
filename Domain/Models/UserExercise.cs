using System.ComponentModel.DataAnnotations.Schema;

namespace EDzController.Domain.Models
{
    [Table("UserExercises")]
    public class UserExercise
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ExerciseId { get; set; }

        public Role Exercise { get; set; }
    }
}
