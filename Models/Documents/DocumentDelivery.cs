using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InteractHealthProDatabase.Models.Enums;

namespace InteractHealthProDatabase.Models.Documents
{
    public class DocumentDelivery : Document
    {
        [Display(Name = "General Treatment Plan")]
        public bool GeneralTreatmentPlan { get; set; }

        [Display(Name = "OCF-18 TP Received")]
        public bool Ocf18TpReceived { get; set; }

        [Display(Name = "OCF-23 MIG Received")]
        public bool Ocf23MigReceived { get; set; }

        [Display(Name = "Date Delievered by IHP")]
        [DataType(DataType.Date)]
        public DateTime? DateDeliveredByIhp { get; set; }

        public string? To { get; set; }

        [Display(Name = "Delivery Method")]
        public DeliveryMethodEnum DeliveryMethod { get; set; }

        [Display(Name = "Delivery Method Note")]
        public string? DeliveryMethodNote { get; set; }

        [Display(Name = "Name of Associate")]
        public string? NameOfAssociate { get; set; }

        public static new string GetDocumentType()
        {
            return "DELIVERY of Letters - Treatment Plan - Advisory Reports";
        }
    }
}