using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Repositories
{
    public class EmpLeaveBalRepo : BaseRepo<EmpLeaveBalance>, IEmpLeaveBalRepo
    {
        private readonly IBaseRepo<EmpLeaveBalance> _baseRepoBalance;
        private readonly HrmsDBContext _dbContext;
        public EmpLeaveBalRepo(HrmsDBContext context,  IBaseRepo<EmpLeaveBalance> baseRepoBalance) : base(context)
        {
            
            _dbContext = context;
            _baseRepoBalance = baseRepoBalance;
        }

       public async Task<EmpLeaveBalance> Update(EmpLeaveBalance balance)
        {
             await _baseRepoBalance.UpdateAsync(balance);
            return balance;
        }

    }
}
