using Microsoft.AspNetCore.Identity;

namespace Blog.Infrastructure.Data.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}