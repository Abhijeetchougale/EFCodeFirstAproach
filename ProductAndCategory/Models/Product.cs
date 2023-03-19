using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ProductAndCategory.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}