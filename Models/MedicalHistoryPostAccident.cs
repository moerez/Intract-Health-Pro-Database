using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InteractHealthProDatabase.Models;

namespace Aftab_InteractHealthProDatabase.Models
{
  public class MedicalHistoryPostAccident
  {
    public int Id { get; set; }
    public Client Client { get; set; } = null!;

    [NotMapped]
    public ICollection<Medication>? Medications { get; set; } = new List<Medication>();

    [Display(Name = "Were you Hospitalized for any Condition")]
    public string? TreatmentCenter { get; set; }
    public DateTime? Appointment { get; set; }
    public string? Doctor { get; set; }

  }
}