using System.Collections;
using System.Collections.Generic;
using Blog.Data.Models;
using Blog.Infrastructure.Data.Models;

namespace Blog.Services.Infrastructure
{
    public interface IUserService
    {
        User AuthenticateUser(string username, string password);
        IEnumerable<Role> GetUserRoles(int userId);
        IEnumerable<Role> GetUserRoles(string username);
    }
}