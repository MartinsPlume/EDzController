using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDzController.Domain.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int UserId { get; set; } 
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string UserEmail { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ShortInstruction { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int ExerciseId { get; set; }
    }
}