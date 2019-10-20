using AutoMapper;
using Blog.Data.Models;
using Blog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Data.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));

            CreateMap<Article, ArticleDetailsModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments));
        }
    }
}
