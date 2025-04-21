using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;

namespace nep_hrms.Server.API
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("GetEmployeesByProject/{projectId}")]
        public async Task<IActionResult> GetEmployeesByProject(int projectId)
        {
            var employees = await _projectService.GetEmployeesByProjectId(projectId);
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetProjectsByEmpId/{empId}")]
        public async Task<IActionResult> GetProjectsByEmpId(int empId)
        {
            var projects = await _projectService.GetProjectsByEmpId(empId);
            return Ok(projects);
        }

        [HttpPost("AddEmployeeToProject/{projectId}/{empId}")]
        public async Task<IActionResult> AddEmployeeToProject(int projectId, int empId)
        {
            await _projectService.AddEmployeeToProject(projectId, empId);
            return Ok(new { message = "Employee added to project successfully." });
        }

        //added
        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjects();
            if (projects == null || !projects.Any())
            {
                return NotFound(new { message = "No projects found." });
            }
            return Ok(projects);
        }

        [HttpPost]
        [Route("AddProjects")]
        public async Task<IActionResult> AddProject([FromBody] ProjectDto projectDto)
        {
            if (projectDto == null)
                return BadRequest(new { message = "Invalid project data" });

            var createdProject = await _projectService.AddAsync(projectDto);

            return CreatedAtAction(nameof(GetProjectsByEmpId), new { empId = createdProject.EmpId }, createdProject);

        }

        //Update 
        [HttpPut]
        [Route("Update{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] ProjectDto projectDto)
        {
            if (projectDto == null || projectId != projectDto.Id)
                return BadRequest(new { message = "Invalid project data" });

            await _projectService.UpdateAsync(projectDto);
            return Ok(new { message = "Project updated successfully" });
        }

        //Delete 
        [HttpDelete]
        [Route("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            await _projectService.DeleteAsync(projectId);
            return Ok(new { message = "Project deleted successfully" });
        }

        [HttpGet]
        [Route("{empId}")]
        public async Task<IActionResult> GetProjectId(int empId)
        {
            var projectId = await _projectService.GetProjectIdByEmployeeId(empId);
            return Ok(projectId);
        }
    }
}
