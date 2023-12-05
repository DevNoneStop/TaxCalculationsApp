using EmployeeTaxCal.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaxCal.API.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees() //get all employees
        { 
            try
            {
                var emp = await _context.Employees.ToListAsync();
                if (emp.Count == 0)
                {
                    return NotFound("No employees available");
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
     
        [HttpGet("{EmployeeId}")]
        public async Task<IActionResult> GetById(int employeeId) //Getting an employee by Id
        {
            try
            {
                var emp = await _context.Employees.FindAsync(employeeId);
                if (emp == null)
                {
                    return BadRequest($"employee not found with ID {emp.EmployeeId}");
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)  //Creating an employee
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee) //Updating an employee
        {
            if (employee == null || employee.EmployeeId == 0)
            {
                if (employee == null)
                {
                    return BadRequest("employee data is invalid");
                }
                else if (employee.EmployeeId == 0)
                {
                    return BadRequest($"employee id is {employee.EmployeeId} invalid");
                }
            }

            try
            {
                var emp = await _context.Employees.FindAsync(employee.EmployeeId);
                if (emp == null)
                {
                    return BadRequest($"employee not found with ID {employee.EmployeeId}");
                }

                emp.Name = employee.Name;
                emp.PostalCode = employee.PostalCode;
                emp.Income = employee.Income;

                await _context.SaveChangesAsync();

                return Ok("Employee details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> Delete(int employeeId) //Deleting an employee
        {
            try
            {
                var emp = await _context.Employees.FindAsync(employeeId);
                if (emp == null)
                {
                    return BadRequest($"employee not found with ID {employeeId}");
                }
               _context.Employees.Remove(emp);
               _context.SaveChanges();
                return Ok("Employee deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
    }
}
