using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Blog.Data.Common;
using Blog.Data.Models;
using Blog.Infrastructure.Data.Models;
using Blog.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services.Core
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;

        public UserService(IDataContext dataContext, IMapper mapper)
        {
            _userRepository = dataContext.GetRepository<User>();
            _mapper = mapper;
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = GetUser(username);

            if (user == null) return null;

            string hash;

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return user.PasswordHash != hash ? null : user;
        }

        private User GetUser(string username)
        {
            return _userRepository.AsQueryable().FirstOrDefault(x => x.UserName == username);
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            var user = _userRepository.Find(userId);
            return user.UserRoles.Select(x => x.Role);
        }
        public IEnumerable<Role> GetUserRoles(string username)
        {
            var user = _userRepository.AsQueryable()
                .Include(x=>x.UserRoles)
                .ThenInclude(x=>x.Role)
                .FirstOrDefault(x => x.UserName == username);
            return user?.UserRoles.Select(x => x.Role);
        }
    }
}