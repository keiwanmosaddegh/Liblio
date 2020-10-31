using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Liblio.Models
{
    public class OneCEOAtATime : ValidationAttribute
    {
        private ApplicationDbContext _context;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _context = new ApplicationDbContext();

            var employee = (Employee)validationContext.ObjectInstance;

            var ceo = _context.Employees.ToList().Find(e => e.IsCEO);

            if (ceo != null && ceo.Id != employee.Id && employee.IsCEO)
            {
                return new ValidationResult("There's already a CEO.");
            }

            _context.Dispose();

            return ValidationResult.Success;
        }
    }
}