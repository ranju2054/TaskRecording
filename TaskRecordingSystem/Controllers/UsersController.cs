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
    public class UsersController : Controller
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.Users.Include(u => u.Address).Include(u => u.Department).Include(u => u.Gender).Include(u => u.JobPosition).Include(u => u.MaritalStatus).Include(u => u.UserRole);
            return View(await userDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Department)
                .Include(u => u.Gender)
                .Include(u => u.JobPosition)
                .Include(u => u.MaritalStatus)
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus");
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level");
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status");
            ViewData["UserRoleId"] = new SelectList(_context.UserRoles, "Id", "Role");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,EmailAddress,AddressId,GenderId,DateOfBirth,DateOfJoin,MaritalStatusId,UserRoleId,DepartmentId,JobPositionId")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber", user.AddressId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", user.DepartmentId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus", user.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level", user.JobPositionId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status", user.MaritalStatusId);
            ViewData["UserRoleId"] = new SelectList(_context.UserRoles, "Id", "Role", user.UserRoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber", user.AddressId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", user.DepartmentId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus", user.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level", user.JobPositionId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status", user.MaritalStatusId);
            ViewData["UserRoleId"] = new SelectList(_context.UserRoles, "Id", "Role", user.UserRoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,EmailAddress,AddressId,GenderId,DateOfBirth,DateOfJoin,MaritalStatusId,UserRoleId,DepartmentId,JobPositionId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "ContactNumber", user.AddressId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", user.DepartmentId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderStatus", user.GenderId);
            ViewData["JobPositionId"] = new SelectList(_context.JobPositions, "Id", "Level", user.JobPositionId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Status", user.MaritalStatusId);
            ViewData["UserRoleId"] = new SelectList(_context.UserRoles, "Id", "Role", user.UserRoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Department)
                .Include(u => u.Gender)
                .Include(u => u.JobPosition)
                .Include(u => u.MaritalStatus)
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
