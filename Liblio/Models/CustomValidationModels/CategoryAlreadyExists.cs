using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Liblio.Models
{
    public class CategoryAlreadyExists : ValidationAttribute
    {
        private ApplicationDbContext _context;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _context = new ApplicationDbContext();

            var category = (Category)validationContext.ObjectInstance;

            if (_context.Categories.ToList().Exists(c => c.CategoryName.Equals(category.CategoryName)))
            {
                return new ValidationResult("Category Already Exists.");
            }

            _context.Dispose();

            return ValidationResult.Success;
        }
    }
}