using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace smartlivestock.Models
{
    public class UserInformation
    {
        [Key]
        public int UserinfoId { get; set; }
        public string UserFullName { get; set; }
        public string Gender { get; set; }
        public int? PhoneNumber { get; set; }
        public ulong? NID { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Status { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string LoginId { get; set; }
        public string TranjectionId { get; set; }
        public string Designation { get; set; }
        public string Degree { get; set; }
        public string DVMRegiNo { get; set; }
        public string KhamarType { get; set; }




        public string? PhotoUrl { get; set; }


        [Display(Name = "Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }

        [NotMapped]
        public string? BreifPhotoName { get; set; }
    }
}
