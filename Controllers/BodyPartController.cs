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
    public class BodyPartController : Controller
    {
        private readonly IhpDbContext _context;

        public BodyPartController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: BodyPart
        public async Task<IActionResult> Index()
        {
              return _context.BodyPart != null ? 
                          View(await _context.BodyPart.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.BodyPart'  is null.");
        }

        // GET: BodyPart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BodyPart == null)
            {
                return NotFound();
            }

            var bodyPart = await _context.BodyPart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyPart == null)
            {
                return NotFound();
            }

            return View(bodyPart);
        }

        // GET: BodyPart/CreateOrEdit
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {
            if (clientId == null)
                return NotFound("The Client Id is null");

            BodyPart bodyPart = new BodyPart();

            if (id != null) // Editing an existing record
            {
                // Get the BodyPart Detail from the DB
                bodyPart = await _context.BodyPart
                  .Include(bp => bp.Client)
                  .Where(bp => bp.Id == id)
                  .FirstOrDefaultAsync() ?? bodyPart;
                
                if (bodyPart == null)
                    return NotFound("BodyPart not found in the database.");
            } else {
                // Get the BodyPart Detail from the DB
                bodyPart = await _context.BodyPart
                  .Where(bp => bp.Client.Id == clientId)
                  .Include(bp => bp.Client)
                  .FirstOrDefaultAsync() ?? bodyPart;
                
                if (bodyPart == null)
                    return NotFound("BodyPart not found in the database.");
            }

            ViewBag.ClientId = bodyPart.Client?.Id ?? clientId;
            return View("CreateOrEdit", bodyPart);
        }

        // POST: BodyPart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,Concussion,Fracture,DiscHerniation,GeneralNotes,HeadR,HeadL,HeadF,HeadB,FaceR,FaceL,Jaw,Teeth,HeadNotes,Neck,UpBack,UpBackR,UpBackL,MidBack,MidBackR,MidBackL,LowBack,LowBackR,LowBackL,ShoulderR,ShoulderL,NeckAndBackNotes,UpArmR,UpArmL,ElbowR,ElbowL,ForearmR,ForearmL,WristR,WristL,HandR,HandL,FingersR,FingersL,ArmNotes,ChestR,ChestL,RibsR,RibsL,ButtocksR,ButtocksL,TorsoNotes,HipR,HipL,ThighR,ThighL,UpLegR,UpLegL,LowLegRt,LowLegR,KneeR,KneeL,AnkleR,AnkleL,FootR,FootL,ToesR,ToesL,LegNotes,TingRArm,TingLArm,NumbRHand,NumbLHand,PainRArm,PainLArm,TingRLeg,TingLLeg,NumbRLeg,NumbLLeg,PainRLeg,PainLLeg,OtherNotes")] BodyPart bodyPart)
        {

            ViewBag.ClientId = clientId ?? bodyPart.Client.Id;  
            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                Client? client = await _context.Clients.Where(c => c.Id == clientId).FirstOrDefaultAsync();
                if (client == null)
                {
                    ModelState.AddModelError("Client", "Client ID not found");
                    return View(bodyPart);
                }
                bodyPart.Client = client;
                bodyPart.Client!.BodyPart = bodyPart;
                if (id != null)
                {
                    // Update
                    _context.Entry(bodyPart).State = EntityState.Modified;
                    _context.Update(bodyPart!);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Client", new { Id = bodyPart.Client.Id});
                }
                else
                {
                    _context.Add(bodyPart);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Client", new { Id = bodyPart.Client.Id});
                }
            }
            return View(bodyPart);
            
        }

        // GET: BodyPart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BodyPart == null)
            {
                return NotFound();
            }

            var bodyPart = await _context.BodyPart.FindAsync(id);
            if (bodyPart == null)
            {
                return NotFound();
            }
            return View(bodyPart);
        }

        // POST: BodyPart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Concussion,Fracture,DiscHerniation,HeadR,HeadL,HeadF,HeadB,FaceR,FaceL,Jaw,Teeth,Neck,UpBack,UpBackR,UpBackL,MidBack,MidBackR,MidBackL,LowBack,LowBackR,LowBackL,ShoulderR,ShoulderL,UpArmR,UpArmL,ElbowR,ElbowL,ForearmR,ForearmL,WristR,WristL,HandR,HandL,FingersR,FingersL,ChestR,ChestL,RibsR,RibsL,ButtocksR,ButtocksL,HipR,HipL,ThighR,ThighL,UpLegR,UpLegL,LowLegRt,LowLegR,KneeR,KneeL,AnkleR,AnkleL,FootR,FootL,ToesR,ToesL,TingRArm,TingLArm,NumbRHand,NumbLHand,PainRArm,PainLArm,TingRLeg,TingLLeg,NumbRLeg,NumbLLeg,PainRLeg,PainLLeg")] BodyPart bodyPart)
        {
            if (id != bodyPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyPartExists(bodyPart.Id))
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
            return View(bodyPart);
        }

        // GET: BodyPart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BodyPart == null)
            {
                return NotFound();
            }

            var bodyPart = await _context.BodyPart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyPart == null)
            {
                return NotFound();
            }

            return View(bodyPart);
        }

        // POST: BodyPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BodyPart == null)
            {
                return Problem("Entity set 'IhpDbContext.BodyPart'  is null.");
            }
            var bodyPart = await _context.BodyPart.FindAsync(id);
            if (bodyPart != null)
            {
                _context.BodyPart.Remove(bodyPart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyPartExists(int id)
        {
          return (_context.BodyPart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
