using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;

namespace nep_hrms.Server.API
{
    public class EmployeeBankDetailController : ControllerBase
    {
        private readonly IEmployeeBankDetailService _employeeBankDetailService;

        public EmployeeBankDetailController(IEmployeeBankDetailService employeeBankDetailService)
        {
            _employeeBankDetailService = employeeBankDetailService;
        }
        [HttpGet]
        [Route("GetBankDetailsById")]
        public async Task<IActionResult> GetBankDetailsById(int empId)
        {
            var details = await _employeeBankDetailService.GetBankDetailsById(empId);
            if (details == null)
                return NotFound();

            return Ok(details);
        }
    }
}
