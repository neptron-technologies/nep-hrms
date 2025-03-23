using AutoMapper;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.DAL.Repositories;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Services
{
    public class RecruitmentService : IRecruitmentService
    {
        private readonly IRecruitmentRepo _recruitmentRepo;
        private readonly IMapper _mapper;

        public RecruitmentService(IRecruitmentRepo recruitmentRepo, IMapper mapper)
        {
            _recruitmentRepo = recruitmentRepo;
            _mapper = mapper;
        }

        public async Task<List<RecruitmentDTO>> GetAllAsync()
        {
            var recruitments = await _recruitmentRepo.GetAllAsync();
            return _mapper.Map<List<RecruitmentDTO>>(recruitments);
        }

        public async Task<RecruitmentDTO> GetByIdAsync(int id)
        {
            var recruitment = await _recruitmentRepo.GetByIdAsync(id);
            return _mapper.Map<RecruitmentDTO>(recruitment);
        }

        public async Task<RecruitmentDTO> AddAsync(RecruitmentDTO recruitmentDTO)
        {
            if (string.IsNullOrWhiteSpace(recruitmentDTO.Email))
                throw new ArgumentException("Email cannot be null or empty.");

            var recruitment = _mapper.Map<Recruitment>(recruitmentDTO);
            var createdRecruitment = await _recruitmentRepo.AddAsync(recruitment);
            return _mapper.Map<RecruitmentDTO>(createdRecruitment);
        }

        public async Task UpdateAsync(RecruitmentDTO recruitmentDTO)
        {
            var recruitment = _mapper.Map<Recruitment>(recruitmentDTO);
            await _recruitmentRepo.UpdateAsync(recruitment);
        }

        public async Task DeleteAsync(int id)
        {
            await _recruitmentRepo.DeleteAsync(id);
        }
    }
}
