using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzApp.Data;
using PizzApp.Models;

namespace PizzApp.Controllers
{
    public class PizzasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PizzasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pizza.ToListAsync());
        }

        // GET: Pizzas/SearchForm
        //public async Task<IActionResult> SearchForm()
        public IActionResult SearchForm()
        {
            return View();
        }


        // POST: Pizzas/SearchResults
        public async Task<IActionResult> SearchResults(string PhraseToSearch)
        {     

                    return View("Index", await _context.Pizza.Where(
                    pizza => pizza.Description.Contains(PhraseToSearch) || pizza.Name.Contains(PhraseToSearch) || Convert.ToString(pizza.ID).Contains(PhraseToSearch)
                    ).ToListAsync());
          
            
        }



        // GET: Pizzas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // GET: Pizzas/Create
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Price,Source")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        //[Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Price,Source")] Pizza pizza)
        {
            if (id != pizza.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.ID))
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
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        //[Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        //[Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pizza == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pizza'  is null.");
            }
            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza != null)
            {
                _context.Pizza.Remove(pizza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
          return _context.Pizza.Any(e => e.ID == id);
        }

        //public void AddPreDefItem()
        //{
        //    var preDefPizza = new Pizza("Margherita", "Mozzarella cheese, herb tomato sauce", 50, "pizza.jpg");
        //    _context.Pizza.Add(preDefPizza);
        //    _context.SaveChanges();
        //}


        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPreDefItem(Pizza newPizza)
        {
            var preDefPizza = newPizza;
            _context.Pizza.Add(preDefPizza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Pizzas/DeleteAll
        //[Authorize]
        public IActionResult DeleteAll()
        {

            return View();
        }

        // POST: Pizzas/DeleteAll
        //[Authorize]
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAllConfirmed()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE dbo.Pizza");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> OrderByPrice()
        {
            return View("Index", await _context.Pizza.OrderBy(pizza => pizza.Price).ToListAsync());
        }

        public async Task<IActionResult> OrderByName()
        {
            return View("Index", await _context.Pizza.OrderBy(pizza => pizza.Name).ToListAsync());
        }


    }
}
