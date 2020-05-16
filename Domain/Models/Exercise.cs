using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDzController.Domain.Models
{
    public class Exercise
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ExerciseName { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        public bool HasVideo { get; set; }
                
        public string InstructionVideo { get; set; }
        
        public ICollection<Assignment> Assignments { get; set; }
    }
}
