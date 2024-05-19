using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SnakeApplication.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public virtual Item item { get; set; }
        public int PlayerId { get; set; }
        public virtual Player player { get; set; }
    }
}
