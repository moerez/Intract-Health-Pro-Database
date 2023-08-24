using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models.Documents;
using InteractHealthProDatabase.Models.Enums;
using InteractHealthProDatabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace InteractHealthProDatabase.Controllers
{
    [Route("Document")]
    public class DocumentController : Controller
    {
        private readonly DocumentService _documentService;

        public DocumentController(IhpDbContext context)
        {
            _documentService = new DocumentService(context);
        }

        // GET: Document
        [Route("")]
        public IActionResult Index()
        {
            if (_documentService == null) return Problem("Entity set 'IhpDbContext.Documents'  is null.");

            return View(_documentService.GetAll());
        }

        // GET: Document/Details/5
        [Route("Details/{id?}")]
        public IActionResult Details(int? id)
        {
            try
            {
                if (_documentService == null) throw new ArgumentException("Entity set 'IhpDbContext.Documents'  is null.");
                return View(_documentService.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return Problem(ex.Message);
            }
        }

        [Route("GetPlaceHolder/{id?}")]
        public IActionResult? GetPlaceHolder(int id, int? ClientId)
        {
            ViewBag.ClientId = ClientId;
            switch (id)
            {
                case ((int)DocumentTypeEnum.Request):
                    return PartialView("_DocumentRequestPartial");
                case ((int)DocumentTypeEnum.Form):
                    return PartialView("_DocumentFormPartial");
                case ((int)DocumentTypeEnum.Delivery):
                    return PartialView("_DocumentDeliveryPartial");
                case ((int)DocumentTypeEnum.Recovery):
                    return PartialView("_DocumentRecoveryPartial");
                default:
                    return null;
            }
        }

        [Route("CreateOrEdit/{id?}")]
        public IActionResult CreateOrEdit(int? id, int? ClientId)
        {
            ViewBag.ClientId = ClientId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CreateOrEditDelivery/{id?}")]
        public async Task<IActionResult> CreateOrEditDelivery(int? id, int? ClientId, [Bind("Id,Client,ClientId,DocumentType,DocumentStr,Note,GeneralTreatmentPlan,Ocf18TpReceived,Ocf23MigReceived,DateDeliveredByIhp,To,DeliveryMethod,DeliveryMethodNote,NameOfAssociate")] DocumentDelivery document)
        {
            ViewBag.ClientId = ClientId;
            document.DocumentType = DocumentTypeEnum.Delivery;

            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                await _documentService.AddOrUpdateDeliveryAsync(document, ClientId!.Value);
                return RedirectToAction(nameof(Details), "Client", new { id = ClientId });
            }
            return View(nameof(CreateOrEdit), document);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CreateOrEditForm/{id?}")]
        public async Task<IActionResult> CreateOrEditForm(int? id, int? ClientId, [Bind("Id,Client,ClientId,DocumentType,DocumentStr,Note,RequestDate,CompletionDate,To,Submitted,DateSubmitted")] DocumentForm document)
        {
            ViewBag.ClientId = ClientId;
            document.DocumentType = DocumentTypeEnum.Form;

            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                await _documentService.AddOrUpdateFormAsync(document, ClientId!.Value);
                return RedirectToAction(nameof(Details), "Client", new { id = ClientId });
            }
            return View(nameof(CreateOrEdit), document);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CreateOrEditRecovery/{id?}")]
        public async Task<IActionResult> CreateOrEditRecovery(int? id, int? ClientId, [Bind("Id,Client,ClientId,DocumentType,DocumentStr,Note,GeneralTreatmentPlan,Ocf18TpReceived,Ocf23MigReceived,DateReceivedByIhp,ReceivedFrom,DeliveryMethod,ReceivedBy")] DocumentRecovery document)
        {
            ViewBag.ClientId = ClientId;
            document.DocumentType = DocumentTypeEnum.Recovery;

            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                await _documentService.AddOrUpdateRecoveryAsync(document, ClientId!.Value);
                return RedirectToAction(nameof(Details), "Client", new { id = ClientId });
            }
            return View(nameof(CreateOrEdit), document);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CreateOrEditRequest/{id?}")]
        public async Task<IActionResult> CreateOrEditRequest(int? id, int? ClientId, [Bind("Id,Client,ClientId,DocumentType,DocumentStr,Note,DateSubmitted,To,DeliveryMethod,DeliveryMethodNote,NameOfAssociate")] DocumentRequest document)
        {
            ViewBag.ClientId = ClientId;
            document.DocumentType = DocumentTypeEnum.Request;

            ModelState.Remove("Client");
            if (ModelState.IsValid)
            {
                await _documentService.AddOrUpdateRequestAsync(document, ClientId!.Value);
                return RedirectToAction(nameof(Details), "Client", new { id = ClientId });
            }
            return View(nameof(CreateOrEdit), document);
        }

        // // GET: Document/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null || _context.Documents == null)
        //     {
        //         return NotFound();
        //     }

        //     var document = await _context.Documents
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (document == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(document);
        // }

        // // POST: Document/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     if (_context.Documents == null)
        //     {
        //         return Problem("Entity set 'IhpDbContext.Documents'  is null.");
        //     }
        //     var document = await _context.Documents.FindAsync(id);
        //     if (document != null)
        //     {
        //         _context.Documents.Remove(document);
        //     }

        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }
    }
}
