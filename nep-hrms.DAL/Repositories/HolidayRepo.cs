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
    public class HolidayRepo : BaseRepo<Holiday>, IHolidayRepo
    {
        private readonly IBaseRepo<Holiday> _baseRepo;
        private readonly HrmsDBContext _dbContext;

        public HolidayRepo(HrmsDBContext context, IBaseRepo<Holiday> baseRepo) : base(context)
        {

            _baseRepo = baseRepo;
            _dbContext = context;

        }

        public async Task<List<Holiday>> GetHoliday()
        {
            return await _dbContext.Holiday.Where(x => x.Optional == false).ToListAsync();
        }
    }
}
