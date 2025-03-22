using AutoMapper;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepo _leaveRepo;
        private readonly IMapper _mapper;
        private readonly IEmpLeaveBalRepo _empLeaveBalRepo;
        private readonly IHolidayRepo _HolidayRepo;
        private readonly IEmpLeaveCancelled _empLeaveCancelled;

        public LeaveService(ILeaveRepo leaveRepo,IEmpLeaveCancelled empLeaveCancelled, IEmpLeaveBalRepo empLeaveBal, IHolidayRepo HolidayRepo, IMapper mapper)
        {
            _leaveRepo = leaveRepo;
            _mapper = mapper;
            _empLeaveCancelled= empLeaveCancelled;
            _empLeaveBalRepo = empLeaveBal;
            _HolidayRepo= HolidayRepo;
        }


        public async Task<List<EmpLeave>> GetDataBySql(int EmpId)
        {




            return await _leaveRepo.GetLeaveByEmpId(EmpId);


        }


        public async Task<EmpLeave> ApplyLeave(EmpLeave leaveRequest)
        {

            var balance = await _leaveRepo.GetByEmpIdAsync(leaveRequest.EmpId);
            if (balance == null)
            {
                throw new Exception("Leave balance record not found.");
            }

            if (leaveRequest.LeaveType == "EL")
            {
                if (balance.ElBalance >= leaveRequest.NoOfDays)
                {
                    balance.ElBalance -= leaveRequest.NoOfDays;
                }
                else
                {
                    int remainingDays = (int)(leaveRequest.NoOfDays - balance.ElBalance);
                    balance.LeaveWithoutPay += remainingDays;
                    balance.ElBalance = 0;
                }
            }
            else if (leaveRequest.LeaveType == "Optional")
            {
                if (balance.OptionalBal >= leaveRequest.NoOfDays)
                {
                    balance.OptionalBal -= leaveRequest.NoOfDays;
                }
                else
                {
                    throw new Exception("Insufficient Optional Leave Balance.");
                }
            }

            await _empLeaveBalRepo.Update(balance);
            return await _leaveRepo.AddLeave(leaveRequest);
        }






       

        public async Task<EmpLeaveCancelled> CancelLeave(int id)
        {
            var leave = await _leaveRepo.GetByIdAsync(id);
            if (leave == null)
            {
                throw new Exception("Leave record not found.");
            }

            if (leave.ApprovedStatus == "Approved")
            {
                var balance = await _leaveRepo.GetByEmpIdAsync(leave.EmpId);
                if (balance == null)
                {
                    throw new Exception("Employee leave balance record not found.");
                }

                if (leave.LeaveType == "EL")
                {
                    balance.ElBalance += leave.NoOfDays;
                }
                else if (leave.LeaveType == "Optional")
                {
                    balance.OptionalBal += leave.NoOfDays;
                }

                await _empLeaveBalRepo.Update(balance);
            }
           
            var leaveCancelledEntity = _mapper.Map<EmpLeaveCancelled>(leave);
            leaveCancelledEntity.Id = 0;
            leaveCancelledEntity.CanceledStatus = "Canceled";
            leaveCancelledEntity.CanceledOn = DateTime.Now;
            

            await _empLeaveCancelled.CancelUpdate(leaveCancelledEntity);
            await _leaveRepo.DeleteAsync(leave.Id);
            return leaveCancelledEntity;
        }

        public async Task<List<Holiday>> GetHolidays()
        {
            return await _HolidayRepo.GetHoliday();
        }

        public async Task<EmpLeave> ApproveLeaveAsync(int id)
        {
            var leave = await _leaveRepo.GetByIdAsync(id);
            if (leave == null)
            {
                throw new Exception("Leave not found."); 
            }

            leave.ApprovedStatus = "Approved";
            await _leaveRepo.UpdateAsync(leave); 
            return leave;
        }

        public async Task<EmpLeave> RejectLeaveAsync(int id)
        {
            var leave = await _leaveRepo.GetByIdAsync(id);
            if (leave == null)
            {
                throw new Exception("Leave not found.");
            }

            leave.ApprovedStatus = "Rejected";
            await _leaveRepo.UpdateAsync(leave);
            return leave;
        }


        public async Task<List<EmpLeave>> GetPendingLeavesAsync()
        {
            return await _leaveRepo.GetPendingLeavesAsync();
        }
    }
}

