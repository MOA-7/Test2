using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test2.Data;

namespace Test2.Models
{
    public class LeaveReqestVM : LeaveReqestCreatVM
    {
        public int id { get; set; }
        // public DateTime StartDate { get; set; }
        // public DateTime EndDate { get; set; }

       //   public LeaveTypeVM LeaveType { get; set; }
        // public string? RequrstComent { get; set; }

        [Display(Name =" Date Request")]
        public DateTime DateRequest { get; set; }
        [Display(Name = " Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }
        public bool? Approve { get; set; }
        public bool CDancele { get; set; }
        public string?  Requestingemployeeid { get; set; }
        public EmployListVM EmployListVM { get; set; }
    }
}
