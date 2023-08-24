using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(Title))]
    public class InsuranceCompany
    {
        public int Id { get; set; }

        public ICollection<InsuranceClaim> InsuranceClaims { get; set; } = new List<InsuranceClaim>();

        [Display(Name = "Insurance Company Name")]
        public string? Title { get; set; }

        [Display(Name = "Insurance Company Address")]
        public string? Address { get; set; }
        
        [Display(Name = "Insurance Company Telephone")]
        public string? Telephone { get; set; }
        
        [Display(Name = "Insurance Company Fax")]
        public string? Fax { get; set; }

        [NotMapped]
        public ICollection<InsuranceCompanyContact> InsuranceCompanyContacts { get; set; } = new List<InsuranceCompanyContact>();
    }
}