namespace EDzController.Domain.Models
{
    public class AssignmentInfo
    {
        public int Id { get; set; }
        
        public string ShortInstruction { get; set; }
        
        public int UserId { get; set; }
        
        public string UserEmail { get; set; }
        
        public int ExerciseId { get; set; }
    }
}