using AutoMapper;
using Blog.Data.Models;
using Blog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Data.Profiles
{
    class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }        
    }
}
