using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMART.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Must be between 4 to 20 characters", MinimumLength = 4)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
