using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDzController.Domain.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ExerciseName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ExercisePicture { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ExerciseVideo { get; set; }


    }
}
