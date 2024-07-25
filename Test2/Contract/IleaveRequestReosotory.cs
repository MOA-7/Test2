using Test2.Data;
using Test2.Models;

namespace Test2.Contract
{
    public interface IleaveRequestReosotory : IgenricRepostory<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest (LeaveReqestCreatVM model);
        Task<EmployLeaveRequestVM> GetMyLeaveDetails();
        Task<List<LeaveRequest>> GetAllAsync(string employeid);

        Task<LeaveReqestVM?> GetLeaveRequesatAsync (int? id); 

        Task CanceleLeaveRequest (int leaveRequestid); 

        Task<AdminLeaveRequestVIEWVM> GetAdminLeaveReqquestList();
        Task changeAprooveStatuse(int leavRequestID , bool aprroved);

    }
}
