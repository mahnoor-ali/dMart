using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMART.Models
{
    public class Product: FullAuditModel       
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Must be between 5 and 20 characters", MinimumLength = 5)]
        public string Name { get; set; }
        
        
        [StringLength(50, ErrorMessage = "Must be between 10 and 50 characters", MinimumLength = 10)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Price")]
        public int Price { get; set; }        
        
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "Image is required")]
        public String ImageUrl { get; set; }
        
        [Required(ErrorMessage = "Category Id is required")]
        [Range(0, int.MaxValue)]
        public int CategoryId { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid discount")]
        public int Discount { get; set; }
        
        [Range(0, 90, ErrorMessage = "Please enter valid Price")]
        public int DiscountPercentage { get; set; }
        
    }
}
