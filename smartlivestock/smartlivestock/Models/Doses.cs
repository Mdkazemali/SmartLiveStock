using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class Doses
    {
        [Key]
        public int DosesId { get; set; }

        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool Evening { get; set; }
        public int Days { get; set; }


        public string DosesName { get; set; }
        public DateTime DosesDate { get; set; }
        public string UrName { get; set; }
    }
}
