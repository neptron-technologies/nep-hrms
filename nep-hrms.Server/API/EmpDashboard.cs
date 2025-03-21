using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Repositories;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Domain.Services;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Server.API
{
    [Route("api/controller")]
    [ApiController]
    public class EmpDashboard : ControllerBase
    {
      private readonly IEmpDashBoradService _empDashBoradService;

        public EmpDashboard(IEmpDashBoradService empDashBoradService)
        {
            _empDashBoradService = empDashBoradService;
        }
    

        [HttpGet("attendanceInfo/{empId}")]
        public async Task<IActionResult> GetAttendanceSummary(int empId)
        {
            var attendanceinfo = await _empDashBoradService.GetAttendanceInfo(empId);
            if (attendanceinfo == null)
            {
                return NotFound("Attendance  not found");
            }
            return Ok(attendanceinfo);
        }







    }
}