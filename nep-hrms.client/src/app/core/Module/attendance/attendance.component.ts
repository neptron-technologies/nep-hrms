import { Component, Input, OnInit, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  NgModel,
  Validators,
  ReactiveFormsModule,
  FormControl,
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
  imports: [CommonModule, ReactiveFormsModule],
})
export class AttendanceComponent implements OnInit {
  attendanceForm!: FormGroup;
  weekDates: string[] = [];
  selectedDate!: Date;
  //projectId!: number;
  projectId!: number;
  isCurrentWeek: boolean = true;
  maxWeeksBack: number = 4;
  weekOffset: number = 0;
  AttendanceList: Attendance[] = [];
  displayedColumns: string[] = ['date', 'hoursFilled', 'remarks'];
  dataSource = new MatTableDataSource<Attendance>();
  attendanceStatus: string = 'To be submitted';
  @Input() empId: number | null = null;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private fb: FormBuilder,
    private attendanceService: AttendanceService,
    private dataTransferService: DataTransferService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.setCurrentWeekDates();
    // this.fetchEmployeeProjectId();

    this.empId = this.dataTransferService.getEmpId();
    console.log(this.empId);
    if (this.empId) {
      console.log(this.empId);
      this.fetchProjectIdByEmpId(this.empId);
      this.getEmployeeAttendance(this.empId);
    } else {
      console.error('Employee ID not found. Attendance cannot be fetched.');
    }
  }

  weeklyAttendance: Attendance[] = [];

  getEmployeeAttendance(empId: number): void {
    console.log(empId);
    if (this.empId != null) {
      const [startDt, endDt] = [
        new Date(this.weekDates[0]),
        new Date(this.weekDates[6]),
      ];
      this.attendanceService
        .getAttendanceById(this.empId, startDt, endDt)
        .subscribe(
          (data) => {
            console.log(data);
            data.forEach((record) => {
              console.log(`Record:`, record);
              console.log(
                `emp_id:`,
                record.empId,
                `project_id:`,
                record.projectId
              );
            });
            if (data.length > 0) {
              this.weeklyAttendance = data.map((record) => ({
                // emp_id: record.emp_id,
                empId: Number(record.empId),
                attendanceDate: new Date(record.attendanceDate),
                hoursFilled: record.hoursFilled,
                remarks: record.remarks,
                //project_id: record.project_id,
                projectId: Number(record.projectId),
                status: record.status
                  ? { id: record.status.id, status: record.status.status }
                  : { id: 0, status: 'To be Submitted' }, // Keep status as an object
              }));
              const patchValues: { [key: string]: any } = {};
              this.weeklyAttendance.forEach((record, index) => {
                console.log(record);
                patchValues[`attendanceDate${index}`] = record.attendanceDate
                  .toISOString()
                  .split('T')[0];
                patchValues[`hoursFilled${index}`] = record.hoursFilled;
                patchValues[`remarks${index}`] = record.remarks;

                patchValues[`projectId${index}`] = record.projectId;
              });

              this.attendanceForm.patchValue(patchValues);
              this.attendanceStatus =
                this.weeklyAttendance?.[this.weeklyAttendance.length - 1]
                  ?.status?.status ?? 'To be Submitted';
            } else {
              this.weeklyAttendance = this.weekDates.map((date) => ({
                empId: this.empId!,
                attendanceDate: new Date(date),
                hoursFilled: 9,
                remarks: '',
                projectId: this.projectId,
                status: { id: 0, status: 'To be Submitted' },
              }));
              this.attendanceStatus = 'To be Submitted';
            }
          },
          (error) => {
            console.error('Error fetching attendance', error);
          }
        );
    }
  }

  initializeForm(): void {
    const formControls: { [key: string]: any } = {};
    this.attendanceForm = this.fb.group({});

    for (let i = 0; i < 7; i++) {
      this.attendanceForm.addControl(
        `hoursFilled${i}`,
        new FormControl(9, [
          Validators.required,
          Validators.min(0),
          Validators.max(24),
        ])
      );
      this.attendanceForm.addControl(
        `remarks${i}`,
        new FormControl('', Validators.maxLength(200))
      );
      this.attendanceForm.addControl(
        `projectId${i}`,
        new FormControl('', Validators.required)
      );
    }
  }

  fetchProjectIdByEmpId(empId: number): void {
    if (this.empId) {
      this.attendanceService
        .getEmployeeProjectId(this.empId)
        .subscribe((response: any) => {
          const projectId = response[0];
          console.log(projectId);

          this.attendanceForm.patchValue(
            Object.fromEntries(
              [...Array(7).keys()].map((i) => [`projectId${i}`, projectId])
            )
          );
          const patchValues = Object.fromEntries(
            [...Array(7).keys()].map((i) => [`projectId${i}`, projectId])
          );

          console.log('Patch Values:', patchValues);

          this.attendanceForm.patchValue(patchValues);
        });
    }
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
    if (this.empId != null) {
      this.getEmployeeAttendance(this.empId);
    }
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
          empId: this.empId!,
          attendanceDate: new Date(date),
          hoursFilled: this.attendanceForm.value[`hoursFilled${index}`],
          remarks: this.attendanceForm.value[`remarks${index}`],
          projectId: this.attendanceForm.value.projectId,
        })
      );

      console.log('Submitting:', attendanceData);
      this.attendanceService.addAttendance(attendanceData).subscribe(
        (response) => {
          console.log('Attendance added:', response);
          this.attendanceForm.reset();
          //this.getEmployeeAttendance();
          if (this.empId != null) {
            this.getEmployeeAttendance(this.empId);
          }
        },
        (error) => {
          console.error('Error adding attendance:', error);
        }
      );
    }
  }
}
