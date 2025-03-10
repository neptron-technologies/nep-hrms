using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepo _attendanceRepo;
        private readonly IMapper _mapper;
        

        public AttendanceService(IAttendanceRepo attendanceRepo, IMapper mapper)
        {
            _attendanceRepo = attendanceRepo;
            _mapper = mapper;
        }

        //Get By Id 
        public async Task<List<Attendance>> GetDataBySql(string sqlQry)
        {
            return await _attendanceRepo.GetDataBySql(sqlQry);
        }
        public async Task<List<Attendance>> GetDataBySql(int EmpId) //GET BY ID
        {

            //string sql = "SELECT * FROM Attendance where emp_id = " + EmpId.ToString();
            //var empAttendance = await _attendanceRepo.GetDataBySql(sql);

            //return empAttendance;
            return await _attendanceRepo.GetAttendanceByEmpId(EmpId);

            //var sqlQuery = "SELECT * FROM Attendance WHERE emp_id = {0}";
            //return await _dbContext.Attendances.FromSqlRaw(sqlQuery, EmpId).ToListAsync();
        }
  
        public async Task<Attendance> AddAsync(Attendance attendance) //ADD
        {
            return await _attendanceRepo.AddAsync(attendance);
        }
        public async Task<AttendanceDto> AddAsync(AttendanceDto attendanceDto) //USE OF DTO
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            var createdAttendance = await _attendanceRepo.AddAsync(attendance);
            return _mapper.Map<AttendanceDto>(createdAttendance);
        }   
        public async Task UpdateAsync(Attendance attendance) //update
        {
            await _attendanceRepo.UpdateAsync(attendance);
        }
        public async Task DeleteAsync(int id) //delete
        {
            await _attendanceRepo.DeleteAsync(id);
        }
    }
}
