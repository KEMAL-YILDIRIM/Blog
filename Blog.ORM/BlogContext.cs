using Blog.ORM.Models;

using Microsoft.EntityFrameworkCore;

namespace Blog.ORM
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {

        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Post>();

            modelBuilder.Entity<Post>()
                .HasOne<User>()
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.Author);
        }
    }
}
