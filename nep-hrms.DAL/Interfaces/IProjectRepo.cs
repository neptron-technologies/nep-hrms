using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Interfaces
{
    public interface IProjectRepo : IBaseRepo<Project>
    {
        Task<List<Project>> GetProjectsByEmpId(int empId);
        Task<Project?> GetProjectWithEmployeesAsync(int projectId);
        Task<List<Employee>> GetEmployeesByProjectId(int projectId);
        Task AddEmployeeToProject(int projectId, int empId);
    }
}
