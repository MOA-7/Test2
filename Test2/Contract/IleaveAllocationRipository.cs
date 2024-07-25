using Test2.Data;
using Test2.Models;

namespace Test2.Contract
{
    public interface IleaveAllocationRipository :IgenricRepostory<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExist(string employID, int leavetypeid, int period);
        Task<EmployeAllocationVM> GetEmployeAllocations(string employID);
        Task<LeaveAllocation?> GetEmployeAllocation(string employID,int leavetypeid);
        Task<EdirLeaveAllocationVM> GetEmployeAllocation(int id);
        Task<bool> UPDATEEmployeAllocation(EdirLeaveAllocationVM model);
    }
}
