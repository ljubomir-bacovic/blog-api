using Blog.Data.Common.Types;
using Blog.Data.Constants;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            //Table name
            builder.ToTable(typeof(UserRole).Name);

            //Primary Key
            builder.HasKey(t => new {t.UserId, t.RoleId});

            //Properties

            //Relationships
            builder.HasOne(t => t.User)
                .WithMany(t => t.UserRoles);
            builder.HasOne(t => t.Role)
                .WithMany(t => t.UserRoles);

            //Indexes
            builder.HasIndex(t => t.UserId);
            builder.HasIndex(t => t.RoleId);

            //Seeding
            builder.HasData(
                new UserRole
                {
                    UserId = DataConstants.AdminUserId,
                    RoleId = Roles.Admin
                },
                new UserRole
                {
                    UserId = DataConstants.ContributorUserId,
                    RoleId = Roles.Contributor
                },
                new UserRole
                {
                    UserId = DataConstants.RegularUserId,
                    RoleId = Roles.User
                });
        }
    }
}