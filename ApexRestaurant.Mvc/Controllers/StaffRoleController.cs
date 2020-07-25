using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApexRestaurant.Mvc.Data;
using ApexRestaurant.Mvc.Models;

namespace ApexRestaurant.Mvc.Controllers
{
    public class StaffRoleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffRoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffRoles.ToListAsync());
        }

        // GET: StaffRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRoles = await _context.StaffRoles
                .FirstOrDefaultAsync(m => m.StaffRolesId == id);
            if (staffRoles == null)
            {
                return NotFound();
            }

            return View(staffRoles);
        }

        // GET: StaffRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffRolesId,StaffRolesDescription,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] StaffRoles staffRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffRoles);
        }

        // GET: StaffRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRoles = await _context.StaffRoles.FindAsync(id);
            if (staffRoles == null)
            {
                return NotFound();
            }
            return View(staffRoles);
        }

        // POST: StaffRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffRolesId,StaffRolesDescription,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] StaffRoles staffRoles)
        {
            if (id != staffRoles.StaffRolesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffRolesExists(staffRoles.StaffRolesId))
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
            return View(staffRoles);
        }

        // GET: StaffRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRoles = await _context.StaffRoles
                .FirstOrDefaultAsync(m => m.StaffRolesId == id);
            if (staffRoles == null)
            {
                return NotFound();
            }

            return View(staffRoles);
        }

        // POST: StaffRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffRoles = await _context.StaffRoles.FindAsync(id);
            _context.StaffRoles.Remove(staffRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffRolesExists(int id)
        {
            return _context.StaffRoles.Any(e => e.StaffRolesId == id);
        }
    }
}
