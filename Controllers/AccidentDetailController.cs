using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Controllers
{
    public class AccidentDetailController : Controller
    {
        private readonly IhpDbContext _context;

        public AccidentDetailController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: AccidentDetail
        public async Task<IActionResult> Index()
        {
            return _context.AccidentDetails != null ?
                        View(await _context.AccidentDetails.ToListAsync()) :
                        Problem("Entity set 'IhpDbContext.AccidentDetails'  is null.");
        }

        // GET: AccidentDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccidentDetails == null)
            {
                return NotFound();
            }

            var accidentDetail = await _context.AccidentDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accidentDetail == null)
            {
                return NotFound();
            }

            return View(accidentDetail);
        }

        // GET: AccidentDetail/CreateOrEdit
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {
            // Check if we have an id for the AccidentDetail or an Id for the client
            if (id == null && clientId == null)
                return NotFound("The ID of the client and the Accident Detail file are required to create or edit a Accident file.");

            AccidentDetail accidentDetail = new();
            if (clientId != null) // Editing an existing record from Client page
            {
                // Get the Accident Detail from the DB for that client ID
                accidentDetail = _context.AccidentDetails
                  .Where(ad => ad.Client.Id == clientId)
                  .Include(ad => ad.Client)
                  .FirstOrDefault() ?? accidentDetail;
                if (accidentDetail == null)
                   return NotFound("Accident Detail not found in the database.");

                // Get Accident Vehicle if Accident Detail exist
                if (accidentDetail.Id > 0)
                {
                    accidentDetail.AccidentVehicle = await _context.AccidentVehicles
                      .Where(av => av.AccidentDetail.Id == accidentDetail.Id)
                      .FirstOrDefaultAsync();
                }
            } else if (id != null)   // Come from Accident Detail page
            {
                accidentDetail = _context.AccidentDetails
                  .Where(ad => ad.Id == id)
                  .Include(ad => ad.Client)
                  .FirstOrDefault() ?? accidentDetail;
                if (accidentDetail == null)
                    return NotFound("Accident Detail not found in the database.");
                // Get Accident Vehicle
                accidentDetail.AccidentVehicle = await _context.AccidentVehicles
                  .Where(av => av.AccidentDetail.Id == accidentDetail.Id)
                  .FirstOrDefaultAsync();
            }

            ViewBag.ClientId = accidentDetail.Client?.Id ?? clientId;
            return View("CreateOrEdit", accidentDetail);
        }

        // POST: AccidentDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,AccidentVehicle,DateTimeAcc,MedicalHistoryUrl,FMedVisit,Weather,Visibility,RoadCondition,AccidentLocation,AccidentDesc,PoliceName,PoliceBadgeNo,PoliceDept,PoliceReportAccDate,PoliceReportCenter,PoliceCharge,EmeAtScenePolice,EmeAtSceneAmbulance,EmeAtSceneFirefighters,EmeAtSceneTowing,EmeAtSceneNoOneCame,TakeByAmbulance,Note")] AccidentDetail accidentDetail)
        {
            ViewBag.ClientId = clientId ?? accidentDetail.Client.Id;   // for form
            if (ViewBag.ClientId == null)
            {
                return NotFound("Client Id is required to create/edit a Accident");
            }

            // In the Bind annotation above, we have to include the children models, otherwise they will not be included

            // The client of the children models is null, so we have to exclude it from the validation.
            ModelState.Remove("AccidentVehicle.AccidentDetail");
            ModelState.Remove("Client");
            if (id == 0 || id == null)  // If add Accident Detail, remove validation for AccidentVehicle.Id as null
            {
                ModelState.Remove("AccidentVehicle.Id");
            }
            if (ModelState.IsValid)
            {
                // Add
                // Get the client from the DB
                var client = await _context.Clients.FindAsync(ViewBag.ClientId);
                if (client == null)
                    return NotFound("Client id=" + ViewBag.ClientId + " not found in the database.");

                accidentDetail.Client = client;  // Assign client info to Accident Detail
                if (id == 0 || id == null)
                {
                    _context.Add(accidentDetail);
                    accidentDetail.AccidentVehicle!.AccidentDetail = accidentDetail;
                    _context.Add(accidentDetail.AccidentVehicle);
                    TempData["NotifyMsg"] = string.Format("Accident Detail Record Created for Client ID={0}", accidentDetail.Client.Id);
                }
                else { 
                    // Update
                    _context.Entry(accidentDetail).State = EntityState.Modified;
                    _context.Update(accidentDetail.AccidentVehicle!);
                    TempData["NotifyMsg"] = string.Format("Accident Detail ID={0} updated successfully", accidentDetail.Id);
                } 

                await _context.SaveChangesAsync();
                TempData["NotifyClassName"] = "success"; 
                return RedirectToAction("Details", "Client", new { Id = accidentDetail.Client.Id});
            }
            return View("CreateOrEdit", accidentDetail);
        }

        // GET: AccidentDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccidentDetails == null)
            {
                return NotFound();
            }

            var accidentDetail = await _context.AccidentDetails.FindAsync(id);
            if (accidentDetail == null)
            {
                return NotFound();
            }
            return View(accidentDetail);
        }

        // POST: AccidentDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTimeAcc,MedicalHistoryUrl,FMedVisit,Weather,Visibility,RoadCondition,AccidentLocation,AccidentDesc,PoliceName,PoliceBadgeNo,PoliceDept,PoliceReportAccDate,PoliceReportCenter,PoliceCharge,EmeAtScenePolice,EmeAtSceneAmbulance,EmeAtSceneFirefighters,EmeAtSceneTowing,EmeAtSceneNoOneCame,TakeByAmbulance,Note")] AccidentDetail accidentDetail)
        {
            if (id != accidentDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accidentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccidentDetailExists(accidentDetail.Id))
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
            return View(accidentDetail);
        }

        // GET: AccidentDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccidentDetails == null)
            {
                return NotFound();
            }

            var accidentDetail = await _context.AccidentDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accidentDetail == null)
            {
                return NotFound();
            }

            return View(accidentDetail);
        }

        private void CreateNotifyMsg(string notifyMsg, string notifyClassName)
        {
            TempData["NotifyMsg"] = notifyMsg;
            TempData["NotifyClassName"] = notifyClassName;
        }

        // POST: AccidentDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accidentDetail = await _context.AccidentDetails.FindAsync(id);
            if (accidentDetail == null)
            {
                CreateNotifyMsg(string.Format("Failed to find Accident Detail ID={0}", id), "error");
                return new JsonResult(new { result = false });
            }

            try
            {
                _context.AccidentDetails.Remove(accidentDetail);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                // For .notify
                CreateNotifyMsg(string.Format("Accident Detail ID={0} deleted successfully", id), "success");
                return new JsonResult(new { result = true });
            }
            catch (Exception ex)
            {
                CreateNotifyMsg(ex.Message, "error");
                return new JsonResult(new { result = false });
            }
        }

        private bool AccidentDetailExists(int id)
        {
            return (_context.AccidentDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
