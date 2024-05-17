using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace SnakeApplication.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        [StringLength(50)]

        public string Name { get; set; }
        [StringLength(15)]
        public string Color { get; set; }   
        public int Score { get; set; }  

        public string IdentityUserId { get; set; }  
        public virtual IdentityUser User { get; set; }
    }
}
