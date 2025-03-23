// import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
// import {
//   FormBuilder,
//   FormGroup,
//   FormsModule,
//   NgModel,
//   Validators,
// } from '@angular/forms';
// import { AttendanceService } from '../../services/attendance.service';
// import { Attendance } from '../../Models/Attendance';
// import { CommonModule } from '@angular/common';
// import { MatPaginator } from '@angular/material/paginator';
// import { MatTableDataSource } from '@angular/material/table';
// import { DataTransferService } from '../../services/data-transfer.service';
 
// @Component({
//   selector: 'app-attendance',
//   templateUrl: './attendance.component.html',
//   styleUrls: ['./attendance.component.css'],
//   standalone: true,
//   imports: [CommonModule, FormsModule],
// })
// export class AttendanceComponent implements OnInit {
//   attendanceForm!: FormGroup;
//   weekDates: string[] = [];
//   selectedDate!: Date;
//   projectId!: number;
//   isCurrentWeek: boolean = true;
//   maxWeeksBack: number = 4; // Allow only 4 weeks back
//   weekOffset: number = 0; // Tracks how many weeks back the user is
//   AttendanceList: Attendance[] = [];
//   displayedColumns: string[] = ['date', 'hoursFilled', 'remarks'];
//   dataSource = new MatTableDataSource<Attendance>();
//   attendanceStatus: string = 'N/A';
//   empId!: number | null;
 
//   @ViewChild(MatPaginator) paginator!: MatPaginator;
 
//   constructor(
//     private fb: FormBuilder,
//     private attendanceService: AttendanceService,
//     private dataTransferService: DataTransferService,
//     private cdr: ChangeDetectorRef
//   ) {}
 
//   ngOnInit(): void {
//     this.initializeForm();
//     this.setCurrentWeekDates();
//     this.fetchEmployeeProjectId();
 
//     this.empId = this.dataTransferService.getEmpId();
//     if (this.empId) {
//       this.getEmployeeAttendance();
//     } else {
//       console.error('Employee ID not found. Attendance cannot be fetched.');
//     }
//   }
 
//   weeklyAttendance: Attendance[] = [];
 
//   getEmployeeAttendance(): void {
//     if (this.empId == null) {
//       console.error('No Employee ID available.');
//       return;
//   }
 
//     const [startDt, endDt] = [new Date(this.weekDates[0]), new Date(this.weekDates[6])];
 
 
//     this.attendanceService
//       .getAttendanceById(this.empId, startDt, endDt)
//       .subscribe(
//         (data) => {
//           if (data.length > 0) {
//             this.weeklyAttendance = data.map((record) => ({
//               emp_id: record.emp_id,
//               attendanceDate: new Date(record.attendanceDate),
//               hoursFilled: record.hoursFilled,
//               remarks: record.remarks,
//               project_id: record.project_id,
//               status: record.status ? { id: record.status.id, status: record.status.status } : { id: 0, status: 'N/A' },
//             }));
//             console.log('Processed Attendance:', this.weeklyAttendance); // Debugging log
//             this.attendanceStatus = this.weeklyAttendance[this.weeklyAttendance.length - 1]?.status?.status ?? 'N/A';
//             this.cdr.detectChanges(); // Force UI update
//           } else {
//             this.weeklyAttendance = this.weekDates.map((date) => ({
//               emp_id: this.empId!,
//               attendanceDate: new Date(date),
//               hoursFilled: 9,
//               remarks: '',
//               project_id: this.projectId,
//               status: { id: 0, status: 'N/A' },
//             }));
//             this.attendanceStatus = 'N/A';
//           }
//         },
//         (error) => {
//           console.error('Error fetching attendance', error);
//         }
//       );
//   }
 
//   //Initialize Form with Weekly Fields
//   initializeForm(): void {
//     const formControls: { [key: string]: any } = {};
//     for (let i = 0; i < 7; i++) {
//       formControls[`attendanceDate${i}`] = ['', Validators.required];
//       formControls[`hoursFilled${i}`] = [
//         '9',
//         [Validators.required, Validators.min(0), Validators.max(24)],
//       ];
//       formControls[`remarks${i}`] = ['', Validators.maxLength(200)];
//       formControls[`projectId${i}`] = ['', Validators.required];
//     }
//     this.attendanceForm = this.fb.group(formControls);
//   }
 
//   // fetchEmployeeProjectId(): void {
//   //   this.attendanceService.getEmployeeProjectId(this.empId!).subscribe(
//   //     (response: any) => {  
//   //       const projectId = response?.find((p: any) => p.emp_id === this.empId)?.id;
//   //       if (!projectId || !this.attendanceForm) return console.warn(`No project found for employee ID: ${this.empId}`);
 
