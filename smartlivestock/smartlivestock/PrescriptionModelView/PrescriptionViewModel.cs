
using smartlivestock.Models;
using smartlivestock.Controllers;

namespace smartlivestock.Models
{
    public class PrescriptionViewModel
    {
        //Advices
        public string AdvName { get; set; }
        public DateTime AdvDate { get; set; }
        public string UrName { get; set; }


        // Chip Complaint
     
        public string ChiName { get; set; }
        public DateTime CreateDt { get; set; }
        public string UsrName { get; set; }

        //Diagnosis

 
        public string DiagName { get; set; }

        //Doses



        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool Evening { get; set; }
        public int Days { get; set; }
        public string DosesName { get; set; }

        //Flowup

        public string FloName { get; set; }

        //General Examination

        public string ExamName { get; set; }

        //Invastigation

        public string InvName { get; set; }

        //Medication

        public string MedName { get; set; }

        //Registration

        public string Name { get; set; }
        public string PtnId { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Ages { get; set; }

        //Prescriptions
        public int PresId { get; set; }
        public string PresName { get; set; }
        public DateTime PresDate { get; set; }

        public int RegistrationId { get; set; }
        public virtual Registration Registration { get; set; }
        public int ChiefComplaintId { get; set; }
        public virtual ChiefComplaint ChiefComplaint { get; set; }

        public int GeneralExaminationId { get; set; }
        public virtual GeneralExamination GeneralExamination { get; set; }

        public int DiagnosisId { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public int InvastigationId { get; set; }
        public virtual Invastigation Invastigation { get; set; }

        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Doses Doses { get; set; }
        public int AdviceId { get; set; }
        public virtual Advice Advice { get; set; }
        public int FlowUpId { get; set; }
        public virtual FlowUp FlowUp { get; set; }

       

        public int? Sokal { get; set; }
        public int? Duput { get; set; }
        public int? Rat { get; set; }

        public int ReferredId { get; set; }
        public string ReferredName { get; set; }
        public List<Prescription> Prescriptions { get; set; }

        public List<Prescription> PrescriptionsList { get; set; }

        public Prescription SinglePrescrip { get; set; }

        public List<PrescriptionViewModel> TotalPrescriptionview { get; set;}




    }
}







