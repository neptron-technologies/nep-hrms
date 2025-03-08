﻿using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Repositories;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()  //all emp
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id) //emp by id
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto) //add
        {
            if (employeeDto == null)
                return BadRequest(new { message = "Invalid employee data" });

            var createdEmployee = await _employeeService.AddAsync(employeeDto);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateEmployee(long id, [FromBody] Employee employee)  //update
        //{
        //    if (employee == null || id != employee.Id)
        //        return BadRequest(new { message = "Invalid Employee Data" });

        //    var existingEmployee = await _employeeService.GetByIdAsync(id);
        //    if (existingEmployee == null)
        //        return NotFound(new { message = "Employee not Found" });

        //    await _employeeService.UpdateAsync(employee);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            //or this
            //var existingEmployee = await _employeeService.GetByIdAsync(id);
            //if (existingEmployee == null)
            //    return NotFound(new { message = "Employee Not Found" });

            //await _employeeService.DeleteAsync(id);
            //    return NoContent();
        }
    }
}
