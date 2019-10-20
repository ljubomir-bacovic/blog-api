using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Data.Models
{
    public class ArticleDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Author { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
