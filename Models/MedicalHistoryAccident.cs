using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aftab_InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Models
{
  public class MedicalHistoryAccident
  {
    public int Id { get; set; }

    public Client Client { get; set; } = null!;

    [NotMapped]
    public ICollection<BodyPart>? BodyPart { get; set; } = new List<BodyPart>();

    [NotMapped]
    public ICollection<Medication>? Medications { get; set; } = new List<Medication>();

    [Display(Name = "Symptoms Onset Date")]
    public DateTime DiagnosisDate {get; set;} = DateTime.Now;

    public string? Name { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Description { get; set; }

    [Display(Name = "Patient's Name")]
    public string? NameOfPatiant { get; set; }

    [Display(Name = "Were you taken from the Scene in an Ambulance?")]
    public bool Ambulance { get; set; }

    [Display(Name = "Was your first visit after the accident to a walk-in clinic?")]
    public bool Walkin { get; set; }

    [Display(Name = "Was there an attending Physician?")]
    public bool Attending { get; set; }

    [Display(Name = "Were any Xrays taken?")]
    public bool Xray { get; set; }
    [NotMapped]
    public MedicalHistoryPreAccident? MedicalHistoryPreAccident { get; set; }
    [NotMapped]
    public MedicalHistoryPostAccident? MedicalHistoryPostAccident { get; set; }


  }
}
