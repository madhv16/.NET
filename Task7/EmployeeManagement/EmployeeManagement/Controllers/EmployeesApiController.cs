using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public EmployeesApiController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
            => await _db.Employees.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var e = await _db.Employees.FindAsync(id);
            if (e == null) return NotFound();
            return e;
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
            try { await _db.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Employees.AnyAsync(x => x.Id == id)) return NotFound();
                throw;
            }
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
