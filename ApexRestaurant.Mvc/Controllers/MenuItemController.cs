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
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuItemViewModel.ToListAsync());
        }

        // GET: MenuItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItemViewModel = await _context.MenuItemViewModel
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuItemViewModel == null)
            {
                return NotFound();
            }

            return View(menuItemViewModel);
        }

        // GET: MenuItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuItemId,MenuId,Menu_Items_Name,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MenuItemViewModel menuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuItemViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuItemViewModel);
        }

        // GET: MenuItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItemViewModel = await _context.MenuItemViewModel.FindAsync(id);
            if (menuItemViewModel == null)
            {
                return NotFound();
            }
            return View(menuItemViewModel);
        }

        // POST: MenuItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuItemId,MenuId,Menu_Items_Name,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MenuItemViewModel menuItemViewModel)
        {
            if (id != menuItemViewModel.MenuItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItemViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemViewModelExists(menuItemViewModel.MenuItemId))
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
            return View(menuItemViewModel);
        }

        // GET: MenuItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItemViewModel = await _context.MenuItemViewModel
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuItemViewModel == null)
            {
                return NotFound();
            }

            return View(menuItemViewModel);
        }

        // POST: MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuItemViewModel = await _context.MenuItemViewModel.FindAsync(id);
            _context.MenuItemViewModel.Remove(menuItemViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemViewModelExists(int id)
        {
            return _context.MenuItemViewModel.Any(e => e.MenuItemId == id);
        }
    }
}
