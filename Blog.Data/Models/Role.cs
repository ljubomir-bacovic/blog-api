using System.Collections.Generic;
using Blog.Data.Common.Types;

namespace Blog.Data.Models
{
    public class Role : EntityBase<Roles>
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public string Name { get; set; }
        public HashSet<UserRole> UserRoles { get; set; }
    }
}