using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class Diagnosis
    {
        [Key]
        public int DiagId { get; set; }
        public string DiagName { get; set; }
        public DateTime CreateDt { get; set; }
        public string UsrName { get; set; }
    }
}
