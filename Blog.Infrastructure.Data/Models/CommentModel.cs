using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Data.Models
{
    public class CommentModel
    {
        public string Author { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Text { get; set; }
    }
}
