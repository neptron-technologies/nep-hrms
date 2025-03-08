using AutoMapper;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
