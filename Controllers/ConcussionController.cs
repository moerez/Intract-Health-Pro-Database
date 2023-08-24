using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using MailKit;

namespace InteractHealthProDatabase.Controllers
{
    public class ConcussionController : Controller
    {
        private readonly IhpDbContext _context;

        public ConcussionController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: Concussion
        public async Task<IActionResult> Index()
        {
              return _context.Concussion != null ? 
                          View(await _context.Concussion.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.Concussion'  is null.");
        }

        // GET: Concussion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Concussion == null)
            {
                return NotFound();
            }

            var concussion = await _context.Concussion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concussion == null)
            {
                return NotFound();
            }

            return View(concussion);
        }

        // GET: Concussion/CreateOrEdit
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {
            if (clientId == null)
                return NotFound("The Client Id is null");

            Concussion concussion = new Concussion();

            if (id != null) // Editing an existing record
            {
                // Get the BodyPart Detail from the DB
                concussion = await _context.Concussion
                  .Include(c => c.Client)
                  .Where(c => c.Id == id)
                  .FirstOrDefaultAsync() ?? concussion;

                if (concussion == null)
                    return NotFound("Type of Head Trauma not found in the database.");
            } else {
                // Get the BodyPart Detail from the DB
                concussion = await _context.Concussion
                  .Include(c => c.Client)
                  .Where(c => c.Client.Id == clientId)
                  .FirstOrDefaultAsync() ?? concussion;

                if (concussion == null)
                    return NotFound("Type of Head Trauma not found in the database.");
            }

            ViewBag.ClientId = concussion.Client?.Id ?? clientId;
            return View("CreateOrEdit", concussion);
        }

        // POST: Concussion/CreateOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,HeadAches,Vision,Amnesia,Smell,Tinitus,Seizures,Dizziness,Balance,Tremors,Nausea,Blackouts,Tasks,Motivation,FinishTasks,Assert,Forgetful,AttentionSpan,AnticipateOthers,ProblemSolving,MentalStamina,Reading,Performance,LanguageDifficulty,Verbal,ImpairedJudgement,Reactions,NotesTimer,AbnormalAnxiety,Rude,Personality,Mood,Depression,Indifference,Fatigue,Shallow,MentalFlex,Note")] Concussion concussion)
        {
            ViewBag.ClientId = clientId ?? concussion.Client.Id;
            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                Client? client = await _context.Clients.Where(c => c.Id == clientId).FirstOrDefaultAsync();
                if (client == null)
                {
                    ModelState.AddModelError("Client", "Client ID not found");
                    return View(concussion);
                }
                concussion.Client = client;
                concussion.Client!.Concussion = concussion;
                if (id != null)
                {
                    // Update
                    _context.Entry(concussion).State = EntityState.Modified;
                    _context.Update(concussion!);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Client", new { Id = concussion.Client.Id});
                }
                else
                {
                    _context.Add(concussion);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Client", new { Id = concussion.Client.Id});
                }
            }
            return View(concussion);
        }

        // GET: Concussion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Concussion == null)
            {
                return NotFound();
            }

            var concussion = await _context.Concussion.FindAsync(id);
            if (concussion == null)
            {
                return NotFound();
            }
            return View(concussion);
        }

        // POST: Concussion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HeadAches,Vision,Amnesia,Smell,Tinitus,Seizures,Dizziness,Balance,Tremors,Nausea,Blackouts,Tasks,Motivation,FinishTasks,Assert,Forgetful,AttentionSpan,AnticipateOthers,ProblemSolving,MentalStamina,Reading,Performance,LanguageDifficulty,Verbal,ImpairedJudgement,Reactions,NotesTimer,AbnormalAnxiety,Rude,Personality,Mood,Depression,Indifference,Fatigue,Shallow,MentalFlex,Note")] Concussion concussion)
        {
            if (id != concussion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concussion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcussionExists(concussion.Id))
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
            return View(concussion);
        }

        // GET: Concussion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Concussion == null)
            {
                return NotFound();
            }

            var concussion = await _context.Concussion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concussion == null)
            {
                return NotFound();
            }

            return View(concussion);
        }

        // POST: Concussion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Concussion == null)
            {
                return Problem("Entity set 'IhpDbContext.Concussion'  is null.");
            }
            var concussion = await _context.Concussion.FindAsync(id);
            if (concussion != null)
            {
                _context.Concussion.Remove(concussion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcussionExists(int id)
        {
          return (_context.Concussion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
