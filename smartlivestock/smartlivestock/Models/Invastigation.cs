using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class Invastigation
    {
        [Key]
        public int InvId { get; set; }
        public string InvName { get; set;}
        public DateTime InvDate { get; set; }
        public string UrName { get; set; }
    }
}
