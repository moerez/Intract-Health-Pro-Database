using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InteractHealthProDatabase.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(RefNo), nameof(OtherRefNo))]
    public class HealthFile
    {
        public int Id { get; set; }

        public Client Client { get; set; } = null!;

        [NotMapped]
        [Display(Name = "Health Company")]
        public int? SelectedHealthCompanyId { get; set; }

        [Display(Name = "Health Company")]
        public HealthCompany HealthCompany { get; set; } = null!;

        [Display(Name = "Ref No")]
        public string? RefNo { get; set; }

        [Display(Name = "Other Ref No")]
        public string? OtherRefNo { get; set; }

        [Display(Name = "Type of Appointment")]
        public VisitTypeEnum? TypeOfAppointment { get; set; }

        [Display(Name = "Date of Appointment")]
        public DateTime? DateTime { get; set; } = null!;
    }
}