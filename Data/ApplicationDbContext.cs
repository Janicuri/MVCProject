using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnakeApplication.Models;
namespace SnakeApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Player> players { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}