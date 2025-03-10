using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;

namespace nep_hrms.Server.API
{
    [Route("api/controller")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("{EmpId}")]
        public async Task<IActionResult>GetAttendanceById(int EmpId) //emp by id
        {
            var attendance = await _attendanceService.GetDataBySql(EmpId);
            if (attendance == null)
                return NotFound(new { message = "Attendance not found" });

            return Ok(attendance);
        }

        [HttpPost]
        [Route("AddAttendance")]
        public async Task<IActionResult> AddAttendance([FromBody] AttendanceDto attendanceDto)  //add
        {
            if (attendanceDto == null)
                return BadRequest(new { message = "Invalid attendance data" });

            var createdAttendance = await _attendanceService.AddAsync(attendanceDto);
            return Ok(createdAttendance.EmpId);
        }
    }
}
