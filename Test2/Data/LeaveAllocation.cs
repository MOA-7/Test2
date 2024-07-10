using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Data
{
    public class LeaveAllocation:BaseEnitity
    {
    //    public int id { get; set; }
        public int NumberOfDAYS { get; set; }


        [ForeignKey("LeaveTypeid")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeid { get; set; }

        public string Employid { get; set; }





    //    public DateTime datecreat { get; set; }
     //   public DateTime datemodified { get; set; }
    }
}
