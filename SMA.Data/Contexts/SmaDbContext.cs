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
            //Set Env variable to connect to SQL server
            //Exm:Server=IP;Database=NameOfTheDataBase;User Id=exampleUserName;Password=examplePassword;
            var SqlCredidentials = System.Environment.GetEnvironmentVariable("SqlCredidentials");
            optionsBuilder.UseSqlServer(SqlCredidentials); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            
        }
    }
}