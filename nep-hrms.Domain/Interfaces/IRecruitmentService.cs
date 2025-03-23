using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Interfaces
{
    public interface IRecruitmentService
    {
        Task<List<RecruitmentDTO>> GetAllAsync();
        Task<RecruitmentDTO> GetByIdAsync(int id);
        Task<RecruitmentDTO> AddAsync(RecruitmentDTO recruitmentDTO);
        Task UpdateAsync(RecruitmentDTO recruitmentDTO);
        Task DeleteAsync(int id);
    }
}

