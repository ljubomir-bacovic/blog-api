using Blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BlogContext>();
            var connectionString = "Server=DESKTOP-MQB4EOM;Database=Blog;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
            return new BlogContext(builder.Options);
        }
    }
}
