using System.ComponentModel.DataAnnotations;
using InteractHealthProDatabase.Models.Enums;

namespace InteractHealthProDatabase.Models.Documents
{
    public class DocumentRequest : Document
    {
        [Display(Name = "Date Submitted")]
        [DataType(DataType.Date)]
        public DateTime? DateSubmitted { get; set; }

        public string? To { get; set; }

        [Display(Name = "Delivery Method")]
        public DeliveryMethodEnum DeliveryMethod { get; set; }

        [Display(Name = "Delivery Method Note")]
        public string? DeliveryMethodNote { get; set; }

        [Display(Name = "Name of Associate")]
        public string? NameOfAssociate { get; set; }

        public override string GetDocumentType()
        {
            return "REQUEST for Treatment Plan & Advisory Reports";
        }
    }
}