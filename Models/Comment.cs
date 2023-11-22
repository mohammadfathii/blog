using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models;

namespace blog.Models
{
    public class Comment
    {        
        [Key]
        public int Id { get; set; }
        public bool IsVerfiy { get; set; } = false;
        public string Body { get; set; }
        public int Likes { get; set; } = 0;

        [NotMapped]
        public int ArticleId { get; set; }
        [NotMapped]
        public int UserId { get; set; }
        [NotMapped]
        public Article Article { get; set; }
        [NotMapped]
        public User User { get; set; }
    }
}