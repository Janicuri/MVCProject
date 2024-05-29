using System.ComponentModel.DataAnnotations;

namespace SnakeApplication.Models
{
    public class games
    {
        [Key]
        public string ?Title { get; set; }
        public DateTime StartTime { get; set; }
    }
}
