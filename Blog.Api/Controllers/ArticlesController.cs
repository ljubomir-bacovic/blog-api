using System;
using System.Linq;
using Blog.Data.Models;
using Blog.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Basic")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetArticle(int id)
        {
            var article = _articleService.GetArticle(id);
            return Ok(article);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllArticles()
        {
            var articles = _articleService.GetAllArticles();
            return Ok(articles);
        }

        [HttpPost]
        [Authorize(Roles = "Contributor,Admin")]
        public IActionResult CreateArticle(string title, string text)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault()?.Value);
            _articleService.CreateArticle(title, text, userId);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Contributor,Admin")]
        public IActionResult UpdateArticle(int id, string title, string text)
        {
            _articleService.UpdateArticle(id, title, text);
            return Ok();
        }
    }
}