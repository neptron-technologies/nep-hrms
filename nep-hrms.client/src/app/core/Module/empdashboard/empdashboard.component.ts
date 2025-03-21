import { Component, OnInit } from '@angular/core';
import { AttendanceInfo } from '../../Models/AttendanceInfo';
import { EmpdashboardService } from '../../services/empdashboard.service';

@Component({
  selector: 'app-empdashboard',
  standalone: false,
  templateUrl: './empdashboard.component.html',
  styleUrls: ['./empdashboard.component.css']
})
export class EmpdashboardComponent implements OnInit {
  attendanceInfo: AttendanceInfo | null = null;
  empId: number = Number(localStorage.getItem('empId')) || 0;

  view: [number, number] = [700, 400]; // Chart size

  data: { name: string; value: number }[] = []; // Initialize as empty array

  // Chart options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Category';
  showYAxisLabel = true;
  yAxisLabel = 'Value';
  colorScheme = 'vivid';

  constructor(private empDashBoardServ: EmpdashboardService) {}

  ngOnInit(): void {
    this.getAttendanceInfo(this.empId);
  }

  getAttendanceInfo(id: number) {
    this.empDashBoardServ.getAttndanceInfo(id).subscribe((res: any) => {
      console.log('API Response:', res); // Debugging
      this.attendanceInfo = res;

      // Dynamically update the chart data
      this.data = [
        { name: 'Monthly Attendance', value: res.monthlyAttendance || 0 },
        { name: 'Quarterly Attendance', value: res.quarterlyAttendance || 0 },
        { name: 'Total EL', value: res.totalEl || 0 },
        { name: 'EL Balance', value: res.elBalance || 0 },
        { name: 'Optional Balance', value: res.optionalBal || 0 },
        { name: 'Leave Without Pay', value: res.leaveWithoutPay || 0 },
      ];
    });
  }
}
