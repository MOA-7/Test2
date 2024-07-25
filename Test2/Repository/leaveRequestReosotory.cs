using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Test2.Contract;
using Test2.Data;
using Test2.Models;

namespace Test2.Repository
{
    public class leaveRequestReosotory : GenricRepostory<LeaveRequest>, IleaveRequestReosotory
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Employ> userManager;
        private readonly IleaveAllocationRipository ileaveAllocationRipository;

        public leaveRequestReosotory(ApplicationDbContext context 
            , IMapper mapper ,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Employ> userManager,
            IleaveAllocationRipository ileaveAllocationRipository
            ) : base(context) 
        {
            this.ileaveAllocationRipository = ileaveAllocationRipository;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task CanceleLeaveRequest(int leaveRequestid)
        {
            var leaveRequest = await GetAsync(leaveRequestid);
            leaveRequest.CDancele = true;
            await UpdateAsync(leaveRequest);
        }




        public async Task changeAprooveStatuse(int leavRequestID, bool aprroved)
        {
            var leaveRequest = await GetAsync( leavRequestID );
            leaveRequest.Approve = aprroved;
            if (aprroved) 
            { 
               var allocation = await ileaveAllocationRipository.GetEmployeAllocation
                    (leaveRequest.RequestEmployID,leavRequestID);
                 //   (leaveRequest.RequestEmployID,leaveRequest.LeaveTypeid);
                int dayRequest = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                 allocation.NumberOfDAYS -= dayRequest;

                ileaveAllocationRipository.UpdateAsync(allocation);
            }

             await UpdateAsync(leaveRequest);
        }




        public async Task<bool> CreateLeaveRequest(LeaveReqestCreatVM model)
        {
            var user =await userManager.GetUserAsync(httpContextAccessor?.HttpContext.User);
            var leaveallocation = await ileaveAllocationRipository.GetEmployeAllocation(user.Id, model.LeaveTypeid);

            if (leaveallocation == null)
            {
                return false;
            }

            int dayRequest = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            if (dayRequest > leaveallocation.NumberOfDAYS)
            {
                return false;
            }

            var LeaveRequest = mapper.Map<LeaveRequest>(model);
            LeaveRequest.DateRequest = DateTime.Now;
            LeaveRequest.RequestEmployID = user.Id;
            await AddAsync(LeaveRequest);
            return true;
        }

        public async Task<AdminLeaveRequestVIEWVM> GetAdminLeaveReqquestList()
        {
            var LeaveRequest = await context.LeaveRequests.Include( q=> q.LeaveType).ToListAsync();
            //  var LeaveRequest = await GetAllAsync();
            var model = new AdminLeaveRequestVIEWVM
            {
                totalRequest = LeaveRequest.Count,
                AprovvedRequesr = LeaveRequest.Count(Q => Q.Approve == true),
                PendilingRequest = LeaveRequest.Count(q => q.Approve == null),
                RejectRequest = LeaveRequest.Count(q => q.Approve == false),
                leaveReqests = mapper.Map<List<LeaveReqestVM>>(LeaveRequest),
            };

            foreach (var item in model.leaveReqests)
            {
                item.EmployListVM = mapper.Map<EmployListVM>(await userManager.FindByIdAsync(item.Requestingemployeeid));
            }

            return model;
        }



        public async Task<List<LeaveRequest>> GetAllAsync(string employeid)
        {
            return await context.LeaveRequests.Where(w => w.RequestEmployID == employeid).ToListAsync();
        }

        public async Task<LeaveReqestVM?> GetLeaveRequesatAsync(int? id)
        {
            var leaveRequest = await context.LeaveRequests.Include(q=> q.LeaveType).FirstOrDefaultAsync(q=> q.id==id);
            
            if(leaveRequest == null)
            {
                return null;
            }


            var model =mapper.Map<LeaveReqestVM>(leaveRequest);
            model.EmployListVM = mapper.Map<EmployListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestEmployID));
            return model;
        }   

        public async Task<EmployLeaveRequestVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var allocations = ( await ileaveAllocationRipository.GetEmployeAllocations(user.Id)).LeaveAllication;
            var request = mapper.Map<List<LeaveReqestVM>>(await GetAllAsync(user.Id));

            var model = new EmployLeaveRequestVM
            {
                LeaveAllocations = allocations,
                leaveReqests = request,
            };
            return model;
        }
    }
}
