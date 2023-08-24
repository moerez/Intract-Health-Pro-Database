using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Controllers
{
    public class DependentController : Controller
    {
        private readonly IhpDbContext _context;

        public DependentController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: Dependent
        public async Task<IActionResult> Index()
        {
              return _context.Dependent != null ? 
                          View(await _context.Dependent.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.Dependent'  is null.");
        }

        // GET: Dependent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dependent == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // GET: Dependent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dependent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Person,Wheelchair,Details")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dependent);
        }

        // GET: Dependent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dependent == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependent.FindAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }
            return View(dependent);
        }

        // POST: Dependent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Person,Wheelchair,Details")] Dependent dependent)
        {
            if (id != dependent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependentExists(dependent.Id))
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
            return View(dependent);
        }

        // GET: Dependent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dependent == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // POST: Dependent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dependent == null)
            {
                return Problem("Entity set 'IhpDbContext.Dependent'  is null.");
            }
            var dependent = await _context.Dependent.FindAsync(id);
            if (dependent != null)
            {
                _context.Dependent.Remove(dependent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependentExists(int id)
        {
          return (_context.Dependent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
