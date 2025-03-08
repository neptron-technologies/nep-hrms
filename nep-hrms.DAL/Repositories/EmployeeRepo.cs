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
        public EmployeeRepo(HrmsDBContext context) : base(context)
        {

        }
    }
}
