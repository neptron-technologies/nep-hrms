using AutoMapper;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Mappers
{
    public class EmpMapper : Profile
    {
        public EmpMapper()
        {
            CreateMap<Employee, EmployeeDto>(); //.ReverseMap();

            CreateMap<EmployeeDto, Employee>();

        }
    }
}
