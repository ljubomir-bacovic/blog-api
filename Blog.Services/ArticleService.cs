using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.Data.Common;
using Blog.Data.Models;
using Blog.Infrastructure.Data.Models;
using Blog.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services.Core
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public ArticleService(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _articleRepository = dataContext.GetRepository<Article>();
            _mapper = mapper;
        }

        public void CreateArticle(string title, string text, int userId)
        {
            _articleRepository.AddOrUpdate(new Article
            {
                Title = title,
                Text = text,
                UserId = userId,
                Date = DateTimeOffset.Now
            });
            _dataContext.SaveChanges();
        }

        public void UpdateArticle(int articleId, string title, string text)
        {
            var article = _articleRepository.Find(articleId);
            article.Title = title;
            article.Text = text;
            _articleRepository.AddOrUpdate(article);
            _dataContext.SaveChanges();
        }

        public IEnumerable<ArticleModel> GetAllArticles()
        {
            var articles = _articleRepository.AsQueryable().Include(x => x.Author).ToList();
            var articleModels = _mapper.Map<List<ArticleModel>>(articles);
            return articleModels;
        }

        public ArticleDetailsModel GetArticle(int id)
        {
            var artMod = new ArticleDetailsModel();
            var article = _articleRepository.AsQueryable().Include(x => x.Comments).ThenInclude(y => y.Author)
                .FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ArticleDetailsModel>(article);
        }
    }
}