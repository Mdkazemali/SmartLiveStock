using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using smartlivestock.Models;
using System.ComponentModel.DataAnnotations;
using System.Configuration;



namespace smartlivestock
{
    public class UserRoleViewModel
    {

        public string UserName { get; set; }
        public List<IdentityRole> Roles { get; set; }
  
        public List<string> UserRoles { get; set; }
        public List<string> SelectedRoles { get; set; }


       // UserRoles

        public string Id { get; set; }
        public string RoleName { get; set; }

        public  int RoleCount { get; set; }

        // For UserRoles

        public string UserId { get; set; }
        public  List<Trainingvideo> VideoDataList {  get; set; }

        //for User INformation 

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
        public string DVMRegiNo { get; set; }
        public string KhamarType { get; set; }
        public string? PhotoUrl { get; set; }



    }
}







