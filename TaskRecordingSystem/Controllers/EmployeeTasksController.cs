using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskRecordingSystem.Models;

namespace TaskRecordingSystem.Controllers
{
    [Authorize]
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
            var userDbContext = _context.Tasks.Include(e => e.Project).Include(e => e.Employees).Include(e=>e.Priority);
            return View(await userDbContext.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
           // ViewData["GetTaskDetails"] = search;
            List<EmployeeTask> query =  await _context.Tasks.Include(e => e.Project).Include(e => e.Employees).Include(e => e.Priority).ToListAsync(); 
            if (!String.IsNullOrEmpty(search))
            {
                query =  await _context.Tasks.Where(e => e.TaskName.Contains(search)).ToListAsync();

            }
            return View(query);
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
                .Include( e=> e.Employees)
                .Include(e=>e.Priority)
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "PriorityStatus");
            return View();
        }

        // POST: EmployeeTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Description,ProjectId,StartDate,EndDate,PriorityId,EmployeeId")] EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "ProjectName", employeeTask.ProjectId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeTask.EmployeeId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "PriorityStatus", employeeTask.PriorityId);
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeTask.EmployeeId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "PriorityStatus", employeeTask.PriorityId);
            return View(employeeTask);
        }

        // POST: EmployeeTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Description,ProjectId,StartDate,EndDate,PriorityId,EmployeeId")] EmployeeTask employeeTask)
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", employeeTask.EmployeeId);
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "Id", "PriorityStatus", employeeTask.PriorityId);
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
