using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article(int id)
        {
            var article = _articleService.GetArticle(id);
            return View(article);
        }
    }
}