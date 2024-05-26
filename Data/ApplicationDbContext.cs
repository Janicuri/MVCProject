using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnakeApplication.Models;
namespace SnakeApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}