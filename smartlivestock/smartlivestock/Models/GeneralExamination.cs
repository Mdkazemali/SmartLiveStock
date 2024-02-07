using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class GeneralExamination
    {
        [Key]
        public int GenId { get; set; }
        public string  ExamName { get; set; }
        public DateTime CreateDt { get; set; }
        public string UsrName { get; set; }
    }
}
