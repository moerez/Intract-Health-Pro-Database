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
    public class MedicalHistoryAccidentController : Controller
    {
        private readonly IhpDbContext _context;

        public MedicalHistoryAccidentController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: MedicalHistoryAccidents
        public async Task<IActionResult> Index()
        {
              return _context.MedicalHistoryAccident != null ? 
                          View(await _context.MedicalHistoryAccident.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.MedicalHistoryAccident'  is null.");
        }

        // GET: MedicalHistoryAccidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalHistoryAccident == null)
            {
                return NotFound();
            }

            var medicalHistoryAccident = await _context.MedicalHistoryAccident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalHistoryAccident == null)
            {
                return NotFound();
            }

            return View(medicalHistoryAccident);
        }

        // GET: MedicalHistoryAccidents/Create
        public IActionResult CreateOrEdit(int? id, int? clientId)
        {
            // Check if we have an id for the client of the bodyTrauma
            if (clientId == null)
                return NotFound("The ID of the client and the Medical History Accident file are required to create or edit a Medical History Accident file.");

            MedicalHistoryAccident medicalHistoryAccident = new();
            if (clientId != null) // Editing an existing record from Client page
            {
                // Get the BodyTrauma from the DB for that client ID
                medicalHistoryAccident = _context.MedicalHistoryAccident
                  .Where(mha => mha.Client.Id == clientId)
                  .Include(mha => mha.Client)
                  .FirstOrDefault() ?? medicalHistoryAccident;

                if (medicalHistoryAccident == null)
                    return NotFound("Body Trauma not found in the database.");
            }

            ViewBag.ClientId = clientId;
            return View("CreateOrEdit", medicalHistoryAccident);
        }

        // POST: MedicalHistoryAccidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,DiagnosisDate,Name,City,PostalCode,Description,NameOfPatiant,Ambulance,Walkin,Attending,Xray")] MedicalHistoryAccident medicalHistoryAccident)
        {
            ViewBag.ClientId = clientId ?? medicalHistoryAccident.Client.Id;   // for form
            if (ViewBag.ClientId == null)
            {
                return NotFound("Client Id is required to create/edit a Medical History Accident file");
            }

            // In the Bind annotation above, we have to include the children models, otherwise they will not be included
            // Remove the client from the validation
            ModelState.Remove("Client");

            if (ModelState.IsValid)
            {
                // Add
                // Get the client from the DB
                var client = await _context.Clients.FindAsync(ViewBag.ClientId);
                if (client == null)
                    return NotFound("Client id=" + ViewBag.ClientId + " not found in the database.");
                medicalHistoryAccident.Client = client;  // Assign client info to Body Trauma
                medicalHistoryAccident.Client!.MedicalHistoryAccident = medicalHistoryAccident;

                if (medicalHistoryAccident?.Id == 0 || medicalHistoryAccident?.Id == null)
                {
                    _context.Add(medicalHistoryAccident);
                    TempData["NotifyMsg"] = string.Format("Accident Detail Record Created for Client ID={0}", medicalHistoryAccident.Client.Id);
                    TempData["NotifyClassName"] = "success";
                }
                else
                {
                    // Update
                    _context.Entry(medicalHistoryAccident).State = EntityState.Modified;
                    _context.Update(medicalHistoryAccident);
                    TempData["NotifyMsg"] = string.Format("Medical History Accident ID={0} updated successfully", medicalHistoryAccident.Id);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Client", new { Id = medicalHistoryAccident.Client.Id});
            }
            return View("CreateOrEdit", medicalHistoryAccident);
        }

        // GET: MedicalHistoryAccidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalHistoryAccident == null)
            {
                return NotFound();
            }

            var medicalHistoryAccident = await _context.MedicalHistoryAccident.FindAsync(id);
            if (medicalHistoryAccident == null)
            {
                return NotFound();
            }
            return View(medicalHistoryAccident);
        }

        // POST: MedicalHistoryAccidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiagnosisDate,Name,City,PostalCode,Description,NameOfPatiant,Ambulance,Walkin,Attending,Xray")] MedicalHistoryAccident medicalHistoryAccident)
        {
            if (id != medicalHistoryAccident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalHistoryAccident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalHistoryAccidentExists(medicalHistoryAccident.Id))
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
            return View(medicalHistoryAccident);
        }

        // GET: MedicalHistoryAccidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalHistoryAccident == null)
            {
                return NotFound();
            }

            var medicalHistoryAccident = await _context.MedicalHistoryAccident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalHistoryAccident == null)
            {
                return NotFound();
            }

            return View(medicalHistoryAccident);
        }

        // POST: MedicalHistoryAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalHistoryAccident == null)
            {
                return Problem("Entity set 'IhpDbContext.MedicalHistoryAccident'  is null.");
            }
            var medicalHistoryAccident = await _context.MedicalHistoryAccident.FindAsync(id);
            if (medicalHistoryAccident != null)
            {
                _context.MedicalHistoryAccident.Remove(medicalHistoryAccident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalHistoryAccidentExists(int id)
        {
          return (_context.MedicalHistoryAccident?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
