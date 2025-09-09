using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.Data;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.Controllers
{
    [Authorize] // Require login for all actions
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        public EmployeesController(AppDbContext db) => _db = db;

        // Admin and Manager can view list
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Index()
            => View(await _db.Employees.ToListAsync());

        // Admin and Manager can create
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _db.Add(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Admin and Manager can edit
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _db.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            if (!ModelState.IsValid) return View(employee);
            _db.Update(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Only Admin can delete
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _db.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _db.Employees.FindAsync(id);
            if (emp != null) _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Admin, Manager, and Employee can view details
        [Authorize(Roles = "Admin,Manager,Employee")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _db.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            return View(emp);
        }
    }
}
