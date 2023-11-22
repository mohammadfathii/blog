using System.ComponentModel.DataAnnotations;
using Blog.Models;

namespace blog.Models
{
    public class Comment
    {        
        [Key]
        public int Id { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; } = 0;

        public int ArticleId { get; set; }
        public int UserId { get; set; }

        public Article Article { get; set; }
        public User User { get; set; }
    }
}