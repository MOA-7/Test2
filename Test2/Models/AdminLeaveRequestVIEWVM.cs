using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class AdminLeaveRequestVIEWVM
    {
        [Display(Name =" Total Number df request")]
        public int totalRequest { get; set; }


        [Display(Name =" Approverd Request")]
        public int AprovvedRequesr { get; set; }


        [Display(Name = " pendiling request")]
        public int PendilingRequest { get; set; } 


       [Display(Name =" Reject request")]
        public int RejectRequest { get; set; }

        public List<LeaveReqestVM> leaveReqests { get; set; }
    }
}
