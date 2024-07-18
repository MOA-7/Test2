using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test2.Data;

namespace Test2.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int id { get; set; }

        [Display (Name ="Number od Days ")]
        [Required]
        [Range(1,25 , ErrorMessage ="Invalid Number user range 1-25")] 
        public int NumberOfDAYS { get; set; }
        [Required]
        [Display(Name = "Allocation Period")]

        public int period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }


    }
}