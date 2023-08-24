using InteractHealthProDatabase.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models
{
    public class ClientMVA
    {

        public int Id { get; set; }
        public Client Client { get; set; } = null!;

        [Display(Name = "Date File Opened")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Dob { get; set; }
        public string? OHIP { get; set; }
        public GenderEnum? Gender { get; set; }
        public bool Consent { get; set; }

        [Display(Name = "Dominant Hand")]
        public string? DominantHand { get; set; } 
        public string? Height { get; set; }
        public string? Weight { get; set; }

        [Display(Name = "Marital Status")]
        public MaritalStatusEnum? MaritalStatus { get; set; }

        [Display(Name = "Is Home Rented or Owned")]
        public AccommodationEnum? Accommodation { get; set; }

        [Display(Name = "Type of Accommodation")]
        public AccommodationTypeEnum? AccommodationType { get; set; }

        [Display(Name = "Tell us who you live with")]
        public string? Household { get; set; }

        [Display(Name = "Emergency Contacts Name")]
        public string? EmergencyContactName { get; set; }

        [Display(Name = "Relationship to Client")]
        public string? Relationship { get; set; }

        [Display(Name = "Emergency Contacts Cell Number")]
        public string? CellPhone { get; set; }

        [Display(Name = "Is an Interpreter Required")]
        public string? Interpreter { get; set; }

        [Display(Name = "Clients Prefered Language")]
        public string? PreferredLanguage { get; set; }

        [Display(Name = "Please Give Age and Gender of any Children")]
        public string? Children { get; set; }
        public string? Notes { get; set; }

    }
}
