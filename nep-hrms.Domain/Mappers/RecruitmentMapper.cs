using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Mappers;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Mappers
{
    public class RecruitmentMapper : Profile
    {
        public RecruitmentMapper() 
        {
            CreateMap<Recruitment, RecruitmentDTO>();
            CreateMap<RecruitmentDTO, Recruitment>();
        }
    }
}


