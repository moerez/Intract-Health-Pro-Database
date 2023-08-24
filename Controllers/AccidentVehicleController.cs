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
    public class AccidentVehicleController : Controller
    {
        private readonly IhpDbContext _context;

        public AccidentVehicleController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: AccidentVehicle
        public async Task<IActionResult> Index()
        {
              return _context.AccidentVehicles != null ? 
                          View(await _context.AccidentVehicles.ToListAsync()) :
                          Problem("Entity set 'IhpDbContext.AccidentVehicles'  is null.");
        }

        // GET: AccidentVehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccidentVehicles == null)
            {
                return NotFound();
            }

            var accidentVehicle = await _context.AccidentVehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accidentVehicle == null)
            {
                return NotFound();
            }

            return View(accidentVehicle);
        }

        // GET: AccidentDetail/CreateOrEdit
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {
            // Check if we have an id for the AccidentDetail or an Id for the client
            if (id == null && clientId == null)
                return NotFound("The ID of the client and the Accident Detail file are required to create or edit a Accident file.");

            AccidentVehicle accidentVehicle = new();
            if (clientId != null) // Editing an existing record from Client page
            {
                // Get the Accident Detail from the DB for that client ID
                accidentVehicle = _context.AccidentVehicles
                  .Where(ad => ad.AccidentDetail.Id == clientId)
                  .Include(ad => ad.AccidentDetail)
                  .FirstOrDefault() ?? accidentVehicle;
                if (accidentVehicle == null)
                    return NotFound("Accident Vehicle not found in the database.");

                // Get Accident Details if Accident Vehicle exist
                if (accidentVehicle.Id > 0)
                {
                    accidentVehicle.AccidentDetail = await _context.AccidentDetails
                      .Where(av => av.Client.Id == clientId)
                      .FirstOrDefaultAsync();
                }
            }
            else if (id != null)   // Come from Accident Detail page
            {
                accidentVehicle = _context.AccidentVehicles
                  .Where(ad => ad.Id == id)
                  .Include(ad => ad.AccidentDetail)
                  .FirstOrDefault() ?? accidentVehicle;
                if (accidentVehicle == null)
                    return NotFound("Accident Detail not found in the database.");
                // Get Accident Detail
                accidentVehicle.AccidentDetail = await _context.AccidentDetails
                      .Where(av => av.Client.Id == clientId)
                      .FirstOrDefaultAsync();
            }

            ViewBag.ClientId = accidentVehicle.AccidentDetail?.Id ?? clientId;
            return View("CreateOrEdit", accidentVehicle);
        }

        // POST: AccidentVehicle/CreateOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,TransportType,DriverPosition,Make,Model,Year,License,VehiclePersName,VehicleNoPeople,OtherLiableParties,Seatbelt,AirbagDeploy,Bracing,Anticipated,MvaCoName,MvaPolicyNo,MvaClaimNo,MvaAdjuster,MvaTel,MvaFax,MvaEmail,MvaAddress,MvaCity,MvaProv,MvaPC,InsuranceUrl")] AccidentVehicle accidentVehicle)
        {
            ViewBag.ClientId = clientId ?? accidentVehicle.AccidentDetail.Client.Id;   // for form
            if (ViewBag.ClientId == null)
            {
                return NotFound("Client Id is required to create/edit a Accident");
            }
            
            // In the Bind annotation above, we have to include the children models, otherwise they will not be included

            // The accident detail of the children models is null, so we have to exclude it from the validation.
            ModelState.Remove("AccidentDetail");

            if (id == 0 || id == null)  // If add Accident Vehicle, remove validation for Id as null
            {
                ModelState.Remove("AccidentDetail.Id");
            }

            if (ModelState.IsValid)
            {
                if (id == 0 || id == null)
                {
                    // Add
                    // Get the accident detail from the DB
                    var accidentDetail = await _context.AccidentDetails.FindAsync(ViewBag.ClientId);
                    if (accidentDetail == null)
                        return NotFound("Client id=" + ViewBag.ClientId + " not found in the database.");

                    accidentVehicle.AccidentDetail = accidentDetail;  // Assign client info to Accident Detail
                    _context.Add(accidentVehicle);
                    accidentVehicle.AccidentDetail!.AccidentVehicle = accidentVehicle;
                    _context.Add(accidentVehicle.AccidentDetail);
                    TempData["NotifyMsg"] = string.Format("Accident Vehicle Record Created for Client ID={0}", clientId);
                } else {
                    // Update
                    _context.Entry(accidentVehicle).State = EntityState.Modified;
                    _context.Update(accidentVehicle.AccidentDetail!);
                    TempData["NotifyMsg"] = string.Format("Accident Detail ID={0} updated successfully", accidentVehicle.Id);
                }
                await _context.SaveChangesAsync();
                TempData["NotifyClassName"] = "success";
                return RedirectToAction("Details", "Client", new { Id = accidentVehicle.AccidentDetail.Client.Id});
            }
            return View("CreateOrEdit", accidentVehicle);
        }

        // GET: AccidentVehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccidentVehicles == null)
            {
                return NotFound();
            }

            var accidentVehicle = await _context.AccidentVehicles.FindAsync(id);
            if (accidentVehicle == null)
            {
                return NotFound();
            }
            return View(accidentVehicle);
        }

        // POST: AccidentVehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransportType,DriverPosition,Make,Model,Year,License,VehiclePersName,VehicleNoPeople,OtherLiableParties,Seatbelt,AirbagDeploy,Bracing,Anticipated,MvaCoName,MvaPolicyNo,MvaClaimNo,MvaAdjuster,MvaTel,MvaFax,MvaEmail,MvaAddress,MvaCity,MvaProv,MvaPC,InsuranceUrl")] AccidentVehicle accidentVehicle)
        {
            if (id != accidentVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accidentVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccidentVehicleExists(accidentVehicle.Id))
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
            return View(accidentVehicle);
        }

        // GET: AccidentVehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccidentVehicles == null)
            {
                return NotFound();
            }

            var accidentVehicle = await _context.AccidentVehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accidentVehicle == null)
            {
                return NotFound();
            }

            return View(accidentVehicle);
        }

        // POST: AccidentVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccidentVehicles == null)
            {
                return Problem("Entity set 'IhpDbContext.AccidentVehicles'  is null.");
            }
            var accidentVehicle = await _context.AccidentVehicles.FindAsync(id);
            if (accidentVehicle != null)
            {
                _context.AccidentVehicles.Remove(accidentVehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccidentVehicleExists(int id)
        {
          return (_context.AccidentVehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