//   //       this.projectId = projectId;
//   //       console.log('Project ID Received:', this.projectId);
 
//   //       this.attendanceForm.patchValue(Object.fromEntries([...Array(7).keys()].map(i => [`projectId${i}`, this.projectId])));
//   //     },
//   //     (error) => console.error('Error fetching Project ID:', error)
//   //   );
//   // }
//   fetchEmployeeProjectId(): void {
//     this.attendanceService.getEmployeeProjectId(this.empId!).subscribe(
//       (response: any) => {
//         const projectId = response?.find((p: any) => p.emp_id === this.empId)?.id;
//         if (!projectId) {
//           console.warn(`No project found for employee ID: ${this.empId}`);
//           return;
//         }
 
//         this.projectId = projectId;
//         console.log('Project ID Received:', this.projectId);
 
//         // Assign project ID to each entry in weeklyAttendance
//         this.weeklyAttendance.forEach(day => {
//           day.project_id = this.projectId;
//         });
 
//         // Update the form fields
//         this.attendanceForm.patchValue(
//           Object.fromEntries([...Array(7).keys()].map(i => [`projectId${i}`, this.projectId]))
//         );
//       },
//       (error) => console.error('Error fetching Project ID:', error)
//     );
//   }
 
//   // Get Monday of a Given Week
//   getMonday(date: Date): Date {
//     const d = new Date(date);
//     const day = d.getDay();
//     const diff = d.getDate() - day + (day === 0 ? -6 : 1);
//     return new Date(d.setDate(diff));
//   }
 
//   calculateWeekDates(selectedDate: Date): void {
//     const monday = this.getMonday(selectedDate);
//     this.weekDates = [];
 
//     for (let i = 0; i < 7; i++) {
//       const currentDate = new Date(monday);
//       currentDate.setDate(monday.getDate() + i);
//       this.weekDates.push(currentDate.toISOString().split('T')[0]);
//     }
//     this.getEmployeeAttendance();
//   }
 
//   // Set Current Week
//   setCurrentWeekDates(): void {
//     this.selectedDate = new Date();
//     this.calculateWeekDates(this.selectedDate);
//     this.isCurrentWeek = true;
//     this.weekOffset = 0;
//   }
 
//   //Navigate to Previous Week
//   previousWeek(): void {
//     if (this.weekOffset < this.maxWeeksBack) {
//       this.weekOffset++;
//       this.selectedDate.setDate(this.selectedDate.getDate() - 7);
//       this.calculateWeekDates(this.selectedDate);
//       this.isCurrentWeek = false;
//     }
//   }
 
//   // Navigate to Next Week
//   nextWeek(): void {
//     if (!this.isCurrentWeek) {
//       this.weekOffset--;
//       this.selectedDate.setDate(this.selectedDate.getDate() + 7);
//       this.calculateWeekDates(this.selectedDate);
//       this.isCurrentWeek = this.weekOffset === 0;
//     }
//   }
 
//   //Submit Attendance
//   onSubmit(): void {
//     if (!this.empId) {
//       console.error('No Employee ID available for submission');
//       return;
//     }
 
//     if (this.attendanceForm.valid) {
//       const attendanceData: Attendance[] = this.weekDates.map(
//         (date, index) => ({
//           emp_id: this.empId!,
//           attendanceDate: new Date(date),
//           hoursFilled: this.attendanceForm.value[`hoursFilled${index}`],
//           remarks: this.attendanceForm.value[`remarks${index}`],
//           project_id: this.attendanceForm.value.project_id,
//         })
//       );
 
//       console.log('Submitting:', attendanceData);
//       this.attendanceService.addAttendance(attendanceData).subscribe(
//         (response) => {
//           console.log('Attendance added:', response);
//           this.attendanceForm.reset();
//           this.getEmployeeAttendance();
//         },
//         (error) => {
//           console.error('Error adding attendance:', error);
//         }
//       );
//     }
//   }
// }
 

import { Component, OnInit, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  NgModel,
  Validators,
} from '@angular/forms';
import { AttendanceService } from '../../services/attendance.service';
import { Attendance } from '../../Models/Attendance';
import { CommonModule } from '@angular/common';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DataTransferService } from '../../services/data-transfer.service';
 
@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule],
})
export class AttendanceComponent implements OnInit {
  attendanceForm!: FormGroup;
  weekDates: string[] = [];
  selectedDate!: Date;
  projectId!: number;
  isCurrentWeek: boolean = true;
  maxWeeksBack: number = 4; // Allow only 4 weeks back
  weekOffset: number = 0; // Tracks how many weeks back the user is
  AttendanceList: Attendance[] = [];
  displayedColumns: string[] = ['date', 'hoursFilled', 'remarks'];
  dataSource = new MatTableDataSource<Attendance>();
  attendanceStatus: string = 'N/A';
  empId!: number | null;
 
