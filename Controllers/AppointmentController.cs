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
    public class AppointmentController : Controller
    {
        private readonly IhpDbContext _context;

        public AppointmentController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: Appointment
        public async Task<IActionResult> Index(int? clientId)
        {
            var appointment = await _context.Appointments.Include(a => a.Client).Where(a => a.Client.Id == clientId).ToListAsync();

            ViewBag.ClientId = clientId;
            return View(appointment);
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/CreateOrEdit
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {
            if (clientId == null)
                return NotFound("The Client Id cannot be null");

            Appointment appointment = new();

            if (id != null) // Editing an existing record
            {
                // Get the BodyPart Detail from the DB
                appointment = await _context.Appointments
                  .Include(apt => apt.Client)
                  .Where(apt => apt.Id == id)
                  .FirstOrDefaultAsync() ?? appointment;

                if (appointment == null)
                    return NotFound("Appointment not found in the database.");
            }
            //else
            //{
            //    //Get the BodyPart Detail from the DB

            //   appointment = await _context.Appointments
            //     .Where(apt => apt.Client.Id == clientId)
            //     .Include(apt => apt.Client)
            //     .FirstOrDefaultAsync() ?? appointment;

            //    if (appointment == null)
            //        return NotFound("Appointment not found in the database.");
            //}
            ViewBag.ClientId = appointment.Client?.Id ?? clientId;
            return View("CreateOrEdit", appointment);
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId, [Bind("Id,Title,Description,Duration,Start")] Appointment appointment)
        {
            ViewBag.ClientId = clientId ?? appointment.Client.Id;
            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                Client? client = await _context.Clients.Where(c => c.Id == clientId).FirstOrDefaultAsync();
                if (client == null)
                {
                    ModelState.AddModelError("Client", "Client ID not found");
                    return View(appointment);
                }
                if (id != null)
                {
                    // Update
                    _context.Entry(appointment).State = EntityState.Modified;
                    _context.Update(appointment!);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Client", new { Id = clientId });
                }
                else
                {

                    appointment.Client = client;
                    appointment.Client!.Appointments?.Add(appointment);
                    _context.Add(appointment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Client", new { Id = clientId });
                }
            }
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Duration,Start")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'IhpDbContext.Appointments'  is null.");
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
