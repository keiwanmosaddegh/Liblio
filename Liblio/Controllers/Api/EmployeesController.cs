using AutoMapper;
using Liblio.Dtos;
using Liblio.Models;
using System.Linq;
using System.Web.Http;

namespace Liblio.Controllers
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/employees
        public IHttpActionResult GetEmployees()
        {
            var employeesQuery = _context.Employees
                .ToList()
                .Select(Mapper.Map<Employee, EmployeeDto>);

            return Ok(employeesQuery);
        }
        // GET /api/employee/1
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Employee, EmployeeDto>(employee));
        }
        /*

                // POST /api/customers
                [HttpPost]
                public IHttpActionResult CreateCustomer(EmployeeDto customerDto)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    var customer = Mapper.Map<EmployeeDto, Employee>(customerDto);

                    _context.Customers.Add(customer);
                    _context.SaveChanges();

                    customerDto.Id = customer.Id;

                    return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
                }

                // PUT /api/customers/1
                [HttpPut]
                public IHttpActionResult UpdateCustomer(int id, EmployeeDto customerDto)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                    if (customerInDb == null)
                    {
                        return NotFound();
                    }

                    Mapper.Map(customerDto, customerInDb);

                    _context.SaveChanges();

                    return Ok();
                }
        */

        // DELETE /api/employee/1
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var customerInDb = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            var managing = _context.Employees.Where(e => e.ManagerId == id).ToList();

            if (managing.Count > 0)
            {
                return BadRequest();
            }

            _context.Employees.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }

}
