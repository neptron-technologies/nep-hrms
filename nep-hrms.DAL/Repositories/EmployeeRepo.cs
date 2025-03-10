using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Repositories
{
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        private readonly IBaseRepo<Attendance> _baseRepo;
        private readonly HrmsDBContext _dbContext;

        public EmployeeRepo(HrmsDBContext context, IBaseRepo<Attendance> baseRepo) : base(context)
        {
            _baseRepo = baseRepo;
            _dbContext = context;
        }
        //public async Task<List<Employee>> GetAllAsync()
        //{
        //    var employees = await _dbContext.Employees.ToListAsync();

        //    foreach (var emp in employees)
        //    {
        //        emp.BloodGroup ??= "Unknown"; // Default value
        //        emp.Grade ??= "N/A";
        //        emp.BaseLoc ??= "Not Assigned";
        //        emp.CreatedDt ??= DateTime.UtcNow;
        //        emp.UpdatedBy ??= "System";
        //        emp.UpdatedDt ??= DateTime.UtcNow;
        //        emp.CompanyEmail ??= "noemail@company.com";
        //    }

        //    return employees;
        //}
    }
}
