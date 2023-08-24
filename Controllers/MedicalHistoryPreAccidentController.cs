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
    public class MedicalHistoryPreAccidentController : Controller
    {
        private readonly IhpDbContext _context;

        public MedicalHistoryPreAccidentController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: MedicalHistoryPreAccidents
        public async Task<IActionResult> Index()
        {
              return _context.MedicalHistoryPreAccident != null ? 
                          View(await _context.MedicalHistoryPreAccident.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.MedicalHistoryPreAccident'  is null.");
        }

        // GET: MedicalHistoryPreAccidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalHistoryPreAccident == null)
            {
                return NotFound();
            }

            var medicalHistoryPreAccident = await _context.MedicalHistoryPreAccident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalHistoryPreAccident == null)
            {
                return NotFound();
            }

            return View(medicalHistoryPreAccident);
        }

        // GET: MedicalHistoryPreAccidents/Create
        public IActionResult CreateOrEdit(int? id, int? clientId)
        {
            // Check if we have an id for the client of the bodyTrauma
            if (clientId == null)
                return NotFound("The ID of the client and the Medical History Accident file are required to create or edit a Medical History Accident file.");

            MedicalHistoryPreAccident medicalHistoryPreAccident = new();
            if (clientId != null) // Editing an existing record from Client page
            {
                // Get the BodyTrauma from the DB for that client ID
                medicalHistoryPreAccident = _context.MedicalHistoryPreAccident
                  .Where(mhpa => mhpa.Client.Id == clientId)
                  .Include(mhpa => mhpa.Client)
                  .FirstOrDefault() ?? medicalHistoryPreAccident;

                if (medicalHistoryPreAccident == null)
                    return NotFound("Body Trauma not found in the database.");
            }

            ViewBag.ClientId = clientId;
            return View("CreateOrEdit", medicalHistoryPreAccident);
        }

        // POST: MedicalHistoryPreAccidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,Hospitalized,HospitalizedCondition,Asthma,Arthritis,Diabetes,HeartStroke,Thyroid,Other,Cancer,None,Note")] MedicalHistoryPreAccident medicalHistoryPreAccident)
        {
            ViewBag.ClientId = clientId ?? medicalHistoryPreAccident.Client.Id;   // for form
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
                medicalHistoryPreAccident.Client = client;  // Assign client info to Body Trauma
                medicalHistoryPreAccident.Client!.MedicalHistoryPreAccident = medicalHistoryPreAccident;
                if (medicalHistoryPreAccident?.Id == 0 || medicalHistoryPreAccident?.Id == null)
                {
                    _context.Add(medicalHistoryPreAccident);
                    TempData["NotifyMsg"] = string.Format("Medical History Detail Record Created for Client ID={0}", medicalHistoryPreAccident.Client.Id);
                    TempData["NotifyClassName"] = "success";
                }
                else
                {
                    // Update
                    _context.Entry(medicalHistoryPreAccident).State = EntityState.Modified;
                    _context.Update(medicalHistoryPreAccident);
                    TempData["NotifyMsg"] = string.Format("Medical History Pre Accident ID={0} updated successfully", medicalHistoryPreAccident.Id);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Client", new { Id = medicalHistoryPreAccident.Client.Id});
            }
            return View("CreateOrEdit", medicalHistoryPreAccident);
        }

        // GET: MedicalHistoryPreAccidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalHistoryPreAccident == null)
            {
                return NotFound();
            }

            var medicalHistoryPreAccident = await _context.MedicalHistoryPreAccident.FindAsync(id);
            if (medicalHistoryPreAccident == null)
            {
                return NotFound();
            }
            return View(medicalHistoryPreAccident);
        }

        // POST: MedicalHistoryPreAccidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hospitalized,HospitalizedCondition,Asthma,Arthritis,Diabetes,HeartStroke,Thyroid,Other,Cancer,None,Note")] MedicalHistoryPreAccident medicalHistoryPreAccident)
        {
            if (id != medicalHistoryPreAccident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalHistoryPreAccident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalHistoryPreAccidentExists(medicalHistoryPreAccident.Id))
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
            return View(medicalHistoryPreAccident);
        }

        // GET: MedicalHistoryPreAccidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalHistoryPreAccident == null)
            {
                return NotFound();
            }

            var medicalHistoryPreAccident = await _context.MedicalHistoryPreAccident
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalHistoryPreAccident == null)
            {
                return NotFound();
            }

            return View(medicalHistoryPreAccident);
        }

        // POST: MedicalHistoryPreAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalHistoryPreAccident == null)
            {
                return Problem("Entity set 'IhpDbContext.MedicalHistoryPreAccident'  is null.");
            }
            var medicalHistoryPreAccident = await _context.MedicalHistoryPreAccident.FindAsync(id);
            if (medicalHistoryPreAccident != null)
            {
                _context.MedicalHistoryPreAccident.Remove(medicalHistoryPreAccident);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalHistoryPreAccidentExists(int id)
        {
          return (_context.MedicalHistoryPreAccident?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
