using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepo projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> GetProjectsByEmpId(int empId)
        {
            var projects = await _projectRepo.GetProjectsByEmpId(empId);
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task<ProjectDto?> GetProjectWithEmployeesAsync(int projectId)
        {
            var project = await _projectRepo.GetProjectWithEmployeesAsync(projectId);
            return project != null ? _mapper.Map<ProjectDto>(project) : null;
        }

        public async Task<List<EmployeeDto>> GetEmployeesByProjectId(int projectId)
        {
            var employees = await _projectRepo.GetEmployeesByProjectId(projectId);
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<ProjectDto> AddAsync(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            var createdProject = await _projectRepo.AddAsync(project);
            return _mapper.Map<ProjectDto>(createdProject);
        }

        public async Task UpdateAsync(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _projectRepo.UpdateAsync(project);
        }

        public async Task DeleteAsync(int id)
        {
            await _projectRepo.DeleteAsync(id);
        }

        public async Task AddEmployeeToProject(int projectId, int empId)
        {
            await _projectRepo.AddEmployeeToProject(projectId, empId);
        }
    }
}
