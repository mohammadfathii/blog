using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{

    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string ImageURL { get; set; }

        public bool IsVerified { get; set; } = false;

        public int Views { get; set; } = 0;

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

    }

}