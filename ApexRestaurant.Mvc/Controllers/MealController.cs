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
    public class MealController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Meal
        public async Task<IActionResult> Index()
        {
            return View(await _context.MealViewModel.ToListAsync());
        }

        // GET: Meal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealViewModel = await _context.MealViewModel
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (mealViewModel == null)
            {
                return NotFound();
            }

            return View(mealViewModel);
        }

        // GET: Meal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealId,StaffId,CustomerId,Date_of_Meal,Cost_of_Meal,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MealViewModel mealViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealViewModel);
        }

        // GET: Meal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealViewModel = await _context.MealViewModel.FindAsync(id);
            if (mealViewModel == null)
            {
                return NotFound();
            }
            return View(mealViewModel);
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealId,StaffId,CustomerId,Date_of_Meal,Cost_of_Meal,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MealViewModel mealViewModel)
        {
            if (id != mealViewModel.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealViewModelExists(mealViewModel.MealId))
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
            return View(mealViewModel);
        }

        // GET: Meal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealViewModel = await _context.MealViewModel
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (mealViewModel == null)
            {
                return NotFound();
            }

            return View(mealViewModel);
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealViewModel = await _context.MealViewModel.FindAsync(id);
            _context.MealViewModel.Remove(mealViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealViewModelExists(int id)
        {
            return _context.MealViewModel.Any(e => e.MealId == id);
        }
    }
}
