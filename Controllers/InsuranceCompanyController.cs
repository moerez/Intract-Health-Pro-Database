using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Controllers
{
    public class InsuranceCompanyController : Controller
    {
        private readonly IhpDbContext _context;

        public InsuranceCompanyController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: InsuranceCompany
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null || _context.InsuranceCompanies == null)
            {
                return _context.InsuranceCompanies != null ?
                            View(await _context.InsuranceCompanies.ToListAsync()) :
                            Problem("Entity set 'IhpDbContext.InsuranceCompanies'  is null.");
            }
            var insuranceCompany = await _context.InsuranceCompanies.FirstOrDefaultAsync(m => m.Id == id);
            if(insuranceCompany == null)
            {
                return NotFound();
            }
            insuranceCompany.InsuranceCompanyContacts = _context.InsuranceCompanyContacts.Where(icc => icc.InsuranceCompany.Id == id).ToList();
            insuranceCompany.InsuranceClaims = _context.InsuranceClaims.Where(ic => ic.InsuranceCompany.Id == id).ToList();
            return View("Details", insuranceCompany);

        }

        // GET: InsuranceCompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsuranceCompanies == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return View(insuranceCompany);
        }

        // GET: InsuranceCompany/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuranceCompany/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuranceCompany);
        }

        // GET: InsuranceCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InsuranceCompanies == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompanies.FindAsync(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }
            return View(insuranceCompany);
        }

        // POST: InsuranceCompany/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] InsuranceCompany insuranceCompany)
        {
            if (id != insuranceCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceCompanyExists(insuranceCompany.Id))
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
            return View(insuranceCompany);
        }

        // GET: InsuranceCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsuranceCompanies == null)
            {
                return NotFound();
            }

            var insuranceCompany = await _context.InsuranceCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return View(insuranceCompany);
        }

        // POST: InsuranceCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsuranceCompanies == null)
            {
                return Problem("Entity set 'IhpDbContext.InsuranceCompanies'  is null.");
            }
            var insuranceCompany = await _context.InsuranceCompanies.FindAsync(id);
            if (insuranceCompany != null)
            {
                _context.InsuranceCompanies.Remove(insuranceCompany);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceCompanyExists(int id)
        {
          return (_context.InsuranceCompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
