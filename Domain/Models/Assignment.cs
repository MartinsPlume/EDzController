using System.ComponentModel.DataAnnotations;

namespace EDzController.Domain.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public User User { get; set; }
        
        [Required]
        public string ShortInstruction { get; set; }
        
        [Required]
        public Exercise Exercise { get; set; }
    }
}