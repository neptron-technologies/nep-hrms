using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.Domain.Mappers;

namespace nep_hrms.Domain.Interfaces
{
    public interface IEmployeeService 
    {
        Task<List<Employee>> GetAllAsync();     
        Task<Employee> GetByIdAsync(int id);
        Task<EmployeeDto> AddAsync(EmployeeDto employeeDto);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
