using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Repositories
{
    public class RecruitmentRepo : BaseRepo<Recruitment>, IRecruitmentRepo
    {
        private readonly IBaseRepo<Recruitment> _baseRepo;
        private readonly HrmsDBContext _dbContext;

        public RecruitmentRepo(HrmsDBContext context, IBaseRepo<Recruitment> baseRepo) : base(context)
        {
            _baseRepo = baseRepo;
            _dbContext = context;
        }
    }
}