
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Controllers
{
    public class InsuranceClaimController : Controller
    {
        private readonly IhpDbContext _context;

        public InsuranceClaimController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: InsuranceClaim
        public async Task<IActionResult> Index()
        {
              return _context.InsuranceClaims != null ? 
                          View(await _context.InsuranceClaims.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.InsuranceClaims'  is null.");
        }

        // GET: InsuranceClaim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsuranceClaims == null)
            {
                return NotFound();
            }

            var insuranceClaim = await _context.InsuranceClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceClaim == null)
            {
                return NotFound();
            }

            return View(insuranceClaim);
        }

        // GET: InsuranceClaim/Create
        public IActionResult CreateOrEdit(int? id, int? clientId)
        {
            // Check if we have an id for the healthFile or an Id for the client
            if (id == null && clientId == null)
                return NotFound("The ID of the client and the insurance claim are required to create or edit a insurance claim.");

            InsuranceClaim insuranceClaim = new InsuranceClaim();
            if (id != null) // Editing an existing health file
            {
                // Get the health file from the DB
                insuranceClaim = _context.InsuranceClaims
                    .Include(hf => hf.Client)
                    .Include(hf => hf.InsuranceCompany)
                    .Where(hf => hf.Id == id)
                    .FirstOrDefault() ?? insuranceClaim;
                if (insuranceClaim == null)
                    return NotFound("Health file not found in the database.");
                insuranceClaim.SelectedInsuranceCompanyId = insuranceClaim.InsuranceCompany?.Id;
            }
            ViewBag.ClientId = insuranceClaim.Client?.Id ?? clientId;

            // Get the list of Health Companies from the DB
            var insuranceCompanies = _context.InsuranceCompanies?.ToList();
            if (insuranceCompanies == null)
                return Problem("Entity set 'IhpDbContext.InsuranceCompanies'  is null.");
            ViewBag.InsuranceCompanies = insuranceCompanies;

            return View("CreateOrEdit", insuranceClaim);
        }

        // POST: InsuranceClaim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,SelectedInsuranceCompanyId,Claimref,OtherClaimRef")] InsuranceClaim insuranceClaim)
        {
            ModelState.Remove("Client");
            ModelState.Remove("InsuranceCompany");
            ViewBag.ClientId = clientId;

            //Load InsuranceCompanies to show as a select
            var insuranceCompanies = _context.InsuranceCompanies?.ToList();
            if (insuranceCompanies == null)
                return Problem("Entity set 'IhpDbContext.InsuranceCompanies'  is null.");
            ViewBag.InsuranceCompanies = insuranceCompanies;

            if (clientId == null)
            {
                return NotFound("Client Id is required to create/edit a insurance claim");
            }
            if (insuranceClaim.SelectedInsuranceCompanyId == null)
            {
                ModelState.AddModelError("SelectedInsuranceCompanyId", "You must select a Insurance Company.");
                return View("CreateOrEdit", insuranceClaim);
            }
            if (ModelState.IsValid)
            {
                // Get the client from the DB
                var client = await _context.Clients.FindAsync(clientId);
                if (client == null)
                    return NotFound("Client not found in the database.");
                insuranceClaim.Client = client;

                // Get the health company from the DB
                var insuranceCompany = await _context.InsuranceCompanies!.FindAsync(insuranceClaim.SelectedInsuranceCompanyId);
                if (insuranceCompany == null)
                    return NotFound("Insurance Company not found in the database.");
                insuranceClaim.InsuranceCompany = insuranceCompany;

                // Editing or creating?
                if (id != null)
                    _context.Entry(insuranceClaim).State = EntityState.Modified;
                else
                    _context.Add(insuranceClaim);

                await _context.SaveChangesAsync();

                // TODO: Decide where these actions should redirect to
                if (id == null)
                    return RedirectToAction("Details", "Client", new { id = clientId });
                else
                    return RedirectToAction(nameof(Details), new { id = id });
            }
            return View("CreateOrEdit", insuranceClaim);
        }
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Claimref,OtherClaimRef")] InsuranceClaim insuranceClaim)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(insuranceClaim);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(insuranceClaim);
        // }

        // // GET: InsuranceClaim/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null || _context.InsuranceClaims == null)
        //     {
        //         return NotFound();
        //     }

        //     var insuranceClaim = await _context.InsuranceClaims.FindAsync(id);
        //     if (insuranceClaim == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(insuranceClaim);
        // }

        // POST: InsuranceClaim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,Claimref,OtherClaimRef")] InsuranceClaim insuranceClaim)
        // {
        //     if (id != insuranceClaim.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(insuranceClaim);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!InsuranceClaimExists(insuranceClaim.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(insuranceClaim);
        // }

        // GET: InsuranceClaim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsuranceClaims == null)
            {
                return NotFound();
            }

            var insuranceClaim = await _context.InsuranceClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceClaim == null)
            {
                return NotFound();
            }

            return View(insuranceClaim);
        }

        // POST: InsuranceClaim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsuranceClaims == null)
            {
                return Problem("Entity set 'IhpDbContext.InsuranceClaims'  is null.");
            }
            var insuranceClaim = await _context.InsuranceClaims.FindAsync(id);
            if (insuranceClaim != null)
            {
                _context.InsuranceClaims.Remove(insuranceClaim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceClaimExists(int id)
        {
          return (_context.InsuranceClaims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
