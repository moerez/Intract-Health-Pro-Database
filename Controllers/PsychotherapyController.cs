using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using InteractHealthProDatabase.Data.Migrations;

namespace InteractHealthProDatabase.Controllers
{
    public class PsychotherapyController : Controller
    {
        private readonly IhpDbContext _context;

        public PsychotherapyController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: Psychotherapy
        public async Task<IActionResult> Index()
        {
              return _context.Psychotherapies != null ? 
                          View(await _context.Psychotherapies.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.Psychotherapies'  is null.");
        }

        // GET: Psychotherapy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Psychotherapies == null)
            {
                return NotFound();
            }

            var psychotherapy = await _context.Psychotherapies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (psychotherapy == null)
            {
                return NotFound();
            }

            return View(psychotherapy);
        }

        // GET: Psychotherapy/CreateOrEdit
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {
            if (clientId == null)
                return NotFound("The Client Id is null");

            Psychotherapy psychotherapy = new Psychotherapy();

            if (id != null) // Editing an existing record
            {
                // Get the BodyPart Detail from the DB
                psychotherapy = await _context.Psychotherapies
                  .Include(p => p.Client)
                  .Where(p => p.Id == id)
                  .FirstOrDefaultAsync() ?? psychotherapy;

                if (psychotherapy == null)
                    return NotFound("Type of Trauma not found in the database.");
            } else if (clientId != null)
            {
                psychotherapy = await _context.Psychotherapies
                  .Include(p => p.Client)
                  .Where(p => p.Client.Id == clientId)
                  .FirstOrDefaultAsync() ?? psychotherapy;

                if (psychotherapy == null)
                    return NotFound("Type of Trauma not found in the database.");
            }

            ViewBag.ClientId = psychotherapy.Client?.Id ?? clientId;
            return View("CreateOrEdit", psychotherapy);
        }

        // POST: Psychotherapy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,Stressed,Sad,NervousDepressed,Irritable,Restless,SleepTrouble,Flashbacks,Nightmares,MemoryProblems,AfraidDriving,AfraidPassenger,RelationshipsAffected,DifficultyWActivities,LowEnergy,Apathy,Avoidance,Other")] Psychotherapy psychotherapy)
        {
            ViewBag.ClientId = clientId ?? psychotherapy.Client.Id;
            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                Client? client = await _context.Clients.Where(c => c.Id == clientId).FirstOrDefaultAsync();
                if (client == null)
                {
                    ModelState.AddModelError("Client", "Client ID not found");
                    return View(psychotherapy);
                }
                psychotherapy.Client = client;
                psychotherapy.Client!.Psychotherapy = psychotherapy;
                if (id != null)
                {
                    // Update
                    _context.Entry(psychotherapy).State = EntityState.Modified;
                    _context.Update(psychotherapy!);
                }
                else
                {
                    _context.Add(psychotherapy);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Client", new { Id = psychotherapy.Client.Id});
            }
            return View(psychotherapy);
        }

        // GET: Psychotherapy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Psychotherapies == null)
            {
                return NotFound();
            }

            var psychotherapy = await _context.Psychotherapies.FindAsync(id);
            if (psychotherapy == null)
            {
                return NotFound();
            }
            return View(psychotherapy);
        }

        // POST: Psychotherapy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Stressed,Sad,NervousDepressed,Irritable,Restless,SleepTrouble,Flashbacks,Nightmares,MemoryProblems,AfraidDriving,AfraidPassenger,RelationshipsAffected,DifficultyWActivities,LowEnergy,Apathy,Avoidance,Other")] Psychotherapy psychotherapy)
        {
            if (id != psychotherapy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(psychotherapy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PsychotherapyExists(psychotherapy.Id))
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
            return View(psychotherapy);
        }

        // GET: Psychotherapy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Psychotherapies == null)
            {
                return NotFound();
            }

            var psychotherapy = await _context.Psychotherapies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (psychotherapy == null)
            {
                return NotFound();
            }

            return View(psychotherapy);
        }

        // POST: Psychotherapy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Psychotherapies == null)
            {
                return Problem("Entity set 'IhpDbContext.Psychotherapies'  is null.");
            }
            var psychotherapy = await _context.Psychotherapies.FindAsync(id);
            if (psychotherapy != null)
            {
                _context.Psychotherapies.Remove(psychotherapy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PsychotherapyExists(int id)
        {
          return (_context.Psychotherapies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
