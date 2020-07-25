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
            return View(await _context.Meals.ToListAsync());
        }

        // GET: Meal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meals = await _context.Meals
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meals == null)
            {
                return NotFound();
            }

            return View(meals);
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
        public async Task<IActionResult> Create([Bind("MealId,StaffId,CustomerId,DateOfMeal,CostOfMeal,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Meals meals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meals);
        }

        // GET: Meal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meals = await _context.Meals.FindAsync(id);
            if (meals == null)
            {
                return NotFound();
            }
            return View(meals);
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealId,StaffId,CustomerId,DateOfMeal,CostOfMeal,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Meals meals)
        {
            if (id != meals.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealsExists(meals.MealId))
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
            return View(meals);
        }

        // GET: Meal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meals = await _context.Meals
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meals == null)
            {
                return NotFound();
            }

            return View(meals);
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meals = await _context.Meals.FindAsync(id);
            _context.Meals.Remove(meals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealsExists(int id)
        {
            return _context.Meals.Any(e => e.MealId == id);
        }
    }
}
