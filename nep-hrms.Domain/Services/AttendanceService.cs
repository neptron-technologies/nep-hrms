using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using nep_hrms.Domain.Helpers;
using System.Collections.Generic;
using System.Linq;
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

        //Get attendance by employee ID
        public async Task<List<Attendance>> GetDataBySql(int EmpId)
        {
            return await _attendanceRepo.GetAttendanceByEmpId(EmpId);
        }

        // Add attendance record
        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            return await _attendanceRepo.AddAsync(attendance);
        }

        //  Add attendance using DTO
        public async Task<AttendanceDto> AddAsync(AttendanceDto attendanceDto)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            var createdAttendance = await _attendanceRepo.AddAsync(attendance);
            return _mapper.Map<AttendanceDto>(createdAttendance);
        }

        // Update
        public async Task UpdateAsync(Attendance attendance)
        {
            await _attendanceRepo.UpdateAsync(attendance);
        }

       
        public async Task DeleteAsync(int id)
        {
            await _attendanceRepo.DeleteAsync(id);
        }
        public async Task<AttendanceSummaryDto> GetAttendanceSummary(int empId)
        {
            var monthlyAttendance = await _attendanceRepo.GetMonthlyAttendance(empId);
            var quarterlyAttendance = await _attendanceRepo.GetQuarterlyAttendance(empId); // Fixed
           // var leaveBalance = await _attendanceRepo.GetLeaveBalance(empId);

            return new AttendanceSummaryDto
            {
                MonthlyAttendance = monthlyAttendance,
                QuarterlyAttendance = quarterlyAttendance, // Use count instead of List
               // LeaveBalance = leaveBalance
            };
        }


    }
}
