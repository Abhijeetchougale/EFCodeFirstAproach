using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ProductAndCategory.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Required(ErrorMessage ="Ctegory Id is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Ctegory Name is required")]
         public string CategoryName { get; set; }

    }
}