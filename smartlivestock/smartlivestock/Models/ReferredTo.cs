using System.ComponentModel.DataAnnotations;

namespace smartlivestock.Models
{
    public class ReferredTo
    {
        [Key]
        public int ReferredId { get; set; }
        public string ReferredName { get; set;}

        public DateTime createDate { get; set; }=DateTime.Now;
        public string UserName { get; set; }
    }
}
