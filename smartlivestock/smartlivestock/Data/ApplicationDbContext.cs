using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using smartlivestock.Models;

namespace smartlivestock.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trainingvideo> Trainingvideo { get; set; }
        public virtual DbSet<UserInformation> UserInformation { get; set; }
        public object UserInformations { get; internal set; }
        public virtual DbSet<Advice> Advices { get;  set; }
        public virtual DbSet<ChiefComplaint> ChiefComplaint { get; set; }
        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Doses> Doses { get; set; }
        public virtual DbSet<FlowUp> FlowUp { get; set; }
        public virtual DbSet<GeneralExamination> GeneralExamination { get; set;}
        public virtual DbSet<Invastigation> Invastigations { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }

        public virtual DbSet<ReferredTo> ReferredTo { get; set; }

        public virtual DbSet<FacilityRegistry> FacilityRegistry { get; set;}

        public virtual DbSet<ShortNote> ShortNotes { get; set; }
    }
}
