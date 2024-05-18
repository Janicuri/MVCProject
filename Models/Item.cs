using System.ComponentModel.DataAnnotations;

namespace SnakeApplication.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
        public decimal? Price { get; set; }

        public byte[]? ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
