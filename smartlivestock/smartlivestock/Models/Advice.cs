using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class Advice
    {
        [Key]
        public int AdvId { get; set; }
        public string AdvName { get; set; }
        public DateTime AdvDate { get; set; }
        public string UrName { get; set; }
    }
}
