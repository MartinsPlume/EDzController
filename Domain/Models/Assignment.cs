using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDzController.Domain.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        
        public User User { get; set; } 
        
        [Column(TypeName = "nvarchar(100)")]
        public string ShortInstruction { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public Exercise Exercise { get; set; }
    }
}