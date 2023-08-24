using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Controllers
{
    public class HealthCompanyContactController : Controller
    {
        private readonly IhpDbContext _context;

        public HealthCompanyContactController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: HealthCompanyContact
        public async Task<IActionResult> Index()
        {
            return _context.HealthCompanyContacts != null ?
                        View(await _context.HealthCompanyContacts.ToListAsync()) :
                        Problem("Entity set 'IhpDbContext.HealthCompanyContacts'  is null.");
        }

        // GET: HealthCompanyContact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthCompanyContacts == null)
            {
                return NotFound();
            }

            var healthCompanyContact = await _context.HealthCompanyContacts
                .Include(hcc => hcc.HealthCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCompanyContact == null)
            {
                return NotFound();
            }

            return View(healthCompanyContact);
        }

        // GET: HealthCompanyContact/Create
        public async Task<IActionResult> Create(int? healthCompanyId)
        {
            if (healthCompanyId == null || _context == null || _context.HealthCompanies == null)
            {
                return RedirectToAction("Index", "HealthCompany");
            }
            else
            {
                HealthCompany? hc = await _context.HealthCompanies.Where(h => h.Id == healthCompanyId).FirstOrDefaultAsync();
                if (hc == null)
                {
                    return RedirectToAction("Index", "HealthCompany");
                }
                return View(new HealthCompanyContact { HealthCompanyId1 = hc.Id, HealthCompany = hc });
            }
        }

        // POST: HealthCompanyContact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HealthCompanyId1,Title,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] HealthCompanyContact healthCompanyContact)
        {
            ModelState.Remove("HealthCompany");
            if (ModelState.IsValid)
            {
                HealthCompany? hc = await _context.HealthCompanies.Where(h => h.Id == healthCompanyContact.HealthCompanyId1).FirstOrDefaultAsync();
                healthCompanyContact.HealthCompany = hc ?? throw new InvalidOperationException("HealthCompany is null");
                _context.Add(healthCompanyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "HealthCompany", new { id = healthCompanyContact.HealthCompany.Id });
            }
            return View(healthCompanyContact);
        }

        // GET: HealthCompanyContact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthCompanyContacts == null)
            {
                return NotFound();
            }

            var healthCompanyContact = await _context.HealthCompanyContacts
            .Include(hcc => hcc.HealthCompany)
            .Where(hcc => hcc.Id == id)
            .FirstOrDefaultAsync();
            if (healthCompanyContact == null)
            {
                return NotFound();
            }
            healthCompanyContact.HealthCompanyId1 = healthCompanyContact.HealthCompany.Id;
            return View(healthCompanyContact);
        }

        // POST: HealthCompanyContact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HealthCompanyId1,Title,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] HealthCompanyContact healthCompanyContact)
        {
            if (id != healthCompanyContact.Id)
            {
                return NotFound();
            }

            ModelState.Remove("HealthCompany");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthCompanyContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthCompanyContactExists(healthCompanyContact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "HealthCompany", new { id = healthCompanyContact.HealthCompanyId1 });
            }
            return View(healthCompanyContact);
        }

        // GET: HealthCompanyContact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthCompanyContacts == null)
            {
                return NotFound();
            }

            var healthCompanyContact = await _context.HealthCompanyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthCompanyContact == null)
            {
                return NotFound();
            }

            return View(healthCompanyContact);
        }

        // POST: HealthCompanyContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthCompanyContacts == null)
            {
                return Problem("Entity set 'IhpDbContext.HealthCompanyContacts'  is null.");
            }
            var healthCompanyContact = await _context.HealthCompanyContacts.FindAsync(id);
            if (healthCompanyContact != null)
            {
                _context.HealthCompanyContacts.Remove(healthCompanyContact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthCompanyContactExists(int id)
        {
            return (_context.HealthCompanyContacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
