using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Mappers
{
    public class LeaveMapper: Profile
    {
        public LeaveMapper() {
            CreateMap<EmpLeave, EmpLeaveCancelled>();

            CreateMap<EmpLeaveCancelled, EmpLeaveCancelDto>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) 
             .ForMember(dest => dest.EmpId, opt => opt.MapFrom(src => src.EmpId))
             .ForMember(dest => dest.LeaveType, opt => opt.MapFrom(src => src.LeaveType))
             .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
             .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
             .ForMember(dest => dest.NoOfDays, opt => opt.MapFrom(src => src.NoOfDays))
             .ForMember(dest => dest.ApprovedStatus, opt => opt.MapFrom(src => src.ApprovedStatus))
             .ForMember(dest => dest.ApprovedBy, opt => opt.MapFrom(src => src.ApprovedBy))
             .ForMember(dest => dest.LeaveDesc, opt => opt.MapFrom(src => src.LeaveDesc))
             .ForMember(dest => dest.ApprovedDesc, opt => opt.MapFrom(src => src.ApprovedDesc))
             .ForMember(dest => dest.CanceledStatus, opt => opt.MapFrom(src => src.CanceledStatus))
             .ForMember(dest => dest.CanceledOn, opt => opt.MapFrom(src => src.CanceledOn))
             .ReverseMap(); 
        }
    }
}
