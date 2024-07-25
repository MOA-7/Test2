using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Test2.Contract;
using Test2.Data;
using Test2.Models;

namespace Test2.Repository
{
    public class LeaveAllocationRepository : GenricRepostory<LeaveAllocation>, IleaveAllocationRipository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Employ> userManager;
        private readonly IleaveRepository leaveRepository;
        private readonly IMapper mapper;

        public LeaveAllocationRepository(ApplicationDbContext context
            ,UserManager<Employ> userManager , IleaveRepository ileaveRepository,IMapper mapper ) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
           leaveRepository = ileaveRepository;
            this.mapper = mapper; 
        }

        public async Task<bool> AllocationExist(string employID, int leavetypeid, int period)
        {
            return await context.LeaveAllocations.AnyAsync(q => q.Employid == employID &&
                                                                         q.LeaveTypeid == leavetypeid &&
                                                                         q.period == period
                                                                         );
        }



        public async Task<EmployeAllocationVM> GetEmployeAllocations(string employID )
       {
           var Allocation = await context.LeaveAllocations
               .Include(q => q.LeaveType)
               .Where(q => q.Employid == employID)
                .ToListAsync();
            var employee = await userManager.FindByIdAsync(employID);


            var employallocationModel = mapper.Map<EmployeAllocationVM>(employee);
            employallocationModel.LeaveAllication = mapper.Map<List<LeaveAllocationVM>>(Allocation);
            
            return employallocationModel;
        }


        
        public async Task<EdirLeaveAllocationVM> GetEmployeAllocation(int id)
        {
            var Allocation = await context.LeaveAllocations
                .Include(q => q.LeaveType)
              .FirstOrDefaultAsync(q => q.id == id);

              if (Allocation == null)
            {
                return null;
            }
            var employee = await userManager.FindByIdAsync(Allocation.Employid);


            var model = mapper.Map<EdirLeaveAllocationVM>(Allocation);
            model.Employee = mapper.Map<EmployListVM>(await userManager.FindByIdAsync(Allocation.Employid));
            
            return model;
        }




        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync("User");
            
            var period = DateTime.Now.Year;

            var leavetype = await leaveRepository.GetAsync(leaveTypeId);

            var allocation = new List<LeaveAllocation>();
            foreach (var employ in employees) {


                if (await AllocationExist (employ.Id, leaveTypeId, period))
                     continue;
                
                 allocation.Add( new LeaveAllocation
                {
                    Employid = employ.Id,
                    LeaveTypeid = leaveTypeId,
                    period = period,
                    NumberOfDAYS = leavetype.DefultDays


                   
                });
           //   await  AddAsync(allocation);
            }
            await AddRangeAsync(allocation);


          //  throw new NotImplementedException();
        }

        public async Task<bool> UPDATEEmployeAllocation(EdirLeaveAllocationVM model)
        {
            var leaveAllocation = await GetAsync(model.id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.period = model.period;
            leaveAllocation.NumberOfDAYS = model.NumberOfDAYS;
            await UpdateAsync(leaveAllocation);
            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeAllocation(string employID, int leavetypeid)
        {
           return await context.LeaveAllocations.FirstOrDefaultAsync(q => q.Employid == employID
                && q.LeaveTypeid == leavetypeid
            );
        }
    }
}
