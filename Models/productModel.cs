using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DMART.Models
{
    public class productModel: Product
    {

        [Required(ErrorMessage = "Image is required")]
        public IFormFile Image { get; set; }
    }
}
