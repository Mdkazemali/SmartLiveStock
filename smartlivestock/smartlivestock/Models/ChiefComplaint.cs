using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class ChiefComplaint
    {
        [Key]
        public int ChiId { get; set; }
        public string ChiName { get; set;}
        public DateTime CreateDt { get; set; }
        public string UsrName { get; set; }
    }
}
