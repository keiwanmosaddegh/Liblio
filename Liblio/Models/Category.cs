using System.ComponentModel.DataAnnotations;

namespace Liblio.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Category")]
        [CategoryAlreadyExists]
        public string CategoryName { get; set; }
    }
}