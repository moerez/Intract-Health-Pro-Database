using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using InteractHealthProDatabase.Models.Documents;

namespace InteractHealthProDatabase.Services
{
    public class DocumentService
    {
        public IhpDbContext _context { get; set; }

        public DocumentService(IhpDbContext context)
        {
            _context = context;
        }

        public bool DocumentExists(int id)
        {
            return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public List<Document> GetAll()
        {
            return _context.Documents.ToList();
        }

        public Document GetById(int? id)
        {
            if (id == null)
                throw new ArgumentException("id is required.");
            Document? document = _context.Documents.Where(d => d.Id == id).FirstOrDefault();
            if (document == null)
                throw new NullReferenceException("Document not found.");
            return document;
        }

        // TODO: Merge these into 1
        internal async Task<DocumentForm> AddOrUpdateFormAsync(DocumentForm document, int ClientId)
        {
            Client? client = _context.Clients.Where(c => c.Id == ClientId).FirstOrDefault();
            if (client == null)
                throw new NullReferenceException("Client not found.");
            document.Client = client;
            _context.DocumentForms.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }
        internal async Task<DocumentDelivery> AddOrUpdateDeliveryAsync(DocumentDelivery document, int ClientId)
        {
            Client? client = _context.Clients.Where(c => c.Id == ClientId).FirstOrDefault();
            if (client == null)
                throw new NullReferenceException("Client not found.");
            document.Client = client;
            _context.DocumentDeliveries.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }
        internal async Task<DocumentRecovery> AddOrUpdateRecoveryAsync(DocumentRecovery document, int ClientId)
        {
            Client? client = _context.Clients.Where(c => c.Id == ClientId).FirstOrDefault();
            if (client == null)
                throw new NullReferenceException("Client not found.");
            document.Client = client;
            _context.DocumentRecoveries.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }
        internal async Task<DocumentRequest> AddOrUpdateRequestAsync(DocumentRequest document, int ClientId)
        {
            Client? client = _context.Clients.Where(c => c.Id == ClientId).FirstOrDefault();
            if (client == null)
                throw new NullReferenceException("Client not found.");
            document.Client = client;
            _context.DocumentRequests.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }
    }
}