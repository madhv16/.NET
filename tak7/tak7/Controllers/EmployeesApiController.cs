using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.Data;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        public EmployeesApiController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get() =>
            await _db.Employees.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var emp = await _db.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            return emp;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            _db.Entry(employee).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _db.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
