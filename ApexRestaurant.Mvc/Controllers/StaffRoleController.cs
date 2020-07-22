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
            return View(await _context.StaffRoleViewModel.ToListAsync());
        }

        // GET: StaffRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRoleViewModel = await _context.StaffRoleViewModel
                .FirstOrDefaultAsync(m => m.Staff_Roles_Id == id);
            if (staffRoleViewModel == null)
            {
                return NotFound();
            }

            return View(staffRoleViewModel);
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
        public async Task<IActionResult> Create([Bind("Staff_Roles_Id,Staff_Roles_Description,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] StaffRoleViewModel staffRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffRoleViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffRoleViewModel);
        }

        // GET: StaffRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRoleViewModel = await _context.StaffRoleViewModel.FindAsync(id);
            if (staffRoleViewModel == null)
            {
                return NotFound();
            }
            return View(staffRoleViewModel);
        }

        // POST: StaffRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Staff_Roles_Id,Staff_Roles_Description,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] StaffRoleViewModel staffRoleViewModel)
        {
            if (id != staffRoleViewModel.Staff_Roles_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffRoleViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffRoleViewModelExists(staffRoleViewModel.Staff_Roles_Id))
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
            return View(staffRoleViewModel);
        }

        // GET: StaffRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRoleViewModel = await _context.StaffRoleViewModel
                .FirstOrDefaultAsync(m => m.Staff_Roles_Id == id);
            if (staffRoleViewModel == null)
            {
                return NotFound();
            }

            return View(staffRoleViewModel);
        }

        // POST: StaffRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffRoleViewModel = await _context.StaffRoleViewModel.FindAsync(id);
            _context.StaffRoleViewModel.Remove(staffRoleViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffRoleViewModelExists(int id)
        {
            return _context.StaffRoleViewModel.Any(e => e.Staff_Roles_Id == id);
        }
    }
}
