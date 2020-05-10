using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EDzController.Domain.Models
{
    public class Log
    {
        public int Id { get; set; }

        public string UserInfo { get; set; }

        public ICollection<UserLog> UsersLog { get; set; } = new Collection<UserLog>();
    }
}