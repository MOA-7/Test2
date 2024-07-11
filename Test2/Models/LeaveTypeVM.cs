using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class LeaveTypeVM
    {
        public int id { get; set; }
        public string named { get; set; }
        [Display(Name ="Defult Number of day")]
        [Range(1,25,ErrorMessage ="1--25")]
        public int DefultDays { get; set; }
    }
}
