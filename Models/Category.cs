using System.ComponentModel.DataAnnotations;

namespace Blog.Models {

    public class Category{
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
        public virtual ICollection<Article> Articles { get; set; }
    }

}

