using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Controllers
{
    public class InsuranceCompanyContactController : Controller
    {
        private readonly IhpDbContext _context;

        public InsuranceCompanyContactController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: InsuranceCompanyContact
        public async Task<IActionResult> Index()
        {
              return _context.InsuranceCompanyContacts != null ? 
                          View(await _context.InsuranceCompanyContacts.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.InsuranceCompanyContacts'  is null.");
        }

        // GET: InsuranceCompanyContact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsuranceCompanyContacts == null)
            {
                return NotFound();
            }

            var insuranceCompanyContact = await _context.InsuranceCompanyContacts
                .Include(icc => icc.InsuranceCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCompanyContact == null)
            {
                return NotFound();
            }

            return View(insuranceCompanyContact);
        }

        // GET: InsuranceCompanyContact/Create
        public async Task<IActionResult> Create(int? insuranceCompanyId)
        {
            if (insuranceCompanyId == null || _context == null || _context.InsuranceCompanies == null)
            {
                return RedirectToAction("Index", "insuranceCompany");
            }
            else
            {
                InsuranceCompany? ic = await _context.InsuranceCompanies.Where(i => i.Id == insuranceCompanyId).FirstOrDefaultAsync();
                if (ic == null)
                {
                    return RedirectToAction("Index", "insuranceCompany");
                }
                return View(new InsuranceCompanyContact { InsuranceCompanyId1 = ic.Id, InsuranceCompany = ic });
            }
        }

        // POST: InsuranceCompanyContact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InsuranceCompanyID1,Title,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] InsuranceCompanyContact insuranceCompanyContact)
        {
            ModelState.Remove("InsuranceCompany");
            if (ModelState.IsValid)
            {
                InsuranceCompany? ic = await _context.InsuranceCompanies.Where(i => i.Id == insuranceCompanyContact.InsuranceCompanyId1).FirstOrDefaultAsync();
                insuranceCompanyContact.InsuranceCompany = ic ?? throw new InvalidOperationException("InsuranceCompany is null");
                _context.Add(insuranceCompanyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuranceCompanyContact);
        }

        // GET: InsuranceCompanyContact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InsuranceCompanyContacts == null)
            {
                return NotFound();
            }

            var insuranceCompanyContact = await _context.InsuranceCompanyContacts
            .Include(icc => icc.InsuranceCompany)
            .Where(icc => icc.Id == id)
            .FirstOrDefaultAsync();
            if (insuranceCompanyContact == null)
            {
                return NotFound();
            }
            insuranceCompanyContact.InsuranceCompanyId1 = insuranceCompanyContact.InsuranceCompany.Id;
            return View(insuranceCompanyContact);
        }

        // POST: InsuranceCompanyContact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InsuranceCompanyId1, Title,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] InsuranceCompanyContact insuranceCompanyContact)
        {
            if (id != insuranceCompanyContact.Id)
            {
                return NotFound();
            }

            ModelState.Remove("InsuranceCompany");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceCompanyContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceCompanyContactExists(insuranceCompanyContact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "InsuranceCompany", new {id = insuranceCompanyContact.InsuranceCompanyId1});
            }
            return View(insuranceCompanyContact);
        }

        // GET: InsuranceCompanyContact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsuranceCompanyContacts == null)
            {
                return NotFound();
            }

            var insuranceCompanyContact = await _context.InsuranceCompanyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceCompanyContact == null)
            {
                return NotFound();
            }

            return View(insuranceCompanyContact);
        }

        // POST: InsuranceCompanyContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsuranceCompanyContacts == null)
            {
                return Problem("Entity set 'IhpDbContext.InsuranceCompanyContacts'  is null.");
            }
            var insuranceCompanyContact = await _context.InsuranceCompanyContacts.FindAsync(id);
            if (insuranceCompanyContact != null)
            {
                _context.InsuranceCompanyContacts.Remove(insuranceCompanyContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceCompanyContactExists(int id)
        {
          return (_context.InsuranceCompanyContacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
