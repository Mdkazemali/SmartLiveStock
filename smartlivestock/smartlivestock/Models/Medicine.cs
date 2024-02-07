using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class Medicine
    {
        [Key]
        public int MedId { get; set; }
        public string MedName { get; set; }
        public DateTime MedDate { get; set; }
        public string UrName { get; set; }
    }
}
