
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using MailKit.Net.Imap;

namespace InteractHealthProDatabase.Services
{
    public class EventService
    {
        private IhpDbContext _context;
        private ImapClient _imapClient;
        private IConfiguration _configuration;
        private ILogger _logger;

        public EventService(IhpDbContext context, ImapClient imapClient, IConfiguration configuration, ILogger logger)
        {
            _context = context;
            _imapClient = imapClient;
            _configuration = configuration;
            _logger = logger;
        }

        public void UpdateEvents()
        {
            MailKitService mailKitService = new MailKitService(_imapClient, _context, _configuration, _logger);

            ICollection<EmailMessage> emails = mailKitService.GetUnreadEmails();
            ICollection<EventViewModel> events = new List<EventViewModel>();

            foreach (var email in emails)
            {
                events.Add(new EventViewModel()
                {
                    Title = email.Subject,
                    PublicId = email.ClientId,
                    Start = DateToEventString(email.DateTime),
                    End = DateToEventString(email.DateTime),
                    AllDay = false
                });
            }

            _context.Events.AddRange(events);
            _context.SaveChanges();
        }

        private string DateToEventString(DateTimeOffset date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        internal object? GetEvents()
        {
            UpdateEvents();
            return _context.Events.ToList();
        }
    }
}