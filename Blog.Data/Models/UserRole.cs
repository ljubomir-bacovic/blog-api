using System;
using System.Collections.Generic;
using System.Text;
using Blog.Data.Common.Types;

namespace Blog.Data.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Roles RoleId { get; set; }
        public Role Role { get; set; }
    }
}
