using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Data
{
    public class LeaveRequest : BaseEnitity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("LeaveTypeid")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeid { get; set; }
        public DateTime DateRequest { get; set; }
        public string? RequrstComent { get; set; }

        public bool? Approve { get; set; }
        public bool CDancele { get; set; }

        public string RequestEmployID { get; set; }

    }
}
