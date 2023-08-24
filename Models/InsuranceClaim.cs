using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using InteractHealthProDatabase.Models.Enums;


namespace InteractHealthProDatabase.Models
{
    [Index(nameof(Claimref), nameof(OtherClaimRef))]
    public class InsuranceClaim
    {
        public int Id { get; set; }

        public Client Client { get; set; } = null!;

        [NotMapped]
        [Display(Name = "Insurance Company")]
        public int? SelectedInsuranceCompanyId { get; set; }

        [Display(Name = "Insurance Company")]
        public InsuranceCompany InsuranceCompany { get; set; }
        
        [Display(Name ="Claim Ref")]
        public string? Claimref { get; set; } = null!;

        [Display(Name = "Other Claim Ref")]
        public string? OtherClaimRef { get; set; } = null!;
    }
}