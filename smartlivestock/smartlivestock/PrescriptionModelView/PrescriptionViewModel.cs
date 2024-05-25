
using smartlivestock.Models;
using smartlivestock.Controllers;

namespace smartlivestock.Models
{
    public class PrescriptionViewModel
    {


        //For Facility Register

        public int FacilityId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationType { get; set; }
        public string FacilityEmail { get; set; }
        public string FacilityMobile { get; set; }
        public string FacilityHeadInfomations { get; set; }
        public string DivisionName { get; set; }
        public string DistricName { get; set; }
        public string CityCorporationName { get; set; }
        public string UpozillaName { get; set; }
        public string UnionName { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string FaUserName { get; set; }
        public string? FalPhotoUrl { get; set; }
        public string? FarPhotoUrl { get; set; }



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

        public string ReName { get; set; }
        public string PtnId { get; set; }
        public string Phone { get; set; }
        public string GenderRe { get; set; }
        public string Ages { get; set; }
        // for Dr informationss
        public int UserinfoId { get; set; }
        public string UserFullName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public ulong? NID { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Status { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string LoginId { get; set; }
        public string TranjectionId { get; set; }
        public string Designation { get; set; }
        public string Degree { get; set; }
        public string PassingYear { get; set; }
        public string Designations { get; set; }
        public string Institute { get; set; }
        public string PresentAddrss { get; set; }
        public string EmailNo { get; set; }
        public string Facebook { get; set; }
        public string Website { get; set; }

        public string NagadNo { get; set; }
        public string Bkash { get; set; }
        public string Roket { get; set; }


        public string DVMRegiNo { get; set; }
        public string KhamarType { get; set; }


        public string BarcodeBase64 { get; set; }

        public string? PhotoUrl { get; set; }


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







