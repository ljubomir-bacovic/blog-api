using Blog.Data.Constants;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //Table name
            builder.ToTable(typeof(Comment).Name);

            //Primary Key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.Text)
                .HasMaxLength(2000);

            //Relationships
            builder.HasOne(t => t.Author)
                .WithMany(t => t.Comments)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Article)
                .WithMany(t => t.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            //Indexes
            builder.HasIndex(t => t.Id);
            builder.HasIndex(t => t.UserId);
            builder.HasIndex(t => t.ArticleId);

            //Seeding
            builder.HasData(
                new Comment
                {
                    Id = DataConstants.FirstBlogCommentId,
                    ArticleId = DataConstants.FirstBlogArticleId,
                    Text = "This is a very nice insight. Thank you.",
                    UserId = DataConstants.RegularUserId,
                    Date = DateTimeOffset.Now
                });
        }
    }
}
