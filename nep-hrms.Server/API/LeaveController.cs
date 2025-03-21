using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Domain.Services;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Server.API
{
    [Route("api/controller")]
    [ApiController]
    public class LeaveController : Controller
    {
       
           private readonly ILeaveService _leaveService;

            public LeaveController(ILeaveService LeaveService)
            {
                _leaveService = LeaveService;
            }
        [HttpGet("")]
        public async Task<IActionResult> GetLeaveById(int EmpId) 
        {

            var leave = await _leaveService.GetDataBySql(EmpId);
            if (leave == null)
                return NotFound(new { message = "Leave not found" });

            return Ok(leave);
        }
        [HttpPost]
       [Route("ApplyLeave")]
        public async Task<IActionResult> AddLeave([FromBody] EmpLeave empLeave)
        {

            try
            {
                var result = await _leaveService.ApplyLeave(empLeave);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            
        }

        [HttpGet]
        [Route("CancelLeave")]
        
        public async Task<IActionResult> CancelLeave(int leaveId)  
        {

            try
            {
                var result = await _leaveService.CancelLeave(leaveId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }


        [HttpGet]
        [Route("GetHolidays")]
        public async Task<IActionResult> GetHolidays() 
        {
            var Holidays = await _leaveService.GetHolidays();
            return Ok(Holidays);
        }
        [HttpGet]
        [Route("GetPendingLeave")]
        public async Task<List<EmpLeave>> GetPendingLeave()
        {
            return await _leaveService.GetPendingLeavesAsync();
        }
        
        [HttpGet]
        [Route("ApproveLeave")]

        public async Task<IActionResult> ApproveLeave(int id)
        {
            await _leaveService.ApproveLeaveAsync(id);
            return Ok("Leave Approved");    
        }
        [HttpGet]
        [Route("RejectLeave")]
        public async Task<IActionResult> RejectLeave(int id)
        {
            await _leaveService.RejectLeaveAsync(id);
            return Ok("Leave Rejected");
        }

    }

}
