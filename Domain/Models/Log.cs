using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EDzController.Domain.Models
{
    public class Log
    {
        public int Id { get; set; }

        [Required] public DateTime? LastLoginDateTime { get; set; }

        public ICollection<UserLog> UsersLog { get; set; } = new Collection<UserLog>();
    }
}