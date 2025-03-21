import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, NgModel, Validators } from '@angular/forms';
import { AttendanceService } from '../../services/attendance.service';
import { Attendance } from '../../Models/Attendance';
import { CommonModule } from '@angular/common';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class AttendanceComponent implements OnInit {
  attendanceForm!: FormGroup;
  weekDates: string[] = [];
  selectedDate!: Date;
  isCurrentWeek: boolean = true;
  maxWeeksBack: number = 4; // Allow only 4 weeks back
  weekOffset: number = 0; // Tracks how many weeks back the user is
  AttendanceList: Attendance[] = [];
  displayedColumns: string[] = ['date', 'hoursFilled', 'remarks'];
  dataSource = new MatTableDataSource<Attendance>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private fb: FormBuilder, private attendanceService: AttendanceService) {}

  ngOnInit(): void {
    this.initializeForm();
    this.setCurrentWeekDates();
  }

  weeklyAttendance: Attendance[] = [];

  // Fetch Attendance for Selected Week 
  // getEmployeeAttendance(): void {
  //   const empId = 2; // Replace with actual employee ID
  //   const startDt = new Date(this.weekDates[0]); 
  //   const endDt = new Date(this.weekDates[6]); 
  
  //   this.attendanceService.getAttendanceById(empId, startDt, endDt).subscribe((data) => {
  //     if(data.length === 0){
  //       console.warn("No attendance data found for the selected week");
  //     }else{
  //       console.log('Attendance Data:', data);
  //     }

  //     this.weeklyAttendance = data; //Assign data to weeklyAttendance
  //   },
  //   (error) => {
  //     console.error('Error fetching attendance:', error);
  //   });
  // }
  getEmployeeAttendance(): void {
    let empId: number = 2; // Replace with dynamic Employee ID
    const startDt = new Date(this.weekDates[0]); 
    const endDt = new Date(this.weekDates[6]); 
  
    this.attendanceService.getAttendanceById(empId, startDt, endDt).subscribe((data) => {
      if (data.length > 0) {
        // ✅ Convert API response to match the `Attendance` model
        this.weeklyAttendance = data.map(record => ({
          emp_id: record.emp_id,
          attendanceDate: new Date(record.attendanceDate), // ✅ Rename field
          hoursFilled: record.hoursFilled, // ✅ Rename field
          remarks: record.remarks
        }));
      } else {
        // ✅ Create a blank structure for the current week
        this.weeklyAttendance = this.weekDates.map(date => ({
          emp_id: empId, 
          attendanceDate: new Date(date), // ✅ Use correct property name
          hoursFilled: 9, // ✅ Use correct property name
          remarks: ''
        }));
      }
      console.log(this.weeklyAttendance);
    }, error => {
      console.error("Error fetching attendance", error);
    });
  }
  
  

  //Initialize Form with Weekly Fields 
  initializeForm(): void {
    const formControls: { [key: string]: any } = {};
    for (let i = 0; i < 7; i++) {
      formControls[`attendanceDate${i}`] = ['', Validators.required];
      formControls[`hoursFilled${i}`] = ['9', [Validators.required, Validators.min(0), Validators.max(24)]];
      formControls[`remarks${i}`] = ['', Validators.maxLength(200)];
    }
    this.attendanceForm = this.fb.group(formControls);
  }

  // Get Monday of a Given Week 
  getMonday(date: Date): Date {
    const d = new Date(date);
    const day = d.getDay();
    const diff = d.getDate() - day + (day === 0 ? -6 : 1);
    return new Date(d.setDate(diff));
  }


  calculateWeekDates(selectedDate: Date): void {
    const monday = this.getMonday(selectedDate);
    this.weekDates = [];
  
    for (let i = 0; i < 7; i++) {
      const currentDate = new Date(monday);
      currentDate.setDate(monday.getDate() + i);
      this.weekDates.push(currentDate.toISOString().split('T')[0]);
    }
    this.getEmployeeAttendance();
  }
  

  // Set Current Week 
  setCurrentWeekDates(): void {
    this.selectedDate = new Date();
    this.calculateWeekDates(this.selectedDate);
    this.isCurrentWeek = true;
    this.weekOffset = 0;
  }

  //Navigate to Previous Week 
  previousWeek(): void {
    if (this.weekOffset < this.maxWeeksBack) {
      this.weekOffset++;
      this.selectedDate.setDate(this.selectedDate.getDate() - 7);
      this.calculateWeekDates(this.selectedDate);
      this.isCurrentWeek = false;
    }
  }

  // Navigate to Next Week
  nextWeek(): void {
    if (!this.isCurrentWeek) {
      this.weekOffset--;
      this.selectedDate.setDate(this.selectedDate.getDate() + 7);
      this.calculateWeekDates(this.selectedDate);
      this.isCurrentWeek = this.weekOffset === 0;
    }
  }

  //Submit Attendance
  onSubmit(): void {
    if (this.attendanceForm.valid) {
      const empId = 2; // Replace with actual employee ID
      const attendanceData: Attendance[] = this.weekDates.map((date, index) => ({
        emp_id: empId,
        attendanceDate: new Date(date),
        hoursFilled: this.attendanceForm.value[`hoursFilled${index}`],
        remarks: this.attendanceForm.value[`remarks${index}`]
      }));

      console.log('Submitting:', attendanceData);
      this.attendanceService.addAttendance(attendanceData).subscribe(
        (response) => {
          console.log('Attendance added:', response);
          this.attendanceForm.reset();
          this.getEmployeeAttendance();
        },
        (error) => {
          console.error('Error adding attendance:', error);
        }
      );
    }
  }
}
