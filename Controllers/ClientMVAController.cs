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
  public class ClientMVAController : Controller
  {
    private readonly IhpDbContext _context;

    public ClientMVAController(IhpDbContext context)
    {
      _context = context;
    }

    // GET: ClientMVA
    public async Task<IActionResult> Index()
    {
      return _context.ClientMVA != null ?
                  View(await _context.ClientMVA.ToListAsync()) :
                  Problem("Entity set 'IhpDbContext.ClientMVA'  is null.");
    }

    // GET: ClientMVA/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.ClientMVA == null)
      {
        return NotFound();
      }

      var clientMVA = await _context.ClientMVA
          .FirstOrDefaultAsync(m => m.Id == id);
      if (clientMVA == null)
      {
        return NotFound();
      }

      return View(clientMVA);
    }

    // GET: ClientMVA/CreateOrEdit
    public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
    {
      // Check if we have an id for the AccidentDetail or an Id for the client
      if (id == null && clientId == null)
        return NotFound("The ID of the client and the Accident Detail file are required to create or edit a Accident file.");

      ClientMVA clientMVA = new ClientMVA();
      if (id != null) // Editing an existing record
      {
        // Get the Accident Detail from the DB
        clientMVA = _context.ClientMVA
          .Where(ad => ad.Id == id)
          .Include(ad => ad.Client)
          .FirstOrDefault() ?? clientMVA;
        if (clientMVA == null)
          return NotFound("ClientMVA not found in the database.");
      }

      ViewBag.ClientId = clientMVA.Client?.Id ?? clientId;
      return View("CreateOrEdit", clientMVA);
    }














    // POST: ClientMVA/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,DateCreated,Dob,OHIP,Gender,Consent,DominantHand,Height,Weight,MaritalStatus,Accommodation,AccommodationType,Household,EmergencyContactName,Relationship,CellPhone,Interpreter,PreferredLanguage,Children,Notes")] ClientMVA clientMVA)
    {
      ViewBag.ClientId = clientId ?? clientMVA.Client.Id;   // for form
      if (ViewBag.ClientId == null)
      {
        return NotFound("Client Id is required to create/edit a ClientMVA");
      }

      // The client of the children models is null, so we have to exclude it from the validation.
      ModelState.Remove("Client");
      var FormMode = "";
      if (ModelState.IsValid)
      {
        if (id != null)
        {
          // Update
          _context.Entry(clientMVA).State = EntityState.Modified;
          FormMode = "Updated";
        }
        else
        {
          // Add
          _context.Add(clientMVA);
          FormMode = "Created";
        }

        await _context.SaveChangesAsync();
        TempData["AlertMessage"] = string.Format("Client ID={0} ClientMVA ID={1} Record {2} Successfully", ViewBag.ClientId, id, FormMode);
        return RedirectToAction(nameof(Index));
      }
      return View("CreateOrEdit", clientMVA);
    }

    // GET: ClientMVA/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.ClientMVA == null)
      {
        return NotFound();
      }

      var clientMVA = await _context.ClientMVA.FindAsync(id);
      if (clientMVA == null)
      {
        return NotFound();
      }
      return View(clientMVA);
    }

    // POST: ClientMVA/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,DateCreated,Dob,OHIP,Gender,Consent,DominantHand,Height,Weight,MaritalStatus,Accommodation,AccommodationType,Household,EmergencyContactName,Relationship,CellPhone,Interpreter,PreferredLanguage,Children,Notes")] ClientMVA clientMVA)
    {
      if (id != clientMVA.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(clientMVA);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ClientMVAExists(clientMVA.Id))
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
      return View(clientMVA);
    }

    // GET: ClientMVA/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.ClientMVA == null)
      {
        return NotFound();
      }

      var clientMVA = await _context.ClientMVA
          .FirstOrDefaultAsync(m => m.Id == id);
      if (clientMVA == null)
      {
        return NotFound();
      }

      return View(clientMVA);
    }

    // POST: ClientMVA/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.ClientMVA == null)
      {
        return Problem("Entity set 'IhpDbContext.ClientMVA'  is null.");
      }
      var clientMVA = await _context.ClientMVA.FindAsync(id);
      if (clientMVA != null)
      {
        _context.ClientMVA.Remove(clientMVA);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ClientMVAExists(int id)
    {
      return (_context.ClientMVA?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
