using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Services
{
    public class ClientService
    {
        private readonly IhpDbContext _context;

        public ClientService(IhpDbContext context)
        {
            _context = context;
        }

        public Client? FindClientByName(string input)
        {
            //Find first Client where all words in ContactName match all words in input
            var clients = _context.Clients.ToList();
            foreach (var client in clients)
            {
                string[] names = client.ContactName.Split(' ');
                if (names.All(name => input.ToLower().Contains(name.ToLower())))
                    return client;
            }
            return null;
        }
    }
}