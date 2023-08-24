using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InteractHealthProDatabase.Controllers
{
    public class WorkHistoryController : Controller
    {
        private readonly IhpDbContext _context;

        public WorkHistoryController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: WorkHistory
        public async Task<IActionResult> Index(int? clientId)
        {
            
                var workHistory = await _context.WorkHistory.Include(wh => wh.Client).Where(wh => wh.Client.Id == clientId).ToListAsync();

                ViewBag.ClientId = clientId;
                return View(workHistory);

            
        }

            // GET: WorkHistory/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkHistory == null)
            {
                return NotFound();
            }

            var workHistory = await _context.WorkHistory
                .FirstOrDefaultAsync(wh => wh.Id == id);
                                        
                                        
            if (workHistory == null)
            {
                return NotFound();
            }


            return View(workHistory);
        }

        // GET: WorkHistory/CreateOrEdit
        public IActionResult CreateOrEdit(int? id, int? clientId)
        {
            if (clientId == null)
                return NotFound("The Client Id is null");

            WorkHistory workHistory = new();
            // Get the Work History from the DB for that client ID
            workHistory = _context.WorkHistory
              .Where(wh => wh.Client.Id == clientId)
              .Include(wh => wh.Client)
              .FirstOrDefault() ?? workHistory;
            if (workHistory == null)
                return NotFound("Work History not found in the database.");

            ViewBag.ClientId = clientId ?? workHistory.Client.Id;

            return View("CreateOrEdit", workHistory);
        }
       

        // POST: WorkHistory/CreateOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId,[Bind("Id,Position,Company,Address,City,Region,PostalCode,Country,From,Until,Details")] WorkHistory workHistory)
        {
            ViewBag.ClientId = clientId ?? workHistory.Client.Id;   // for form
            // In the Bind annotation above, we have to include the children models, otherwise they will not be included

            // The client of the children models is null, so we have to exclude it from the validation.
            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                Client? client = await _context.Clients.FindAsync(ViewBag.ClientId);
                if (client == null)
                {
                    ModelState.AddModelError("Client", "Client ID not found");
                    return View(workHistory);
                }

                workHistory.Client = client;
                workHistory.Client!.WorkHistory = workHistory;
                if (workHistory?.Id == 0 || workHistory?.Id == null)
                {
                    // Add
                    // Get the client from the DB
                    _context.Add(workHistory);
                    TempData["NotifyMsg"] = string.Format("Body Trauma Record Created for Client ID={0}", workHistory.Client.Id);

                    TempData["NotifyClassName"] = "success";
                } else
                {
                    // Update
                    _context.Entry(workHistory).State = EntityState.Modified;
                    _context.Update(workHistory!);
                    //TempData["NotifyMsg"] = string.Format("Body Trauma Record Updated successfully for Client ID={0}", ViewBag.ClientId);
                    //return RedirectToAction("Details", "Client", new { Id = bodyTrauma.Client.Id});
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Client", new { Id = workHistory.Client.Id});
            }
            return View(workHistory);
        }

        // GET: WorkHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkHistory == null)
            {
                return NotFound();
            }

            var workHistory = await _context.WorkHistory
                                        .Include(wh => wh.Client)
                                        .Where(wh => wh.Id == id)
                                        .FirstOrDefaultAsync();
            if (workHistory == null)
            {
                return NotFound();
            }

            if (workHistory.Client == null)
            {
                return NotFound("Client is Required");
            }
            ViewBag.ClientId = workHistory.Client.Id;

            return View(workHistory);
        }

        // POST: WorkHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, int? clientId, [Bind("Id,Position,Company,Address,City,Region,PostalCode,Country,From,Until,Details")] WorkHistory workHistory)
        {
            if (id != workHistory.Id)
            {
                return NotFound();
            }
            if(clientId == null)
            {
                return NotFound("ClientId is required!");
            }

            ModelState.Remove("Client");
            ViewBag.ClientId = clientId;
            if (ModelState.IsValid)
            {
                try
                {
                    //workHistory.Client = await _context.Clients.FindAsync(clientId.Value);
                    //workHistory.Client.Id = clientId.Value;
                    _context.Update(workHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkHistoryExists(workHistory.Id))
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
            return View(workHistory);
        }

        // GET: WorkHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkHistory == null)
            {
                return NotFound();
            }

            var workHistory = await _context.WorkHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workHistory == null)
            {
                return NotFound();
            }

            return View(workHistory);
        }

        // POST: WorkHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkHistory == null)
            {
                return Problem("Entity set 'IhpDbContext.WorkHistory'  is null.");
            }
            var workHistory = await _context.WorkHistory.FindAsync(id);
            if (workHistory != null)
            {
                _context.WorkHistory.Remove(workHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkHistoryExists(int id)
        {
            return (_context.WorkHistory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
