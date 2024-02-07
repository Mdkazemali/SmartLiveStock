using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class FlowUp
    {
        [Key]
        public int FloId { get; set; }
        public string FloName { get; set; }
        public DateTime FloDate { get; set; }
        public string UrName { get; set; }
    }
}
