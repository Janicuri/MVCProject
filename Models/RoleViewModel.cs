using System.ComponentModel.DataAnnotations;
namespace SnakeApplication.Models
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string  ? Name { get; set; }
    }
}
