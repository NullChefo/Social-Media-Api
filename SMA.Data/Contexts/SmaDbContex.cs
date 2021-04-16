namespace SMA.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class SMAContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Like> Likes { get; set; }

        public SMAContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Nlear;User Id=applogin;Password=1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            
        }
    }
}