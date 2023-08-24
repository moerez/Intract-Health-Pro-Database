using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(ContactName), nameof(CellPhone))]
    public class Lawyer : BaseContact
    {
        public int Id { get; set; }

        public ICollection<Case> Cases { get; set; } = new List<Case>();
    }
}