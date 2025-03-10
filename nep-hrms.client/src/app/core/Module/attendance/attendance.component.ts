

import { Component, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmpService } from '../../services/emp.service';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
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

  weekDates: string[] = []; // Store the dates for the week (Monday to Sunday)
  selectedDate!: Date; // The date selected by the user (could be any day of the week)
  selectedDateString: string = ''; // To bind the selected date in the input field

  constructor(private fb: FormBuilder,
    private attendanceSerive: AttendanceService,
  ) { }

  ngOnInit(): void {
    // Initialize the form group with 7 days of data
    const formControls: { [key: string]: any } = {};

    // Loop to create form controls for 7 days
    for (let i = 0; i < 7; i++) {
      formControls[`attendanceDate${i}`] = ['', Validators.required];
      formControls[`hoursFilled${i}`] = ['9', [Validators.required, Validators.min(0), Validators.max(24)]];
      formControls[`remarks${i}`] = ['', Validators.maxLength(200)];
    }

    this.attendanceForm = this.fb.group(formControls);
    this.weekDates = Array(7).fill(''); // Initialize an empty array for dates

    // Auto-set the current date and calculate the week
    this.setCurrentWeekDates();
  }

  // Method to calculate the Monday of the selected date's week
  getMonday(date: Date): Date {
    const d = new Date(date);
    const day = d.getDay(),
      diff = d.getDate() - day + (day == 0 ? -6 : 1); // Get the Monday of the week
    return new Date(d.setDate(diff));
  }

  // Method to populate the week starting from Monday based on the current date
  calculateWeekDates(selectedDate: Date): void {
    const monday = this.getMonday(selectedDate); // Get the Monday of the selected week
    const dates = [];

    for (let i = 0; i < 7; i++) {
      const currentDate = new Date(monday);
      currentDate.setDate(monday.getDate() + i); // Increment the date by i days
      dates.push(currentDate.toISOString().split('T')[0]); // Push in YYYY-MM-DD format
    }

    this.weekDates = dates;

    // Auto-populate the form with the calculated dates
    this.weekDates.forEach((date, index) => {
      this.attendanceForm.patchValue({
        [`attendanceDate${index}`]: date
      });
    });
  }

  // Method to set the current week’s dates based on today's date
  setCurrentWeekDates(): void {
    const currentDate = new Date(); // Get today's date
    this.selectedDate = currentDate; // Set the selected date to today's date

    // Convert the selected date to a string in 'YYYY-MM-DD' format for input
    this.selectedDateString = currentDate.toISOString().split('T')[0];

    // Calculate and populate the week starting from the current week's Monday
    this.calculateWeekDates(this.selectedDate);
  }

  // Event handler for when the user selects a date
  onDateChange(): void {
    const selectedDate = this.attendanceForm.get('selectedDate')?.value;

    if (selectedDate) {
      this.selectedDate = new Date(selectedDate);
      this.calculateWeekDates(this.selectedDate); // Recalculate the week's dates
    }
  }

  // Handle form submission
  onSubmit(): void {

    if (this.attendanceForm.valid) {
      const attendanceData = new Attendance(
        this.attendanceForm.value.id,
        this.attendanceForm.value.attendance_date,
        this.attendanceForm.value.hours_filled,
        this.attendanceForm.value.remarks
      );
      console.log('Form Data', this.attendanceForm.value);
      this.attendanceSerive.addAttendance(attendanceData).subscribe(
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

