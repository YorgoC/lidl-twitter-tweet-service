using lidl_twitter_tweet_service.Models;
using Microsoft.EntityFrameworkCore;

namespace lidl_twitter_tweet_service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<LidlTweet> Tweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(p => p.Tweets)
                .WithOne(p => p.User!)
                .HasForeignKey(p => p.Id);

            modelBuilder
                .Entity<LidlTweet>()
                .HasOne(p => p.User)
                .WithMany(p => p.Tweets)
                .HasForeignKey(p => p.UserId);
        }
    }
}