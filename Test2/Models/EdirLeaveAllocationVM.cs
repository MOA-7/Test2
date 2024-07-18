namespace Test2.Models
{
    public class EdirLeaveAllocationVM :LeaveAllocationVM
    {
        public string Employeeid { get; set; }
        public int LeaveTypeID { get; set; }
        public EmployListVM? Employee { get; set; }
    }
}
