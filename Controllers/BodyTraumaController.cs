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
    public class BodyTraumaController : Controller
    {
        private readonly IhpDbContext _context;

        public BodyTraumaController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: BodyTrauma
        public async Task<IActionResult> Index()
        {
              return _context.BodyTrauma != null ? 
                          View(await _context.BodyTrauma.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.BodyTrauma'  is null.");
        }

        // GET: BodyTrauma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BodyTrauma == null)
            {
                return NotFound();
            }

            var bodyTrauma = await _context.BodyTrauma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyTrauma == null)
            {
                return NotFound();
            }

            return View(bodyTrauma);
        }

        // GET: BodyTrauma/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: AccidentDetail/CreateOrEdit?clientId=X
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {
            // Check if we have an id for the client of the bodyTrauma
            if (clientId == null)
                return NotFound("The ID of the client and the Body Trauma file are required to create or edit a Body Trauma file.");

            BodyTrauma bodyTrauma = new();
            if (clientId != null) // Editing an existing record from Client page
            {
                // Get the BodyTrauma from the DB for that client ID
                bodyTrauma = _context.BodyTrauma
                  .Where(bt => bt.Client.Id == clientId)
                  .Include(bt => bt.Client)
                  .FirstOrDefault() ?? bodyTrauma;
                    
            }

            ViewBag.ClientId = clientId ?? bodyTrauma.Client.Id;
            return View("CreateOrEdit", bodyTrauma);
        }

        // POST: BodyTrauma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,Bruising,Bleeding,Fracture,LossOfContentiousness,HitToTheHead,None,PainRightAway")] BodyTrauma bodyTrauma)
        {
            ViewBag.ClientId = clientId ?? bodyTrauma.Client.Id;   // for form
            if (ViewBag.ClientId == null)
            {
                return NotFound("Client Id is required to create/edit a Body Trauma");
            }

            // In the Bind annotation above, we have to include the children models, otherwise they will not be included
            // Remove the client from the validation
            ModelState.Remove("Client");

            if (ModelState.IsValid)
            {
                var client = await _context.Clients.FindAsync(ViewBag.ClientId);
                if (client == null)
                    return NotFound("Client id=" + ViewBag.ClientId + " not found in the database.");
                bodyTrauma.Client = client;  // Assign client info to Body Trauma
                bodyTrauma!.Client.BodyTrauma = bodyTrauma;

                if (bodyTrauma?.Id == 0 || bodyTrauma?.Id == null)
                {
                    // Add
                    // Get the client from the DB
                    _context.Add(bodyTrauma);
                    TempData["NotifyMsg"] = string.Format("Body Trauma Record Created for Client ID={0}", bodyTrauma.Client.Id);

                    TempData["NotifyClassName"] = "success";
                } else
                {
                    // Update
                    _context.Entry(bodyTrauma).State = EntityState.Modified;
                    _context.Update(bodyTrauma!);
                    //TempData["NotifyMsg"] = string.Format("Body Trauma Record Updated successfully for Client ID={0}", ViewBag.ClientId);
                    //return RedirectToAction("Details", "Client", new { Id = bodyTrauma.Client.Id});
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Client", new { Id = bodyTrauma.Client.Id});
            }
            return View("CreateOrEdit", bodyTrauma);
        }

        // GET: BodyTrauma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BodyTrauma == null)
            {
                return NotFound();
            }

            var bodyTrauma = await _context.BodyTrauma.FindAsync(id);
            if (bodyTrauma == null)
            {
                return NotFound();
            }
            return View(bodyTrauma);
        }

        // POST: BodyTrauma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bruising,Bleeding,Fracture,LossOfContentiousness,HitToTheHead,None,PainRightAway")] BodyTrauma bodyTrauma)
        {
            if (id != bodyTrauma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyTrauma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyTraumaExists(bodyTrauma.Id))
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
            return View(bodyTrauma);
        }

        // GET: BodyTrauma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BodyTrauma == null)
            {
                return NotFound();
            }

            var bodyTrauma = await _context.BodyTrauma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyTrauma == null)
            {
                return NotFound();
            }

            return View(bodyTrauma);
        }

        // POST: BodyTrauma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BodyTrauma == null)
            {
                return Problem("Entity set 'IhpDbContext.BodyTrauma'  is null.");
            }
            var bodyTrauma = await _context.BodyTrauma.FindAsync(id);
            if (bodyTrauma != null)
            {
                _context.BodyTrauma.Remove(bodyTrauma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyTraumaExists(int id)
        {
          return (_context.BodyTrauma?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
