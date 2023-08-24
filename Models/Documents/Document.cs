using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InteractHealthProDatabase.Models.Enums;

namespace InteractHealthProDatabase.Models.Documents
{
    public class Document
    {
        public int Id { get; set; }

        public Client Client { get; set; } = null!;

        [NotMapped]
        [Required]
        [Display(Name = "Document Type")]
        public DocumentTypeEnum DocumentType { get; set; }

        [Display(Name = "Document")]
        public string DocumentStr { get; set; } = null!;

        public string? Note { get; set; }


        public virtual string GetDocumentType()
        {
            return "Document";
        }

        [NotMapped]
        public static string[] PersonsArr = new string[] {
            "Insurance" ,
            "Lawyer" ,
            "Rehab" ,
            "Assessment",
            "Doctor",
            "Client"
        };
    }
}