using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class Registration
    {
        [Key]
        public int RegiId { get; set; }
        public string Name { get; set; }
        public string PtnId { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Ages { get; set; }
        public DateTime CreateDAte { get; set; }= DateTime.Now;
        public string UsrName { get; set; }
    }
}
