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
    public class EmployeeTasksController : Controller
    {
        private readonly UserDbContext _context;

        public EmployeeTasksController(UserDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeTasks
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.Tasks.Include(e => e.Project);
            return View(await userDbContext.ToListAsync());
        }

        // GET: EmployeeTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTask = await _context.Tasks
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            return View(employeeTask);
        }

        // GET: EmployeeTasks/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName");
            return View();
        }

        // POST: EmployeeTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Description,ProjectId,StartDate,EndDate,Priority,EmployeeId")] EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName", employeeTask.ProjectId);
            return View(employeeTask);
        }

        // GET: EmployeeTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTask = await _context.Tasks.FindAsync(id);
            if (employeeTask == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName", employeeTask.ProjectId);
            return View(employeeTask);
        }

        // POST: EmployeeTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Description,ProjectId,StartDate,EndDate,Priority,EmployeeId")] EmployeeTask employeeTask)
        {
            if (id != employeeTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTaskExists(employeeTask.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName", employeeTask.ProjectId);
            return View(employeeTask);
        }

        // GET: EmployeeTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTask = await _context.Tasks
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeTask == null)
            {
                return NotFound();
            }

            return View(employeeTask);
        }

        // POST: EmployeeTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTask = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(employeeTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
