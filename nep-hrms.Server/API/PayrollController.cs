using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;

namespace nep_hrms.Server.API
{
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }
        [HttpGet("GetPayroll")]
        public async Task<IActionResult> GetPayroll(int empId)
        {
            var payroll = await _payrollService.GetPayrollByEmpId(empId);
            if (payroll == null)
                return NotFound();

            return Ok(payroll);
        }
    }
}
