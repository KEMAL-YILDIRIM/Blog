using Blog.ORM.Models;

using Microsoft.EntityFrameworkCore;

namespace Blog.ORM
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
