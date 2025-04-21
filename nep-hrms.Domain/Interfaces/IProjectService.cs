using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetProjectsByEmpId(int empId);
        Task<ProjectDto?> GetProjectWithEmployeesAsync(int projectId);
        Task<List<EmployeeDto>> GetEmployeesByProjectId(int projectId);
        Task<ProjectDto> AddAsync(ProjectDto project);
        Task UpdateAsync(ProjectDto project);
        Task DeleteAsync(int id);
        Task AddEmployeeToProject(int projectId, int empId);
        Task<List<ProjectDto>> GetAllProjects(int? projectId = null); //added
        Task<List<int>> GetProjectIdByEmployeeId(int empId);
    }

}
