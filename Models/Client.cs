using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aftab_InteractHealthProDatabase.Models;
using InteractHealthProDatabase.Models.Documents;
using InteractHealthProDatabase.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(ContactName), nameof(Email), nameof(CellPhone))]
    public class Client : BaseContact
    {
        public int Id { get; set; }

        public ReferralEnum? Referral { get; set; }

        [NotMapped]
        public AccidentDetail? AccidentDetail { get; set; }

        [NotMapped]
        public ICollection<Document> Documents { get; set; } = new List<Document>();

        [NotMapped]
        public Case? Case { get; set; }

        [NotMapped]
        public ICollection<HealthFile> HealthFile { get; set; } = new List<HealthFile>();

        [NotMapped]
        public ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();

        [NotMapped]
        public InsuranceClaim? InsuranceClaim { get; set; } = new InsuranceClaim();

        [NotMapped]
        public Psychotherapy? Psychotherapy { get; set; }

        [NotMapped]
        public Concussion? Concussion { get; set; }

        [NotMapped]
        public ClientMVA? ClientMVA { get; set; }

        [NotMapped]
        public Dependent? Dependent { get; set; }


        [NotMapped]
        public Pet? Pet { get; set; }




        [NotMapped]
        public MedicalHistoryAccident? MedicalHistoryAccident { get; set; }

        [NotMapped]
        public WorkHistory? WorkHistory { get; set; }

        [NotMapped]
        public BodyPart? BodyPart { get; set; }

        // Artour : Body Trauma part is missing from the database
        [NotMapped]
        public BodyTrauma? BodyTrauma { get; set; }

        // Artour : putting both pre and post accident in client to assure the joint
        [NotMapped]
        public MedicalHistoryPreAccident? MedicalHistoryPreAccident { get; set; }
        
        [NotMapped]
        public MedicalHistoryPostAccident? MedicalHistoryPostAccident { get; set; }
    }
}