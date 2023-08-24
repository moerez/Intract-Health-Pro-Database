using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Controllers
{
    public class HealthFileController : Controller
    {
        private readonly IhpDbContext _context;

        public HealthFileController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: HealthFile
        public async Task<IActionResult> Index()
        {
            return _context.HealthFiles != null ?
                        View(await _context.HealthFiles.ToListAsync()) :
                        Problem("Entity set 'IhpDbContext.HealthFiles'  is null.");
        }

        // GET: HealthFile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthFiles == null)
            {
                return NotFound();
            }

            var healthFile = await _context.HealthFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthFile == null)
            {
                return NotFound();
            }

            return View(healthFile);
        }

        // GET: HealthFile/CreateEdit/5
        public IActionResult CreateOrEdit(int? id, int? clientId)
        {
            // Check if we have an id for the healthFile or an Id for the client
            if (id == null && clientId == null)
                return NotFound("The ID of the client and the health file are required to create or edit a health file.");

            HealthFile healthFile = new HealthFile();
            if (id != null) // Editing an existing health file
            {
                // Get the health file from the DB
                healthFile = _context.HealthFiles
                    .Include(hf => hf.Client)
                    .Include(hf => hf.HealthCompany)
                    .Where(hf => hf.Id == id)
                    .FirstOrDefault() ?? healthFile;
                if (healthFile == null)
                    return NotFound("Health file not found in the database.");
                healthFile.SelectedHealthCompanyId = healthFile.HealthCompany?.Id;
            }
            ViewBag.ClientId = healthFile.Client?.Id ?? clientId;

            // Get the list of Health Companies from the DB
            var healthCompanies = _context.HealthCompanies?.ToList();
            if (healthCompanies == null)
                return Problem("Entity set 'IhpDbContext.HealthCompanies'  is null.");
            ViewBag.HealthCompanies = healthCompanies;

            return View("CreateOrEdit", healthFile);
        }

        // POST: HealthFile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,SelectedHealthCompanyId,RefNo,OtherRefNo,TypeOfAppointment,DateTime")] HealthFile healthFile)
        {
            ModelState.Remove("Client");
            ModelState.Remove("HealthCompany");
            ViewBag.ClientId = clientId;

            //Load HealthCompanies to show as a select
            var healthCompanies = _context.HealthCompanies?.ToList();
            if (healthCompanies == null)
                return Problem("Entity set 'IhpDbContext.HealthCompanies'  is null.");
            ViewBag.HealthCompanies = healthCompanies;

            if (clientId == null)
            {
                return NotFound("Client Id is required to create/edit a health file");
            }
            if (healthFile.SelectedHealthCompanyId == null)
            {
                ModelState.AddModelError("SelectedHealthCompanyId", "You must select a Health Company.");
                return View("CreateOrEdit", healthFile);
            }
            if (ModelState.IsValid)
            {
                // Get the client from the DB
                var client = await _context.Clients.FindAsync(clientId);
                if (client == null)
                    return NotFound("Client not found in the database.");
                healthFile.Client = client;

                // Get the health company from the DB
                var healthCompany = await _context.HealthCompanies!.FindAsync(healthFile.SelectedHealthCompanyId);
                if (healthCompany == null)
                    return NotFound("Health Company not found in the database.");
                healthFile.HealthCompany = healthCompany;

                // Editing or creating?
                if (id != null)
                    _context.Entry(healthFile).State = EntityState.Modified;
                else
                    _context.Add(healthFile);

                await _context.SaveChangesAsync();

                // TODO: Decide where these actions should redirect to
                //if (id == null)
                return RedirectToAction("Details", "Client", new { id = clientId });
                //else
                //    return RedirectToAction(nameof(Details), new { id = id });
            }
            return View("CreateOrEdit", healthFile);
        }

        // GET: HealthFile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthFiles == null)
            {
                return NotFound();
            }

            var healthFile = await _context.HealthFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthFile == null)
            {
                return NotFound();
            }

            return View(healthFile);
        }

        // POST: HealthFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthFiles == null)
            {
                return Problem("Entity set 'IhpDbContext.HealthFiles'  is null.");
            }
            var healthFile = await _context.HealthFiles.FindAsync(id);
            if (healthFile != null)
            {
                _context.HealthFiles.Remove(healthFile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthFileExists(int id)
        {
            return (_context.HealthFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
