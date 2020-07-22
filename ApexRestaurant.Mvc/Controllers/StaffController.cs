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
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffViewModel.ToListAsync());
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffViewModel = await _context.StaffViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffViewModel == null)
            {
                return NotFound();
            }

            return View(staffViewModel);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Staff_Role_Id,FirstName,LastName,Address,PhoneRes,PhoneMob,EnrollDate,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] StaffViewModel staffViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffViewModel);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffViewModel = await _context.StaffViewModel.FindAsync(id);
            if (staffViewModel == null)
            {
                return NotFound();
            }
            return View(staffViewModel);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Staff_Role_Id,FirstName,LastName,Address,PhoneRes,PhoneMob,EnrollDate,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] StaffViewModel staffViewModel)
        {
            if (id != staffViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffViewModelExists(staffViewModel.Id))
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
            return View(staffViewModel);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffViewModel = await _context.StaffViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffViewModel == null)
            {
                return NotFound();
            }

            return View(staffViewModel);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffViewModel = await _context.StaffViewModel.FindAsync(id);
            _context.StaffViewModel.Remove(staffViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffViewModelExists(int id)
        {
            return _context.StaffViewModel.Any(e => e.Id == id);
        }
    }
}
