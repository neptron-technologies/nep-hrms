import { Component, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmpService } from '../../services/emp.service';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControl, Validator } from '@angular/forms';
import { AttendanceService } from '../../services/attendance.service';
import { Attendance } from '../../Models/Attendance';

 
@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrl: './attendance.component.css',
  standalone: false
})
export class AttendanceComponent implements OnInit {
  attendanceForm!: FormGroup;
  projectId!: number;
  emp_id: number = 101;
  weekDates: string[] = []; // Store the dates for the week (Monday to Sunday)
  selectedDate!: Date; // The date selected by the user (could be any day of the week)
  selectedDateString: string = ''; // To bind the selected date in the input field
 
  constructor(private fb: FormBuilder,
    private attendanceService: AttendanceService,
  ) { }
 
  ngOnInit(): void {
    // Initialize the form group with 7 days of data
    const formControls: { [key: string]: any } = {};
    weekStatus: ['To be Submitted']
    // Loop to create form controls for 7 days
    for (let i = 0; i < 7; i++) {
      formControls[`attendanceDate${i}`] = ['', Validators.required];
      formControls[`hoursFilled${i}`] = ['9', [Validators.required, Validators.min(0), Validators.max(24)]];
      formControls[`remarks${i}`] = ['', Validators.maxLength(200)];
      formControls[`projectId${i}`] = ['', Validators.required];
      
    }
 
    this.attendanceForm = this.fb.group(formControls);
    this.weekDates = Array(7).fill(''); 
 
    
    this.setCurrentWeekDates();
    this.fetchEmployeeProjectId(); 
  }
 
  
  getMonday(date: Date): Date {
    const d = new Date(date);
    const day = d.getDay(),
      diff = d.getDate() - day + (day == 0 ? -6 : 1); 
    return new Date(d.setDate(diff));
  }
 
 
  calculateWeekDates(selectedDate: Date): void {
    const monday = this.getMonday(selectedDate);
    const dates = [];
 
    for (let i = 0; i < 7; i++) {
      const currentDate = new Date(monday);
      currentDate.setDate(monday.getDate() + i); 
      dates.push(currentDate.toISOString().split('T')[0]);
    }
 
    this.weekDates = dates;
 
    this.weekDates.forEach((date, index) => {
      this.attendanceForm.patchValue({
        [`attendanceDate${index}`]: date
      });
    });
  }
 
 
  setCurrentWeekDates(): void {
    const currentDate = new Date(); 
    this.selectedDate = currentDate; 
    
    this.selectedDateString = currentDate.toISOString().split('T')[0];
 
    this.calculateWeekDates(this.selectedDate);
  }
 
  
  onDateChange(): void {
    const selectedDate = this.attendanceForm.get('selectedDate')?.value;
 
    if (selectedDate) {
      this.selectedDate = new Date(selectedDate);
      this.calculateWeekDates(this.selectedDate); 
    }
  }

  fetchEmployeeProjectId(): void {
    this.attendanceService.getEmployeeProjectId(this.emp_id).subscribe(
      (response: any) => {  
        const projectId = response?.find((p: any) => p.emp_id === this.emp_id)?.id;
        if (!projectId || !this.attendanceForm) return console.warn(`No project found for employee ID: ${this.emp_id}`);
  
        this.projectId = projectId;
        console.log('Project ID Received:', this.projectId);
  
        this.attendanceForm.patchValue(Object.fromEntries([...Array(7).keys()].map(i => [`projectId${i}`, this.projectId])));
      },
      (error) => console.error('Error fetching Project ID:', error)
    );
  }
  
  
  onSubmit(): void {
 
    if (this.attendanceForm.valid) {
      this.attendanceForm.patchValue({ weekStatus: "Submitted" });
      const formData = this.attendanceForm.value;
      const weekStatus = formData.weekStatus;
      let attendanceEntries = [];
     
      const attendanceData = new Attendance(
        this.attendanceForm.value.id,
        this.attendanceForm.value.emp_id,
        this.attendanceForm.value.attendance_date,
        this.attendanceForm.value.hours_filled,
        this.attendanceForm.value.remarks,
        this.attendanceForm.value.status_id,
        this.attendanceForm.value.project_id
      );
      console.log('Form Data', this.attendanceForm.value);
      this.attendanceService.addAttendance(attendanceData).subscribe(
        (response) => {
 
          console.log('Employee added:', response);
          this.resetForm();
        },
        (error) => {
 
          console.error('Error adding employee:', error);
        }
      );
    }
  }
  resetForm() {
    this.attendanceForm.reset({
      attendance_date: '',
      hours_filled: '',
      remarks: ''
    })
  }


}
 
 
 