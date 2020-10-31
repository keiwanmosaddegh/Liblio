using System.ComponentModel.DataAnnotations;

namespace Liblio.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [OneCEOAtATime]
        public bool IsCEO { get; set; }

        [Required]
        public bool IsManager { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }
    }
}