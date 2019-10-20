using Blog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.Infrastructure
{
    public interface IArticleService
    {
        void CreateArticle(string title, string text, int userId);
        void UpdateArticle(int articleId, string title, string text);
        IEnumerable<ArticleModel> GetAllArticles();
        ArticleDetailsModel GetArticle(int id);
    }
}
