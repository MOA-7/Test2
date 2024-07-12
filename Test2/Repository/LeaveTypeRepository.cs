using Test2.Contract;
using Test2.Data;

namespace Test2.Repository
{
    public class LeaveTypeRepository : GenricRepostory<LeaveType>, IleaveRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
