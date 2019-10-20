using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Blog.Data.Common;

namespace Blog.Data.Models
{
    public class User : EntityBase<int>
    {
        public User()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            UserRoles = new HashSet<UserRole>();
        }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public HashSet<UserRole> UserRoles { get; set; }
        public HashSet<Article> Articles { get; set; }
        public HashSet<Comment> Comments { get; set; }
    }
}