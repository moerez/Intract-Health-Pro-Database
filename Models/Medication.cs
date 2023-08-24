using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aftab_InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Models


{
    public class Medication
    {
        public int Id { get; set; }
        public MedicalHistoryPreAccident? MedicalHistoryPreAccident { get; set; }
        // Artour : Added the MedicalHistoryPostAccident for Medication to create a link between them
        
        //[NotMapped]
        //public MedicalHistoryPostAccident? MedicalHistoryPostAccident { get; set; }
        public MedicalHistoryAccident? MedicalHistoryAccident { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        [Display(Name = "Medication")]
        public string? Drug { get; set; }
        public string? Doseage { get; set; }
        public DateTime? DateDiagnosed { get; set; }
    }
}
