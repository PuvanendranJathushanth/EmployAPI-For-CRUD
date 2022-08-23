using EmployAPI.Data;
using EmployAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeesController : Controller
    {
        private readonly DataDbContext _dataDbContext;

        public EmployeesController(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _dataDbContext.Employees.ToListAsync();
            
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await _dataDbContext.Employees.AddAsync(employeeRequest);
            await _dataDbContext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _dataDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> updateEmployee([FromRoute] Guid id, Employee updateEmployee)
        {
            var employee = await _dataDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployee.Name;
            employee.Email = updateEmployee.Email;
            employee.PhoneNumber = updateEmployee.PhoneNumber;

            await _dataDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _dataDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            _dataDbContext.Employees.Remove(employee);

            await _dataDbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
