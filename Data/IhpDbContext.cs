using InteractHealthProDatabase.Models;
using InteractHealthProDatabase.Models.Documents;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Aftab_InteractHealthProDatabase.Models;

namespace InteractHealthProDatabase.Data
{
    public class IhpDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Lawyer> Lawyers { get; set; } = null!;
        public DbSet<AccidentDetail> AccidentDetails { get; set; } = null!;
        public DbSet<AccidentVehicle> AccidentVehicles { get; set; } = null!;
        public DbSet<Case> Cases { get; set; } = null!;
        public DbSet<HealthFile> HealthFiles { get; set; } = null!;
        public DbSet<HealthCompany> HealthCompanies { get; set; } = null!;
        public DbSet<HealthCompanyContact> HealthCompanyContacts { get; set; } = null!;
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; } = null!;
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; } = null!;
        public DbSet<InsuranceCompanyContact> InsuranceCompanyContacts { get; set; } = null!;
        public DbSet<WorkHistory> WorkHistory { get; set; } = null!;
        public DbSet<Concussion> Concussion { get; set; } = default!;
        public DbSet<ClientMVA> ClientMVA { get; set; } = default!;
        public DbSet<Dependent> Dependent { get; set; } = default!;
        public DbSet<Pet> Pet { get; set; } = default!;
        public DbSet<MedicalHistoryPreAccident> MedicalHistoryPreAccident { get; set; } = default!;
        public DbSet<MedicalHistoryPreAccident> MedicalHistoryPostAccident { get; set; } = default!;
        public DbSet<Medication> Medication { get; set; } = default!;
        public DbSet<MedicalHistoryAccident> MedicalHistoryAccident { get; set; } = default!;
        public DbSet<BodyPart> BodyPart { get; set; } = default!;
        public DbSet<Psychotherapy> Psychotherapies { get; set; } = default!;
        public DbSet<EventViewModel> Events { get; set; } = default!;
        public DbSet<Document> Documents { get; set; } = default!;
        public DbSet<DocumentForm> DocumentForms { get; set; } = default!;
        public DbSet<DocumentRequest> DocumentRequests { get; set; } = default!;
        public DbSet<DocumentDelivery> DocumentDeliveries { get; set; } = default!;
        public DbSet<DocumentRecovery> DocumentRecoveries { get; set; } = default!;

        public IhpDbContext(DbContextOptions<IhpDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>().UseTpcMappingStrategy();
            builder.Entity<Lawyer>().UseTpcMappingStrategy();
            builder.Entity<HealthCompanyContact>().UseTpcMappingStrategy();
            builder.Entity<InsuranceCompanyContact>().UseTpcMappingStrategy();
            builder.Entity<MedicalHistoryPreAccident>().UseTpcMappingStrategy();

            builder.Entity<Document>().ToTable("Documents").Property(p => p.Id).UseSequence("DocumentsSequence");
            builder.Entity<DocumentForm>().ToTable("DocumentForms").Property(p => p.Id).UseSequence("DocumentsSequence");
            builder.Entity<DocumentRequest>().ToTable("DocumentRequests").Property(p => p.Id).UseSequence("DocumentsSequence");
            builder.Entity<DocumentDelivery>().ToTable("DocumentDeliveries").Property(p => p.Id).UseSequence("DocumentsSequence");
            builder.Entity<DocumentRecovery>().ToTable("DocumentRecoveries").Property(p => p.Id).UseSequence("DocumentsSequence");
        }

        public DbSet<Aftab_InteractHealthProDatabase.Models.MedicalHistoryPostAccident> MedicalHistoryPostAccident_1 { get; set; } = default!;

        public DbSet<InteractHealthProDatabase.Models.BodyTrauma> BodyTrauma { get; set; } = default!;
    }
}