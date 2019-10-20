using Blog.Data.Constants;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //Table name
            builder.ToTable(typeof(Article).Name);

            //Primary Key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.Text)
                .HasMaxLength(4000);
            builder.Property(t => t.Title)
                .HasMaxLength(100);

            //Relationships
            builder.HasOne(t => t.Author)
                .WithMany(t => t.Articles)
                .OnDelete(DeleteBehavior.Restrict);

            //Indexes
            builder.HasIndex(t => t.Id);
            builder.HasIndex(t => t.UserId);

            var sb = new StringBuilder();
            sb.Append("In short, a blog is a type of website that focuses mainly on written content");
            sb.Append(", also known as blog posts. In popular culture we most often hear about news blogs or celebrity blog sites,");
            sb.Append(" but as you’ll see in this guide, you can start a successful blog on just about any topic imaginable.");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Bloggers often write from a personal perspective that allows them to connect directly with their readers. ");
            sb.Append("In addition, most blogs also have a “comments” section where readers can correspond with the blogger. ");
            sb.Append("Interacting with your readers in the comments section helps to further the connection between the blogger and the reader.");

            //Seeding
            builder.HasData(
                new Article
                {
                    Id = DataConstants.FirstBlogArticleId,
                    Title = "This Is Your FIrst Blog Post",
                    Text = sb.ToString(),
                    UserId = DataConstants.ContributorUserId,
                    Date = DateTimeOffset.Now
                });
        }
    }
}