  @ViewChild(MatPaginator) paginator!: MatPaginator;
 
  constructor(
    private fb: FormBuilder,
    private attendanceService: AttendanceService,
    private dataTransferService: DataTransferService
  ) {}
 
  ngOnInit(): void {
    this.initializeForm();
    this.setCurrentWeekDates();
    this.fetchEmployeeProjectId();
 
    this.empId = this.dataTransferService.getEmpId();
    if (this.empId) {
      this.getEmployeeAttendance();
    } else {
      console.error('Employee ID not found. Attendance cannot be fetched.');
    }
  }
 
  weeklyAttendance: Attendance[] = [];
 
  getEmployeeAttendance(): void {
    if (this.empId == null) {
      console.error('No Employee ID available.');
      return;
  }
 
    const [startDt, endDt] = [new Date(this.weekDates[0]), new Date(this.weekDates[6])];
 
 
    this.attendanceService
      .getAttendanceById(this.empId, startDt, endDt)
      .subscribe(
        (data) => {
          if (data.length > 0) {
            this.weeklyAttendance = data.map((record) => ({
              emp_id: record.emp_id,
              attendanceDate: new Date(record.attendanceDate),
              hoursFilled: record.hoursFilled,
              remarks: record.remarks,
              project_id: record.project_id,
              status: record.status ? { id: record.status.id, status: record.status.status } : { id: 0, status: 'N/A' }, // Keep status as an object
            }));
            this.attendanceStatus = this.weeklyAttendance?.[this.weeklyAttendance.length - 1]?.status?.status ?? 'N/A';
          } else {
            this.weeklyAttendance = this.weekDates.map((date) => ({
              emp_id: this.empId!,
              attendanceDate: new Date(date),
              hoursFilled: 9,
              remarks: '',
              project_id: this.projectId,
              status: { id: 0, status: 'N/A' },
            }));
            this.attendanceStatus = 'N/A';
          }
        },
        (error) => {
          console.error('Error fetching attendance', error);
        }
      );
  }
 
  //Initialize Form with Weekly Fields
  initializeForm(): void {
    const formControls: { [key: string]: any } = {};
    for (let i = 0; i < 7; i++) {
      formControls[`attendanceDate${i}`] = ['', Validators.required];
      formControls[`hoursFilled${i}`] = [
        '9',
        [Validators.required, Validators.min(0), Validators.max(24)],
      ];
      formControls[`remarks${i}`] = ['', Validators.maxLength(200)];
      formControls[`projectId${i}`] = ['', Validators.required];
    }
    this.attendanceForm = this.fb.group(formControls);
  }
 
  // fetchEmployeeProjectId(): void {
  //   this.attendanceService.getEmployeeProjectId(this.empId!).subscribe(
  //     (response: any) => {  
  //       const projectId = response?.find((p: any) => p.emp_id === this.empId)?.id;
  //       if (!projectId || !this.attendanceForm) return console.warn(`No project found for employee ID: ${this.empId}`);
 
  //       this.projectId = projectId;
  //       console.log('Project ID Received:', this.projectId);
 
  //       this.attendanceForm.patchValue(Object.fromEntries([...Array(7).keys()].map(i => [`projectId${i}`, this.projectId])));
  //     },
  //     (error) => console.error('Error fetching Project ID:', error)
  //   );
  // }
  fetchEmployeeProjectId(): void {
    this.attendanceService.getEmployeeProjectId(this.empId!).subscribe(
      (response: any) => {
        const projectId = response?.find((p: any) => p.emp_id === this.empId)?.id;
        if (!projectId) {
          console.warn(`No project found for employee ID: ${this.empId}`);
          return;
        }
 
        this.projectId = projectId;
        console.log('Project ID Received:', this.projectId);
 
        // Assign project ID to each entry in weeklyAttendance
        this.weeklyAttendance.forEach(day => {
          day.project_id = this.projectId;
        });
 
        // Update the form fields
        this.attendanceForm.patchValue(
          Object.fromEntries([...Array(7).keys()].map(i => [`projectId${i}`, this.projectId]))
        );
      },
      (error) => console.error('Error fetching Project ID:', error)
    );
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
    if (!this.empId) {
      console.error('No Employee ID available for submission');
      return;
    }
 
    if (this.attendanceForm.valid) {
      const attendanceData: Attendance[] = this.weekDates.map(
        (date, index) => ({
          emp_id: this.empId!,
          attendanceDate: new Date(date),
          hoursFilled: this.attendanceForm.value[`hoursFilled${index}`],
          remarks: this.attendanceForm.value[`remarks${index}`],
          project_id: this.attendanceForm.value.project_id,
        })
      );
 
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