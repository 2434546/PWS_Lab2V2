using ForumDeDiscussion.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumDeDiscussion.Data.Context
{
    public class ForumDeDiscussionDbContext : DbContext
    {
        public ForumDeDiscussionDbContext(DbContextOptions<ForumDeDiscussionDbContext> options) : base(options)
        {
        }

        public DbSet<Section> sections { get; set; }

        public DbSet<Sujet> sujets { get; set; }

        public DbSet<Message> messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
