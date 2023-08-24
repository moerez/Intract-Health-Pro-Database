using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteractHealthProDatabase.Models
{
  public class MedicalHistoryPreAccident
  {

    public int Id { get; set; }
    public Client Client { get; set; } = null!;

    [NotMapped]
    public ICollection<Medication>? Medications { get; set; } = new List<Medication>();

    [Display(Name = "Were you Hospitalized for any Condition")]
    public bool Hospitalized { get; set; }

    public string? HospitalizedCondition { get; set; }

    [Display(Name = "Asthma")]
    public bool Asthma { get; set; }

    [Display(Name = "Arthritis")]
    public bool Arthritis { get; set; }

    [Display(Name = "Diabetes")]
    public bool Diabetes { get; set; }

    [Display(Name = "HeartAttack/Stroke")]
    public bool HeartStroke { get; set; }

    [Display(Name = "Thyroid")]
    public bool Thyroid { get; set; }

    [Display(Name = "Other")]
    public bool Other { get; set; }

    [Display(Name = "Cancer")]
    public bool Cancer { get; set; }

    [Display(Name = "None")]
    public bool None { get; set; }

    public string? Note { get; set; }

  }
}
