using System.Collections.Generic;
using System.Linq;
using Blog.Data.Common.Types;
using Blog.Data.Constants;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Table name
            builder.ToTable(typeof(User).Name);

            //Primary key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(t => t.PasswordHash)
                .IsRequired();

            //Relationships
            builder.HasMany(t=>t.UserRoles)
                .WithOne(t=>t.User);

            //Indexes
            builder.HasIndex(t => t.Id);

            //Seeding
            builder.HasData(
                new User
                {
                    Id = DataConstants.AdminUserId,
                    UserName = "admin",
                    PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                    Email = "admin@blog.test"
                },
                new User
                {
                    Id = DataConstants.ContributorUserId,
                    UserName = "contributor",
                    PasswordHash = "7ee8a8789d5be8d2be3b35505ab433d8e7ab18a25ad4abf066a47b0bd86ce851",
                    Email = "contributor@blog.test"
                },
                new User
                {
                    Id = DataConstants.RegularUserId,
                    UserName = "user",
                    PasswordHash = "04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb",
                    Email = "user@blog.test"
                });
        }
    }
}
