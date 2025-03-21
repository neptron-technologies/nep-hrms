using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Repositories;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Models
{
    public  class EmpLeaveCancelRepo : BaseRepo<EmpLeaveCancelled>, IEmpLeaveCancelled
    {
        private readonly IBaseRepo<EmpLeaveCancelled> _baseRepo;

        private readonly HrmsDBContext _dbContext;
        public EmpLeaveCancelRepo(HrmsDBContext context, IBaseRepo<EmpLeaveCancelled> baseRepo) : base(context)
        {

            _baseRepo = baseRepo;
            _dbContext = context;

        }
        public async Task<EmpLeaveCancelled> CancelUpdate(EmpLeaveCancelled empLeaveCancelled)
        {
            await _baseRepo.AddAsync(empLeaveCancelled);
            return empLeaveCancelled;
        }

    }
}
