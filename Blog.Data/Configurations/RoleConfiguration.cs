using System.Collections.Generic;
using Blog.Data.Common.Types;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {           
            //Table name
            builder.ToTable(typeof(Role).Name);

            //Primary Key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.Name)
                .HasMaxLength(20);

            //Relationships
            builder.HasMany(t => t.UserRoles)
                .WithOne(t=>t.Role);

            //Indexes
            builder.HasIndex(t => t.Id);

            //Seeding
            builder.HasData(
                new Role
                {
                    Id = Roles.Admin,
                    Name = "Admin"
                },
                new Role
                {
                    Id = Roles.Contributor,
                    Name = "Contributor"
                },
                new Role
                {
                    Id = Roles.User,
                    Name = "User"
                });
        }
    }
}