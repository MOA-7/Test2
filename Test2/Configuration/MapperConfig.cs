using AutoMapper;
using Test2.Data;
using Test2.Models;

namespace Test2.Configuration
{
    public class MapperConfig : Profile 
    {
        public MapperConfig() {

            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        
        }
    }
}
