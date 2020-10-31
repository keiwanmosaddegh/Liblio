using System.ComponentModel.DataAnnotations;

namespace Liblio.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public decimal? Salary { get; set; }

        [Required]
        public bool? IsCEO { get; set; }

        [Required]
        public bool? IsManager { get; set; }

        public int? ManagerId { get; set; }
    }
}