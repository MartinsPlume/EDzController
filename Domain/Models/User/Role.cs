﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EDzController.Domain.Models.User
{
    public class Role
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        public ICollection<UserRole> UsersRole { get; set;} = new Collection<UserRole>();
    }
}