using Liblio.Models;
using Liblio.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Liblio.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new EmployeeFormViewModel
            {
                Employee = new Employee(),
                Managers = _context.Employees.Where(e => e.IsManager).ToList(),
                CEO = _context.Employees.ToList().Find(e => e.IsCEO)
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EmployeeFormViewModel employeeFormViewModel)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeFormViewModel
                {
                    Employee = employeeFormViewModel.Employee,
                    Managers = _context.Employees.Where(e => e.IsManager).ToList(),
                    CEO = _context.Employees.ToList().Find(e => e.IsCEO)
                };

                return View("EmployeeForm", viewModel);
            }

            if (employeeFormViewModel.Employee.Id == 0)
            {
                employeeFormViewModel.Employee.Salary = RankToSalary(employeeFormViewModel);

                _context.Employees.Add(employeeFormViewModel.Employee);

            }
            else
            {
                var employeeInDb = _context.Employees.Single(e => e.Id == employeeFormViewModel.Employee.Id);

                employeeInDb.FirstName = employeeFormViewModel.Employee.FirstName;
                employeeInDb.LastName = employeeFormViewModel.Employee.LastName;
                employeeInDb.Salary = RankToSalary(employeeFormViewModel);
                employeeInDb.IsCEO = employeeFormViewModel.Employee.IsCEO;
                employeeInDb.IsManager = employeeFormViewModel.Employee.IsManager;
                employeeInDb.ManagerId = employeeFormViewModel.Employee.ManagerId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Rank = SalaryToRank(employee),
                Managers = _context.Employees.Where(e => e.IsManager).ToList(),
                CEO = _context.Employees.ToList().Find(e => e.IsCEO)
            };

            return View("EmployeeForm", viewModel);
        }

        private static int SalaryToRank(Employee employee)
        {
            return (int)Math.Round((
                employee.IsCEO
                ? Decimal.Divide(employee.Salary, Convert.ToDecimal(2.725))
                : employee.IsManager
                ? Decimal.Divide(employee.Salary, Convert.ToDecimal(1.725))

                : Decimal.Divide(employee.Salary, Convert.ToDecimal(1.125))
                ), 0, MidpointRounding.AwayFromZero);
        }

        private static decimal RankToSalary(EmployeeFormViewModel employeeFormViewModel)
        {
            if (employeeFormViewModel.Employee.IsCEO)
            {
                return employeeFormViewModel.Employee.Salary = employeeFormViewModel.Rank * Convert.ToDecimal(2.725);
            }
            else if (employeeFormViewModel.Employee.IsManager)
            {
                return employeeFormViewModel.Employee.Salary = employeeFormViewModel.Rank * Convert.ToDecimal(1.725);
            }
            else
            {
                return employeeFormViewModel.Employee.Salary = employeeFormViewModel.Rank * Convert.ToDecimal(1.125);
            }
        }
    }
}