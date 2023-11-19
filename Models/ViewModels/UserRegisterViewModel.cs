using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Blog.Models.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}