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
    public class MealDishController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealDishController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MealDish
        public async Task<IActionResult> Index()
        {
            return View(await _context.MealDishes.ToListAsync());
        }

        // GET: MealDish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDishes = await _context.MealDishes
                .FirstOrDefaultAsync(m => m.MealDishesId == id);
            if (mealDishes == null)
            {
                return NotFound();
            }

            return View(mealDishes);
        }

        // GET: MealDish/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealDish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealDishesId,MealId,MenuItemId,Quantity,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MealDishes mealDishes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealDishes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealDishes);
        }

        // GET: MealDish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDishes = await _context.MealDishes.FindAsync(id);
            if (mealDishes == null)
            {
                return NotFound();
            }
            return View(mealDishes);
        }

        // POST: MealDish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealDishesId,MealId,MenuItemId,Quantity,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MealDishes mealDishes)
        {
            if (id != mealDishes.MealDishesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealDishes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealDishesExists(mealDishes.MealDishesId))
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
            return View(mealDishes);
        }

        // GET: MealDish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDishes = await _context.MealDishes
                .FirstOrDefaultAsync(m => m.MealDishesId == id);
            if (mealDishes == null)
            {
                return NotFound();
            }

            return View(mealDishes);
        }

        // POST: MealDish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealDishes = await _context.MealDishes.FindAsync(id);
            _context.MealDishes.Remove(mealDishes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealDishesExists(int id)
        {
            return _context.MealDishes.Any(e => e.MealDishesId == id);
        }
    }
}
