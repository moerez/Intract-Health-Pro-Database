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
    public class LawyerController : Controller
    {
        private readonly IhpDbContext _context;

        public LawyerController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: Lawyer
        public async Task<IActionResult> Index()
        {
              return _context.Lawyers != null ? 
                          View(await _context.Lawyers.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.Lawyers'  is null.");
        }

        // GET: Lawyer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lawyers == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        // GET: Lawyer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lawyer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lawyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lawyer);
        }

        // GET: Lawyer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lawyers == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyers.FindAsync(id);
            if (lawyer == null)
            {
                return NotFound();
            }
            return View(lawyer);
        }

        // POST: Lawyer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] Lawyer lawyer)
        {
            if (id != lawyer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lawyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LawyerExists(lawyer.Id))
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
            return View(lawyer);
        }

        // GET: Lawyer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lawyers == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        // POST: Lawyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lawyers == null)
            {
                return Problem("Entity set 'IhpDbContext.Lawyers'  is null.");
            }
            var lawyer = await _context.Lawyers.FindAsync(id);
            if (lawyer != null)
            {
                _context.Lawyers.Remove(lawyer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LawyerExists(int id)
        {
          return (_context.Lawyers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
