using System.ComponentModel.DataAnnotations;
using InteractHealthProDatabase.Models.Enums;

namespace InteractHealthProDatabase.Models.Documents
{
    public class DocumentRecovery : Document
    {
        [Display(Name = "General Treatment Plan")]
        public bool GeneralTreatmentPlan { get; set; }

        [Display(Name = "OCF-18 TP Received")]
        public bool Ocf18TpReceived { get; set; }

        [Display(Name = "OCF-23 MIG Received")]
        public bool Ocf23MigReceived { get; set; }

        [Display(Name = "Date Received by IHP")]
        [DataType(DataType.Date)]
        public DateTime? DateReceivedByIhp { get; set; }

        [Display(Name = "Received From")]
        public string? ReceivedFrom { get; set; }

        [Display(Name = "Received via")]
        public DeliveryMethodEnum DeliveryMethod { get; set; }

        [Display(Name = "Received By")]
        public string? ReceivedBy { get; set; }

        public override string GetDocumentType()
        {
            return "RECOVERY/Pick up of Letters";
        }
    }
}