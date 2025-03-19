using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;

namespace nep_hrms.Server.API
{
    public class PayslipController : ControllerBase
    {
        private readonly IPayslipService _payslipService;

        public PayslipController(IPayslipService payslipService)
        {
            _payslipService = payslipService;
        }

        [HttpGet]
        [Route("{EmpId}")]
        public async Task<IActionResult> GetPayslipAsync(int EmpId)
        {
            var payslip = await _payslipService.GetPayslipAsync(EmpId);

            if (payslip == null)
                return NotFound(new { message = "Payslip not found" });

            return Ok(payslip);
        }
    }
}
