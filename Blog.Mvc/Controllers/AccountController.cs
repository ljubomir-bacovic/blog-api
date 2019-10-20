using System.Linq;
using Blog.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IArticleService articleService)
        {
            _userService = userService;
            _articleService = articleService;
        }

        public IActionResult Authenticate(string username, string password)
        {
            var user = _userService.AuthenticateUser(username, password);
            if (user != null)
            {
                return View(@"../Home/Index", _articleService.GetAllArticles().ToList());
            }

            return View(@"../Home/Login");
        }
    }
}