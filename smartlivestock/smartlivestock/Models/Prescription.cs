﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace smartlivestock.Models
{
    public class Prescription
    {
        [Key]
        public int PresId { get; set; }
        public string PresName { get; set; }
        public DateTime PresDate { get; set; }
        public string UrName { get; set; }


        [ForeignKey("Registration")]
        public int? RegistrationId { get; set; }
        public virtual Registration Registration { get; set; }


        [ForeignKey("ChiefComplaint")]
        public int? ChiefComplaintId { get; set; }
        public virtual ChiefComplaint ChiefComplaint { get; set; }
        
        
        [ForeignKey("GeneralExamination")]
        public int? GeneralExaminationId { get; set; }
        public virtual GeneralExamination GeneralExamination { get; set; }
        
        
        [ForeignKey("Diagnosis")]
        public int? DiagnosisId { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }

        [ForeignKey("Invastigation")]
        public int? InvastigationId { get; set; }
        public virtual Invastigation Invastigation { get; set; }


        [ForeignKey("Medicine")]
        public int? MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }

        [ForeignKey("Doses")]
        public int? DosesId { get; set; }
        public virtual Doses Doses { get; set; }

        [ForeignKey("Advice")]
        public int? AdviceId { get; set; }
        public virtual Advice Advice { get; set; }


        [ForeignKey("FlowUp")]
        public int? FlowUpId { get; set; }
        public virtual FlowUp FlowUp { get; set; }

        [ForeignKey("ReferredTo")]
        public int? ReferredId { get; set; }
        public virtual ReferredTo ReferredTo { get; set; }


        [ForeignKey("ShortNote")]

        public int? ShortNotePresId { get; set; }
        public virtual ShortNote ShortNote {  get; set; }

        [ForeignKey("Species")]
        public int? SpeciesId { get; set; }
        public virtual Species Species { get; set; }
        public String? SpeciesGender { get; set; }
        public int? SpeciesAges { get; set; }
        public int? SpeciesQuentity { get; set; }

        public string? DurationType { get; set; }
        public int? Duration { get; set; }

        public string? AditionalNotes { get; set; }

        public int? Sokal {  get; set; }
        public int? Duput { get; set; }
        public int? Rat {  get; set; }
        public string? TypeOfAge { get; set; }



    }
}
