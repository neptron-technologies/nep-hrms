using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Repositories;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;

namespace nep_hrms.Domain.Services
{
    public class EmpDashBoardService : IEmpDashBoradService
    {
        private readonly IAttendanceRepo _attendanceRepo;
        private readonly IMapper _mapper;
      //  private readonly IEmpLeaveBalRepo _empLeaveBalRepo;
        private readonly ILeaveRepo _leaveRepo;

        public EmpDashBoardService(IAttendanceRepo attendanceRepo, ILeaveRepo leaveRepo, IMapper mapper)
        {
            _attendanceRepo = attendanceRepo;
            _mapper = mapper;
            //_empLeaveBalRepo = empLeaveBal;
            _leaveRepo = leaveRepo;
        }



        public async Task<AttendanceInfoDto> GetAttendanceInfo(int empId)
        {
            var monthlyAttendance = await _attendanceRepo.GetMonthlyAttendance(empId);
            var quarterlyAttendance = await _attendanceRepo.GetQuarterlyAttendance(empId);     
           
            var balance = await _leaveRepo.GetByEmpIdAsync(empId);

            return new AttendanceInfoDto
            {
                MonthlyAttendance = monthlyAttendance,
                QuarterlyAttendance = quarterlyAttendance,
                TotalEl = balance.EarnedLeavesForFy,
                ElBalance = balance.ElBalance,
                OptionalBal=balance.OptionalBal,
                LeaveWithoutPay=balance.LeaveWithoutPay,
                





            };
        }
    }
}
