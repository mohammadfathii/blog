using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class User {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        public bool IsAdmin { get; set; } = false;
        public DateTime RegisterTime { get; set; } = DateTime.Now;
    }
}
