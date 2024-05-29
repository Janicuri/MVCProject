using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SnakeApplication.Models;
namespace SnakeApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<games> Games { get; set; } // DbSet for GameModel
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the primary key for GameModel
            modelBuilder.Entity<games>()
                .HasKey(g => g.Title); // Use Title as primary key
        }
    }
}