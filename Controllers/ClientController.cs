using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace InteractHealthProDatabase.Controllers
{
    public class ClientController : Controller
    {
        private readonly IhpDbContext _context;

        public ClientController(IhpDbContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index(Client client)
        {

            return _context.Clients != null ?
                        View(await _context.Clients.ToListAsync()) :
                        Problem("Entity set 'IhpDbContext.Clients'  is null.");
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            // Artour : added to view attributes

            // Load Appointments and Healthfiles
            client.Appointments = _context.Appointments.Where(apt => apt.Client.Id == id).ToList();

            // Load Health files
            client.HealthFile = _context.HealthFiles.Where(hf => hf.Client.Id == id).ToList();

            //Load Insurance claim
            client.InsuranceClaim = await _context.InsuranceClaims.Where(insc => insc.Client.Id == id).FirstOrDefaultAsync();

            client.ClientMVA = await _context.ClientMVA.Where(cmva => cmva.Client.Id == id).FirstOrDefaultAsync();

            client.Dependent = await _context.Dependent.Where(cdep => cdep.Client.Id == id).FirstOrDefaultAsync();

            client.Pet = await _context.Pet.Where(cpet => cpet.Client.Id == id).FirstOrDefaultAsync();

            client.AccidentDetail = await _context.AccidentDetails.Where(cacc => cacc.Client.Id == id).FirstOrDefaultAsync();

            client.BodyTrauma = await _context.BodyTrauma.Where(cbdtrauma =>cbdtrauma.Client.Id == id).FirstOrDefaultAsync();

            client.WorkHistory = await _context.WorkHistory.Where(cwh => cwh.Client.Id == id).FirstOrDefaultAsync();

            if(client.AccidentDetail != null)
                client.AccidentDetail.AccidentVehicle = await _context.AccidentVehicles.Where(av => av.AccidentDetail.Id == client.AccidentDetail.Id).FirstOrDefaultAsync();

            client.MedicalHistoryAccident = await _context.MedicalHistoryAccident.Where(mha => mha.Client.Id == id).FirstOrDefaultAsync();

            client.MedicalHistoryPreAccident = await _context.MedicalHistoryPreAccident.Where(mhprea => mhprea.Client.Id == id).FirstOrDefaultAsync();

            client.MedicalHistoryPostAccident = await _context.MedicalHistoryPostAccident_1.Where(mhposta => mhposta.Client.Id == id).FirstOrDefaultAsync();

            client.InsuranceClaim = await _context.InsuranceClaims.Where(ic => ic.Client.Id == id).FirstOrDefaultAsync();

            if (client.InsuranceClaim != null) {
                List<InsuranceCompany> comp = new();
                comp = _context.InsuranceCompanies.ToList();
                foreach(InsuranceCompany inscomp in comp)
                {
                    List<InsuranceClaim> claims = inscomp.InsuranceClaims.ToList();
                    foreach(InsuranceClaim insclaim in claims)
                    {
                        if(insclaim.Client.Id == id)
                        {
                            client.InsuranceClaim.InsuranceCompany = insclaim.InsuranceCompany;
                            client.InsuranceClaim.InsuranceCompany.InsuranceCompanyContacts = insclaim.InsuranceCompany.InsuranceCompanyContacts;
                        }

                    }
                }
            }
            // Artour : end of added code

            client.BodyPart = await _context.BodyPart.FirstOrDefaultAsync(bp => bp.Client.Id == client.Id);

            client.Concussion = await _context.Concussion.FirstOrDefaultAsync(con => con.Client.Id == client.Id);

            client.Psychotherapy = await _context.Psychotherapies.FirstOrDefaultAsync(ps => ps.Client.Id == client.Id);

            client.Documents = await _context.Documents.Where(d => d.Client.Id == client.Id).ToListAsync();
            return View(client);

            
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/CreateOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, [Bind("Id,ClientMVA,Pet,Dependent,InsuranceClaim,Referral,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] Client client)
        {
            // In the Bind annotation above, we have to include the children models, otherwise they will not be included

            // The client of the children models is null, so we have to exclude it from the validation.
            ModelState.Remove("Pet");
            ModelState.Remove("Dependent");
            ModelState.Remove("ClientMVA");
            ModelState.Remove("InsuranceClaim");
            ModelState.Remove("Pet.Client");
            ModelState.Remove("Dependent.Client");
            ModelState.Remove("ClientMVA.Client");
            ModelState.Remove("InsuranceClaim.Client");
            ModelState.Remove("InsuranceClaim.InsuranceCompany");
            if (id == null)
            {
                ModelState.Remove("Pet.Id");
                ModelState.Remove("Dependent.Id");
                ModelState.Remove("ClientMVA.Id");
            }

            if (ModelState.IsValid)
            {
                if (id != null)
                {
                    _context.Entry(client).State = EntityState.Modified;
                    _context.Update(client.Pet!);
                    _context.Update(client.Dependent!);
                    _context.Update(client.ClientMVA!);
                    //_context.Entry(client.Pet!).State = EntityState.Modified;
                    //_context.Entry(client.Dependent!).State = EntityState.Modified;
                    //_context.Entry(client.ClientMVA!).State = EntityState.Modified;
                }
                else
                {
                    _context.Add(client);

                    // We have to set the client of the children models, otherwise it will be null
                    client.Pet!.Client = client;
                    client.Dependent!.Client = client;
                    client.ClientMVA!.Client = client;

                    _context.Add(client.Pet);
                    _context.Add(client.Dependent);
                    _context.Add(client.ClientMVA);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> CreateOrEdit(int? id, int? clientId)
        {

            Client client = new Client();
            if (id != null)
            {
                client = _context.Clients
               .Where(c => c.Id == id)
               .FirstOrDefault() ?? client;

                /*_context.Entry(client)
                    .Reference(c => c.ClientMVA)
                    .Load();
                _context.Entry(client)
                    .Reference(c => c.Dependent)
                    .Load();
                _context.Entry(client)
                    .Reference(c => c.Pet)
                    .Load();*/
                client.ClientMVA = await _context.ClientMVA
                .Where(cmva => cmva.Client.Id == id)
                .FirstOrDefaultAsync();
                client.Dependent = await _context.Dependent
                .Where(cdep => cdep.Client.Id == id)
                .FirstOrDefaultAsync();
                client.Pet = await _context.Pet
                .Where(cpet => cpet.Client.Id == id)
                .FirstOrDefaultAsync();
            }
            await _context.Clients.FindAsync(id);
            return View(client);

            /*if (id == null || _context.Clients == null)
              {
                  return NotFound();
              }

              var 
              if (client == null)
              {
                  return NotFound();
              }
              return View(client); */
        }


        /*// POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]public async Task<IActionResult> Edit(int id, [Bind("Id, Pet,Dependent,ClientMVA,Referral,ContactName,Email,CellPhone,Telephone,Fax,Address,City,Region,Country,PostalCode")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }*/

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'IhpDbContext.Clients'  is null.");
            }
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
