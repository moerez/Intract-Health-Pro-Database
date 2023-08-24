using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(Title))]
    public class HealthCompany
    {
        public int Id { get; set; }

        [NotMapped]
        public ICollection<HealthCompanyContact>? HealthCompanyContacts { get; set; } = new List<HealthCompanyContact>();

        [NotMapped]
        public ICollection<HealthFile> HealthFiles { get; set; } = new List<HealthFile>();

        [Display(Name = "Company Name")]
        public string Title { get; set; } = null!;
    }
}