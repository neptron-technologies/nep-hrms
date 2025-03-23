using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Repositories
{
    public class ProjectRepo : BaseRepo<Project>, IProjectRepo
    {
        private readonly HrmsDBContext _dbContext;

        public ProjectRepo(HrmsDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Employee>> GetEmployeesByProjectId(int projectId)
        {
            var employeeIds = await _dbContext.EmployeeProjects
            .Where(p => p.ProjectId == projectId)
            .Select(e => e.EmployeeId).ToListAsync();

            var employees = await _dbContext.Employees.Where(e => employeeIds.Contains(e.Id)).ToListAsync();

            return employees;

        }

        public async Task<List<Project>> GetProjectsByEmpId(int empId)
        {
            var projectIds = await _dbContext.EmployeeProjects
                .Where(ep => ep.EmployeeId == empId)
                .Select(ep => ep.ProjectId) 
                .ToListAsync();
            
            var projects = await _dbContext.Projects
                .Where(p => projectIds.Contains(p.Id))
                .Include(p => p.EmployeeProjects)
                .ThenInclude(ep => ep.Employee)
                .ToListAsync();
            
            return projects;
            //var employeeIds = await _dbContext.EmployeeProjects
            //    .Where(p => p.ProjectId == empId)
            //    .Select(e => e.EmployeeId).ToListAsync();

            //var employees = await _dbContext.Employees.Where(e => employeeIds.Contains(e.Id)).ToListAsync();


            //return pro;
        }

        public async Task<Project?> GetProjectWithEmployeesAsync(int projectId)
        {
            return await _dbContext.Projects
                .Where(p => p.Id == projectId)
                .Include(p => p.EmployeeProjects)
                    .ThenInclude(ep => ep.Employee)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task AddEmployeeToProject(int projectId, int empId)
        {
            var existingRelation = await _dbContext.EmployeeProjects
                .FirstOrDefaultAsync(ep => ep.ProjectId == projectId && ep.EmployeeId == empId);

            if (existingRelation == null)
            {
                var employeeProject = new EmployeeProject
                {
                    ProjectId = projectId,
                    EmployeeId = empId
                };

                _dbContext.EmployeeProjects.Add(employeeProject);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
