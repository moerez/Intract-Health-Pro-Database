                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using Aftab_InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Controllers
{
    public class MedicationController : Controller
    {
        private readonly IhpDbContext _context;

        public MedicationController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: Medications
        public async Task<IActionResult> Index()
        {
              return _context.Medication != null ? 
                          View(await _context.Medication.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.Medication'  is null.");
        }

        // GET: Medications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medication == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // GET: Medications/Create
        public IActionResult CreateOrEdit(int? id, int? clientId, string? type)
        {
            if (clientId == null)
                return NotFound("Client ID is needed");
            // creating a new medication
            Medication medication = new();
            // modifying an existing medication
            if(id != null)
            {
                // Get the health file from the DB
                if (type == "MedicalHistoryAccident") {
                    medication = _context.Medication
                        .Include(med => med.MedicalHistoryAccident)
                        .Where(med => med.Id == id)
                        .FirstOrDefault() ?? medication;
                } else if(type == "MedicalHistoryPreAccident")
                {
                    medication = _context.Medication
                        .Include(med => med.MedicalHistoryPreAccident)
                        .Where(med => med.Id == id)
                        .FirstOrDefault() ?? medication;
                } else if(type == "MedicalHistoryPostAccident")
                {
                    // Fetch the medical history post accident and then find medication in the list of all medications
                    MedicalHistoryPostAccident mhpa = new();
                    
                    mhpa = _context.MedicalHistoryPostAccident_1
                        .Where(mhposta => mhposta.Client.Id == clientId)
                        .FirstOrDefault() ?? mhpa;


                    if (mhpa == new MedicalHistoryPostAccident())
                        return NotFound("The Medical History Post Accident wasn't found in the database!");
                    medication = mhpa.Medications.ToList().Find(med => med.Id == id);
                }
                if (medication == null)
                    return NotFound("Medication not found in the database.");
            }

            @ViewBag.ClientId = clientId;
            @ViewBag.Id = id;
            @ViewBag.Type = type;

            return View("CreateOrEdit", medication);
        }

        // POST: Medications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, string? type, [Bind("Id,Diagnosis,Treatment,Drug,Doseage,DateDiagnosed")] Medication medication)
        {
            if (id == null && clientId == null)
            {
                return NotFound("The Id and The Client Id are required to create a medication");
            }
            if (ModelState.IsValid)
            {
                // Get the client from the DB
                var client = await _context.Clients.FindAsync(@ViewBag.ClientId);
                if (@ViewBag.Type == "MedicalHistoryAccident")
                {
                    var mha = _context.MedicalHistoryAccident.Find(client?.MedicalHistoryAccident.Id);
                    medication.MedicalHistoryAccident = mha;
                    medication.MedicalHistoryAccident.Medications.Add(medication);
                }
                else if (@ViewBag.Type == "MedicalHistoryPreAccident")
                {
                    var mhprea = _context.MedicalHistoryPreAccident.Find(client?.MedicalHistoryAccident.MedicalHistoryPreAccident.Id);
                    medication.MedicalHistoryPreAccident = mhprea;
                    medication.MedicalHistoryPreAccident.Medications.Add(medication);
                }
                else if (@ViewBag.Type == "MedicalHistoryPostAccident")
                {
                    var mhposa = _context.MedicalHistoryPostAccident_1.Find(client?.MedicalHistoryAccident.MedicalHistoryPostAccident.Id);
                    mhposa.Medications.Add(medication);
                }

                if (id != null)
                {
                    // Update
                    _context.Entry(medication).State = EntityState.Modified;
                    _context.Update(medication);
                }
                else
                {
                    _context.Add(medication);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Client", new { Id = clientId });
            }
            return View(medication);
        }

        // GET: Medications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medication == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            return View(medication);
        }

        // POST: Medications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Diagnosis,Treatment,Drug,Doseage,DateDiagnosed")] Medication medication)
        {
            if (id != medication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationExists(medication.Id))
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
            return View(medication);
        }

        // GET: Medications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medication == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // POST: Medications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medication == null)
            {
                return Problem("Entity set 'IhpDbContext.Medication'  is null.");
            }
            var medication = await _context.Medication.FindAsync(id);
            if (medication != null)
            {
                _context.Medication.Remove(medication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationExists(int id)
        {
          return (_context.Medication?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
