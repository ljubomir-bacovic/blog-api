using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Models
{
    public class Comment : EntityBase<int>
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int UserId { get; set; }
        public User Author { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Text { get; set; }
    }
}
