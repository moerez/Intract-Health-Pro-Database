using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aftab_InteractHealthProDatabase.Models;
using InteractHealthProDatabase.Data;

namespace InteractHealthProDatabase.Controllers
{
    public class MedicalHistoryPostAccidentController : Controller
    {
        private readonly IhpDbContext _context;

        public MedicalHistoryPostAccidentController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: MedicalHistoryPostAccidents
        public async Task<IActionResult> Index()
        {
              return _context.MedicalHistoryPostAccident_1 != null ? 
                          View(await _context.MedicalHistoryPostAccident_1.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.MedicalHistoryPostAccident_1'  is null.");
        }

        // GET: MedicalHistoryPostAccidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalHistoryPostAccident_1 == null)
            {
                return NotFound();
            }

            var medicalHistoryPostAccident = await _context.MedicalHistoryPostAccident_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalHistoryPostAccident == null)
            {
                return NotFound();
            }

            return View(medicalHistoryPostAccident);
        }

        // GET: MedicalHistoryPostAccidents/CreateOrEdit
        public IActionResult CreateOrEdit(int? id, int? clientId)
        {
           // Check if we have an id for the client of the bodyTrauma
            if (clientId == null)
                return NotFound("The ID of the client and the Medical History Accident file are required to create or edit a Medical History Accident file.");

            MedicalHistoryPostAccident medicalHistoryPostAccident = new();
            if (clientId != null) // Editing an existing record from Client page
            {
                // Get the BodyTrauma from the DB for that client ID
                medicalHistoryPostAccident = _context.MedicalHistoryPostAccident_1
                  .Where(mhpa => mhpa.Client.Id == clientId)
                  .Include(mhpa => mhpa.Client)
                  .FirstOrDefault() ?? medicalHistoryPostAccident;

                if (medicalHistoryPostAccident == null)
                    return NotFound("Body Trauma not found in the database.");
            }

            ViewBag.ClientId = clientId;
            return View("CreateOrEdit", medicalHistoryPostAccident);
        }

        // POST: MedicalHistoryPostAccidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,TreatmentCenter,Appointment,Doctor")] MedicalHistoryPostAccident medicalHistoryPostAccident)
        {
            ViewBag.ClientId = clientId ?? medicalHistoryPostAccident.Client.Id;   // for form
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
                medicalHistoryPostAccident.Client = client;  // Assign client info to Body Trauma
                medicalHistoryPostAccident.Client!.MedicalHistoryPostAccident = medicalHistoryPostAccident;
                if (medicalHistoryPostAccident?.Id == 0 || medicalHistoryPostAccident?.Id == null)
                {
                    _context.Add(medicalHistoryPostAccident);
                    TempData["NotifyMsg"] = string.Format("Medical History Post Accident Detail Record Created for Client ID={0}", medicalHistoryPostAccident.Client.Id);
                    TempData["NotifyClassName"] = "success";
                }
                else
                {
                    // Update
                    _context.Entry(medicalHistoryPostAccident).State = EntityState.Modified;
                    _context.Update(medicalHistoryPostAccident);
                    TempData["NotifyMsg"] = string.Format("Medical History Pre Accident ID={0} updated successfully", medicalHistoryPostAccident.Id);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Client", new { Id = medicalHistoryPostAccident.Client.Id});
            }
            return View("CreateOrEdit", medicalHistoryPostAccident);
        }

        // GET: MedicalHistoryPostAccidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalHistoryPostAccident_1 == null)
            {
                return NotFound();
            }

            var medicalHistoryPostAccident = await _context.MedicalHistoryPostAccident_1.FindAsync(id);
            if (medicalHistoryPostAccident == null)
            {
                return NotFound();
            }
            return View(medicalHistoryPostAccident);
        }

        // POST: MedicalHistoryPostAccidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TreatmentCenter,Appointment,Doctor")] MedicalHistoryPostAccident medicalHistoryPostAccident)
        {
            if (id != medicalHistoryPostAccident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalHistoryPostAccident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalHistoryPostAccidentExists(medicalHistoryPostAccident.Id))
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
            return View(medicalHistoryPostAccident);
        }

        // GET: MedicalHistoryPostAccidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalHistoryPostAccident_1 == null)
            {
                return NotFound();
            }

            var medicalHistoryPostAccident = await _context.MedicalHistoryPostAccident_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalHistoryPostAccident == null)
            {
                return NotFound();
            }

            return View(medicalHistoryPostAccident);
        }

        // POST: MedicalHistoryPostAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalHistoryPostAccident_1 == null)
            {
                return Problem("Entity set 'IhpDbContext.MedicalHistoryPostAccident_1'  is null.");
            }
            var medicalHistoryPostAccident = await _context.MedicalHistoryPostAccident_1.FindAsync(id);
            if (medicalHistoryPostAccident != null)
            {
                _context.MedicalHistoryPostAccident_1.Remove(medicalHistoryPostAccident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalHistoryPostAccidentExists(int id)
        {
          return (_context.MedicalHistoryPostAccident_1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
