using AutoMapper;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;


namespace nep_hrms.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetAllAsync() //all emp
        {
            List<Employee> employees = null;
            try
            {
                employees = await _employeeRepo.GetAllAsync();
                var employeeDto = _mapper.Map<List<EmployeeDto>>(employees);
            }
            catch (Exception ex) 
            {
                string msg = ex.Message;
            }
            return employees;
        }

        public async Task<Employee> GetByIdAsync(int id) //emp by id
        {
            return await _employeeRepo.GetByIdAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employee)  //add
        {
            return await _employeeRepo.AddAsync(employee);
        }

        // DTO-Based Add Method
        public async Task<EmployeeDto> AddAsync(EmployeeDto employeeDto)
        {
            if (string.IsNullOrWhiteSpace(employeeDto.company_email)) //added so it cant be null
                throw new ArgumentException("Company email cannot be null or empty.");

            var employee = _mapper.Map<Employee>(employeeDto);
            var createdEmployee = await _employeeRepo.AddAsync(employee);
            return _mapper.Map<EmployeeDto>(createdEmployee);
        }

        public async Task UpdateAsync(Employee employee) //update
        {
            await _employeeRepo.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id) //delete
        {
            await _employeeRepo.DeleteAsync(id);
        }
        //public async Task<bool> DeleteEmp(int id)
        //{
        //    bool emplDeleted = false;
        //    try
        //    {
        //        await _employeeRepo.DeleteAsync(id);
        //        emplDeleted = true;
        //    }
        //    catch
        //    {
        //        emplDeleted = false;
        //    }
        //    return emplDeleted;
        //}
        //Implement the missing method!
        public async Task<List<Employee>> GetDataBySql(string sqlQry)
        {
            return await _employeeRepo.GetDataBySql(sqlQry);
        }
    }
}