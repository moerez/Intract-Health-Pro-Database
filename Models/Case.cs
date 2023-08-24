using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(CaseRef), nameof(OtherRef))]
    public class Case
    {
        public int Id { get; set; }

        public Client Client { get; set; } = null!;

        public Lawyer Lawyer { get; set; } = null!;

        [Display(Name = "Case Ref")]
        public string? CaseRef { get; set; }

        [Display(Name = "Other Ref")]
        public string? OtherRef { get; set; }
    }
}