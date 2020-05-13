using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDzController.Domain.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ExerciseName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        
        public ICollection<Assignment> Assignments { get; set; }
    }
}
