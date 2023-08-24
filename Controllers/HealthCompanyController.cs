using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Controllers
{
    public class HealthCompanyController : Controller
    {
        private readonly IhpDbContext _context;

        public HealthCompanyController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: HealthCompany
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.HealthCompanies == null)
            {
                return _context.HealthCompanies != null ?
                        View(await _context.HealthCompanies.ToListAsync()) :
                        Problem("Entity set 'IhpDbContext.HealthCompanies'  is null.");
            }

            var healthCompany = await _context.HealthCompanies.FirstOrDefaultAsync(m => m.Id == id);
            if (healthCompany == null)
            {
                return NotFound();
            }

            healthCompany.HealthCompanyContacts = _context.HealthCompanyContacts.Where(hcc => hcc.HealthCompany.Id == id).ToList();
            healthCompany.HealthFiles = _context.HealthFiles.Where(hf => hf.HealthCompany.Id == id).ToList();

            return View("Details", healthCompany);
        }

        // GET: HealthCompany/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthCompany/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] HealthCompany healthCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = healthCompany.Id });
            }
            return View(healthCompany);
        }

        // GET: HealthCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthCompanies == null)
            {
                return NotFound();
            }

            var healthCompany = await _context.HealthCompanies.FindAsync(id);
            if (healthCompany == null)
            {
                return NotFound();
            }
            return View(healthCompany);
        }

        // POST: HealthCompany/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] HealthCompany healthCompany)
        {
            if (id != healthCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthCompanyExists(healthCompany.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = healthCompany.Id });
            }
            return View(healthCompany);
        }

        // GET: HealthCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthCompanies == null)
            {
                return NotFound();
            }

            var healthCompany = await _context.HealthCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCompany == null)
            {
                return NotFound();
            }

            return View(healthCompany);
        }

        // POST: HealthCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthCompanies == null)
            {
                return Problem("Entity set 'IhpDbContext.HealthCompanies'  is null.");
            }
            var healthCompany = await _context.HealthCompanies.FindAsync(id);
            if (healthCompany != null)
            {
                _context.HealthCompanies.Remove(healthCompany);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthCompanyExists(int id)
        {
            return (_context.HealthCompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
