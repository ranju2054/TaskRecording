using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskRecordingSystem.Models;

namespace TaskRecordingSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserDbContext _context;

        public EmployeesController(UserDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.Employees.Include(e => e.Address).Include(e => e.Department).Include(e => e.Gender).Include(e => e.JobPosition).Include(e => e.MaritalStatus);
            return View(await userDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Address)
                .Include(e => e.Department)
                .Include(e => e.Gender)
                .Include(e => e.JobPosition)
                .Include(e => e.MaritalStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus");
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level");
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AddressId,GenderId,DateOfBirth,DateOfJoin,MaritalStatusId,DepartmentId,JobPositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber", employee.AddressId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus", employee.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level", employee.JobPositionId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status", employee.MaritalStatusId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber", employee.AddressId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus", employee.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level", employee.JobPositionId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status", employee.MaritalStatusId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AddressId,GenderId,DateOfBirth,DateOfJoin,MaritalStatusId,DepartmentId,JobPositionId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber", employee.AddressId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus", employee.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level", employee.JobPositionId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status", employee.MaritalStatusId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Address)
                .Include(e => e.Department)
                .Include(e => e.Gender)
                .Include(e => e.JobPosition)
                .Include(e => e.MaritalStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
