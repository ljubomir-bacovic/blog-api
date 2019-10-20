using System;
using System.Collections.Generic;

namespace Blog.Data.Models
{
    public class Article : EntityBase<int>
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        public int UserId { get; set; }
        public User Author { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public HashSet<Comment> Comments { get; set; }
    }
}