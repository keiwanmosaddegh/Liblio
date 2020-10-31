using Liblio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liblio.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; }

        [Range(1, 10)]
        public int Rank { get; set; }

        public List<Employee> Managers { get; set; }

        public Employee CEO { get; set; }

    }
}