using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Documents
{
    public class DocumentForm : Document
    {
        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }

        public string? To { get; set; }

        public bool Submitted { get; set; }

        // TODO: public IdentityUser SubmittedBy { get; set; }

        [Display(Name = "Date Submitted")]
        [DataType(DataType.Date)]
        public DateTime? DateSubmitted { get; set; }

        public override string GetDocumentType()
        {
            return "MVA Form Completion";
        }
    }
}