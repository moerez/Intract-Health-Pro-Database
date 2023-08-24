using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(Title), nameof(ContactName), nameof(Telephone))]
    public class InsuranceCompanyContact : BaseContact
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [NotMapped]
        public int InsuranceCompanyId1 { get; set; }

        [Display(Name = "Insurance Company")]
        public InsuranceCompany InsuranceCompany { get; set; } = null!;
    }
}