import { Component, inject, signal, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmpService } from '../../services/emp.service';
import { Employee } from '../../Models/Employee';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-employee',
  standalone: false,
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',

})

export class EmployeeComponent implements OnInit {

  contactsVisible: boolean = false;
  skillVisible: boolean = false;
  jobHistoryVisible: boolean = false;
  editmode: boolean = false;
  PanelOpen: boolean = false;
  SidePanelOpen: boolean = false;
  employeeObj: Employee | any;
  employeeList: Employee[] = [];
  employeeForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmpService,

  ) { }

  ngOnInit(): void {

    this.initializeForm();
    this.getEmployees();

  }

  onEdit(employee: Employee) {
    this.PanelOpen = true;
    this.employeeObj = employee;
    this.editmode = true;
    this.employeeForm.patchValue({ ...employee });
  } 
  onSubmit(): void {
    if (this.employeeForm.valid) {

      const employeeData = new Employee(
        this.employeeForm.value.id,
        this.employeeForm.value.employeeCode,
        this.employeeForm.value.employeeFirstName,
        this.employeeForm.value.employeeLastName,
        this.employeeForm.value.dob,
        this.employeeForm.value.gender,
        this.employeeForm.value.doj,
        this.employeeForm.value.bloodGroup,
        this.employeeForm.value.designation,
        this.employeeForm.value.grade,
        this.employeeForm.value.active,
        this.employeeForm.value.email,
        this.employeeForm.value.contractor,
        this.employeeForm.value.address,
        this.employeeForm.value.city,
        this.employeeForm.value.state,
        this.employeeForm.value.country,
        this.employeeForm.value.pinCode,
        this.employeeForm.value.tel,
        this.employeeForm.value.jobTitle,
        this.employeeForm.value.startDate,
        this.employeeForm.value.endDate,
        this.employeeForm.value.jobLocation,
        this.employeeForm.value.salary,
        this.employeeForm.value.skills
      );
      console.log('Form Data:', this.employeeForm.value);
      if (this.editmode) {

        this.employeeService.updateEmployee(employeeData.id, employeeData).subscribe(
          (response) => {
            console.log('Employee updated successfully', response);
            Swal.fire({
              title: 'Success!',
              text: 'Employee updated successfully.',
              icon: 'success',
              confirmButtonText: 'OK',
            });

            this.resetForm();
            this.PanelOpen = false;
            this.getEmployees();
          },
          (error) => {

            Swal.fire({
              title: 'Error!',
              text: 'There was an error updating the employee.',
              icon: 'error',
              confirmButtonText: 'OK',
            });
            console.error('Error updating employee', error);
          }
        );
      } else {

        this.employeeService.addEmployee(employeeData).subscribe(
          (response) => {

            console.log('Employee added:', response);
            Swal.fire({
              title: 'Success!',
              text: 'Employee added successfully.',
              icon: 'success',
              confirmButtonText: 'OK',
            });
            this.resetForm();
            this.getEmployees();
          },
          (error) => {
            Swal.fire({
              title: 'Error!',
              text: 'There was an error adding the employee.',
              icon: 'error',
              confirmButtonText: 'OK',
            });

            console.error('Error adding employee:', error);
          }
        );
      }
    }
  }

  resetForm() {
    this.employeeForm.reset({
      employeeCode: '',
      employeeFirstName: '',
      employeeLastName: '',
      dob: '',
      gender: '',
      doj: '',
      bloodGroup: '',
      designation: '',
      grade: '',
      active: '',
      email: '',
      contractor: '',
      address: '',
      city: '',
      state: '',
      country: '',
      pinCode: '',
      phone: '',
      jobTitle: '',
      startDate: '',
      endDate: '',
      jobLocation: '',
      salary: '',
      skills: ''
    });
  }

  onDelete(id: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'Do you want to delete this employee?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it',
    }).then((result) => {
      if (result.isConfirmed) {
        this.employeeService.deleteEmployee(id).subscribe(
          (response) => {
            Swal.fire({
              title: 'Deleted!',
              text: 'Employee deleted successfully.',
              icon: 'success',
              confirmButtonText: 'OK',
            });
            this.getEmployees();
          },
          (error) => {
            Swal.fire({
              title: 'Error!',
              text: 'There was an error deleting the employee.',
              icon: 'error',
              confirmButtonText: 'OK',
            });
            console.error('Error deleting employee', error);
          }
        );
      }
    });
  }

  getEmployees() {
    this.employeeService.getEmployees().subscribe((res: any) => {
      this.employeeList = res as Employee[];

    });
  }
  openPanel() {
    this.resetForm();
    this.PanelOpen = true;
  }
  closePanel() {
    this.PanelOpen = false;
  }
  toggleContactVisibility() {
    this.contactsVisible = !this.contactsVisible;
  }
  toggleSkills() {
    this.skillVisible = !this.skillVisible;
  }
  toggleJobHistory() {
    this.jobHistoryVisible = !this.jobHistoryVisible;
  }



  generateEmployeeCode(): void {
    const code = this.getRandomCode(4);
    this.employeeForm.patchValue({
      employeeCode: code,
    });
  }


  private getRandomCode(length: number): string {
    const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    let code = '';
    for (let i = 0; i < length; i++) {
      const randomIndex = Math.floor(Math.random() * chars.length);
      code += chars[randomIndex];
    }
    return code;
  }
  private initializeForm() {


    this.employeeForm = this.fb.group({
      id: [''],
      employeeCode: [''],
      employeeFirstName: ['', Validators.required],
      employeeLastName: ['', Validators.required],
      dob: ['', Validators.required],
      gender: ['', Validators.required],
      doj: ['', Validators.required],
      bloodGroup: ['', Validators.required],
      designation: ['', Validators.required],
      grade: ['', Validators.required],
      active: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      contractor: ['', Validators.required],
      address: [''],
      city: [''],
      state: [''],
      country: [''],
      pinCode: [''],
      tel: [''],
      jobTitle: [''],
      startDate: [''],
      endDate: [''],
      jobLocation: [''],
      salary: [''],
      skills: [''],
    });


  }






}


