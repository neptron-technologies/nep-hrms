using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Domain.Services;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Server.Controllers
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

        [HttpGet("{id}")]
        //[Route("GetAttendanceForEmployee")]
        public async Task<IActionResult> GetAttendanceById(int EmpId) //emp by id
        {
            var attendance = await _attendanceService.GetDataBySql(EmpId);
            if (attendance == null)
                return NotFound(new { message = "Attendance not found" });

            return Ok(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance([FromBody] AttendanceDto attendanceDto)
        {
            if (attendanceDto == null)
                return BadRequest(new { message = "Invalid attendance data" });

            var createdAttendance = await _attendanceService.AddAsync(attendanceDto);
            return CreatedAtAction(nameof(GetAttendanceById), new { id = createdAttendance.Id }, createdAttendance);
        }
    }
}
