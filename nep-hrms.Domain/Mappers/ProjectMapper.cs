using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Mappers
{
    public class ProjectMapper : Profile        //added on 13-03-25
    {
        public ProjectMapper()
        {
            //CreateMap<Project, ProjectDto>();
            //    //.ForMember(dest => dest.Fname, opt => opt.MapFrom(src => src.Employees != null ? src.Employees.Fname : "N/A"));
            //CreateMap<ProjectDto, Project>();
            CreateMap<Project, ProjectDto>();
            // .ForMember(dest => dest.Employees, opt => opt.Ignore()); // Ignore Employees for Project CRUD
            CreateMap<ProjectDto, Project>();
        }
    }
}