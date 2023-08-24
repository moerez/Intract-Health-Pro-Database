using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;

namespace InteractHealthProDatabase.Services
{
    public class MailKitService
    {
        private readonly ImapClient _client;
        private readonly IhpDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;


        public MailKitService(ImapClient client, IhpDbContext context, IConfiguration configuration, ILogger logger)
        {
            _client = client;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public List<EmailMessage> GetUnreadEmails()
        {
            Authenticate();

            //TODO: Fix email authentication
            if(!_client.IsAuthenticated)
                return new List<EmailMessage>();

            var inbox = _client.Inbox;
            inbox.Open(FolderAccess.ReadWrite);
            Dictionary<UniqueId, MimeMessage> inMessages = new Dictionary<UniqueId, MimeMessage>();
            foreach (UniqueId uid in _client.Inbox.Search(SearchQuery.NotSeen))
            {
                MimeMessage message = _client.Inbox.GetMessage(uid);
                inMessages.Add(uid, message);
            }

            var outMessages = new List<EmailMessage>();

            List<Client> clients = _context.Clients.ToList();
            foreach (Client client in clients)
            {
                string[] clientNameArr = client.ContactName.Split(' ');
                foreach (var uid in inMessages.Keys)
                {
                    MimeMessage message = inMessages[uid];
                    if (clientNameArr.All(name => message.Subject.ToLower().Contains(name.ToLower())))
                    {
                        EmailMessage emailMessage = new EmailMessage()
                        {
                            Uid = message.MessageId,
                            ClientId = client.Id,
                            Client = client,
                            Subject = message.Subject,
                            Body = message.TextBody,
                            DateTime = message.Date.DateTime
                        };
                        outMessages.Add(emailMessage);
                        inbox.AddFlags(uid, MessageFlags.Seen, true);
                    }
                }
            }
            Disconnect(true);
            return outMessages;
        }

        // TODO: Link calendar to ClientId

        private void Authenticate()
        {
            try
            {
                //Appsettings
                _client.Connect(
                    _configuration["Email:Host"]!,
                    int.Parse(_configuration["Email:Port"]!),
                    bool.Parse(_configuration["Email:UseSsl"]!)
                    );

                // User secrets -> https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows
                _client.Authenticate(
                    _configuration["ihp_email_username"]!,
                    _configuration["ihp_email_password"]!);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error conencting to email server", ex);
                // throw new Exception("Error connecting to email server", ex);
            }
        }

        private void Disconnect(bool quit)
        {
            _client.Disconnect(quit);
        }
    }
}

// Setup email forwarding from gmail to outlook
// Disable notification emails on outlook
// Set secrets for email & password
