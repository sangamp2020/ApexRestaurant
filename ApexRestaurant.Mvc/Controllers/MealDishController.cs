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
            return View(await _context.MealDishViewModel.ToListAsync());
        }

        // GET: MealDish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDishViewModel = await _context.MealDishViewModel
                .FirstOrDefaultAsync(m => m.MealDishesId == id);
            if (mealDishViewModel == null)
            {
                return NotFound();
            }

            return View(mealDishViewModel);
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
        public async Task<IActionResult> Create([Bind("MealDishesId,MealId,MenuItemId,Quantity,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MealDishViewModel mealDishViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealDishViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealDishViewModel);
        }

        // GET: MealDish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDishViewModel = await _context.MealDishViewModel.FindAsync(id);
            if (mealDishViewModel == null)
            {
                return NotFound();
            }
            return View(mealDishViewModel);
        }

        // POST: MealDish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealDishesId,MealId,MenuItemId,Quantity,IsActive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] MealDishViewModel mealDishViewModel)
        {
            if (id != mealDishViewModel.MealDishesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealDishViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealDishViewModelExists(mealDishViewModel.MealDishesId))
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
            return View(mealDishViewModel);
        }

        // GET: MealDish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDishViewModel = await _context.MealDishViewModel
                .FirstOrDefaultAsync(m => m.MealDishesId == id);
            if (mealDishViewModel == null)
            {
                return NotFound();
            }

            return View(mealDishViewModel);
        }

        // POST: MealDish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealDishViewModel = await _context.MealDishViewModel.FindAsync(id);
            _context.MealDishViewModel.Remove(mealDishViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealDishViewModelExists(int id)
        {
            return _context.MealDishViewModel.Any(e => e.MealDishesId == id);
        }
    }
}
