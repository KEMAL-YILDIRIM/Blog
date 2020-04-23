using Blog.ORM.Models;

using Microsoft.EntityFrameworkCore;

namespace Blog.ORM.Context
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

        public DbSet<Entry> Entries { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Entry>();

            modelBuilder.Entity<Entry>()
                .HasOne<User>()
                .WithMany(u => u.Entries)
                .HasForeignKey(p => p.Author);
        }
    }
}
