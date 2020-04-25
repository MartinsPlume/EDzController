using System.ComponentModel.DataAnnotations.Schema;

namespace EDzController.Domain.Models
{
    [Table("UserLogs")]
    public class UserLog
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int LogId { get; set; }

        public Log Log { get; set; }
    }
}