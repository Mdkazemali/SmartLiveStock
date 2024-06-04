using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class ShortNote
    {
        [Key]
        public int ShortId { get; set; }
        public string ShortNoteName { get; set; }
        public string SrUser { get; set; }
        public DateTime ShortDt { get; set; }
    }
}
