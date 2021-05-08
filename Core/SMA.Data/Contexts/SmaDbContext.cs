using Microsoft.EntityFrameworkCore;
using SMA.Data.Entities;

namespace SMA.Data.Contexts
{
   
    public class SmaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Notification> Notifications {get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Image> Images { get; set; }

        public SmaDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlServer("Server=localhost;Database=SocialMediaApplication;User Id=applogin;Password=1234;"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            
            modelBuilder.Entity<Post>().ToTable("Post");
            
            modelBuilder.Entity<Notification>().ToTable("Notification");
            
            modelBuilder.Entity<Like>().ToTable("Like");
            
            modelBuilder.Entity<Image>().ToTable("Image");

            
            
            
        }
    }
}