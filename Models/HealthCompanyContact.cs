using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(Title), nameof(ContactName), nameof(Telephone))]
    public class HealthCompanyContact : BaseContact
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [NotMapped]
        public int HealthCompanyId1 { get; set; }

        [Display(Name = "Health Company")]
        public HealthCompany HealthCompany { get; set; } = null!;
    }
}