export class AttendanceInfo
{
    	

  monthlyAttendance:number;
  quarterlyAttendance: number;
  totalEl: number;
  elBalance: number;
  optionalBal: number;
  leaveWithoutPay: number
   
  constructor(
    monthlyAttendance:number,
  quarterlyAttendance: number,
  totalEl: number,
  elBalance: number,
  optionalBal: number,
  leaveWithoutPay: number)
{
  this.monthlyAttendance=monthlyAttendance;totalEl;
  this.quarterlyAttendance=quarterlyAttendance;
  this.totalEl=totalEl;
  this.elBalance=elBalance;
  this.optionalBal=optionalBal;
  this.leaveWithoutPay=leaveWithoutPay;

}


}