import { Component, inject, signal, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { EmpService } from '../../services/emp.service';
import { Employee } from '../../Models/Employee';
import Swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { formatDate } from '@angular/common';

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
  selectedFile: File | null = null;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmpService,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getEmployees();
  }

  onEdit(employee: Employee) {
    this.PanelOpen = true;
    this.employeeObj = employee;
    this.editmode = true;
    console.log(employee);
    this.employeeForm.patchValue({
      id: employee.id ?? 0,
      empCode: employee.empCode,
      fname: employee.fname,
      lname: employee.lname,
      dob: employee.dob ? formatDate(employee.dob, 'yyyy-MM-dd', 'en-US') : '',
      //dob: employee.dob,
      //gender: employee.gender ? 'Male' : 'Female',
      //doj: employee.doj,
      doj: employee.doj ? formatDate(employee.doj, 'yyyy-MM-dd', 'en-US') : '',
      bloodGroup: employee.bloodGroup,
      designation: employee.designation,
      grade: employee.grade,
      active: employee.active ? 'true' : 'false',
      email: employee.email,
      contractor: employee.contractor ? 'true' : 'false',
      company_email: employee.company_email,
      address: employee.address,
      city: employee.city,
      state: employee.state,
      country: employee.country,
      pinCode: employee.pinCode,
      tel: employee.tel,
      jobTitle: employee.jobTitle,
      startDate: employee.startDate,
      endDate: employee.endDate,
      jobLocation: employee.jobLocation,
      salary: employee.salary,
      skills: employee.skills,
    });
    // this.employeeForm.patchValue({ ...employee });
  }
  onSubmit(): void {
    if (this.employeeForm.valid) {
      const employeeData = new Employee(
        (this.employeeForm.value.id = 0),
        this.employeeForm.value.empCode,
        this.employeeForm.value.fname,
        this.employeeForm.value.lname,

        this.employeeForm.value.dob,
        //this.employeeForm.value.gender,
        this.employeeForm.value.doj,

        this.employeeForm.value.bloodGroup,
        this.employeeForm.value.designation,
        this.employeeForm.value.grade,
        this.employeeForm.value.active === 'true' ? true : false,
        this.employeeForm.value.email,
        this.employeeForm.value.contractor === 'true' ? true : false,
        this.employeeForm.value.company_email,
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

      console.log('Sending Employee Data:', employeeData);
      //console.log('Form Data:', this.employeeForm.value);
      if (this.editmode) {
        this.employeeService
          .updateEmployee(employeeData.id, employeeData)
          .subscribe(
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
            console.log('Response body:', error.error);
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
      empCode: '',
      fname: '',
      lname: '',
      dob: '',
      //gender: '',
      doj: '',
      bloodGroup: '',
      designation: '',
      grade: '',
      active: '',
      email: '',
      contractor: '',
      company_email: '',
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
      skills: '',
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
    this.employeeService.getEmpCode().subscribe({
      next: (res: any) => {
        if (res && res.empCode) {
          console.log(res.empCode);
          this.employeeForm.patchValue({
            empCode: res.empCode,
          });
        } else {
          console.error('Invalid response format', res);
        }
      },
      error: (err) => {
        console.error('Error fetching employee code:', err);
      },
    });
  }

  private initializeForm() {
    this.employeeForm = this.fb.group({
      id: [0],
      empCode: [''],
      fname: ['', Validators.required],
      lname: ['', Validators.required],
      dob: ['', Validators.required],
      //gender: ['', Validators.required],
      doj: ['', Validators.required],
      bloodGroup: ['', Validators.required],
      designation: ['', Validators.required],
      grade: ['', Validators.required],
      active: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      contractor: ['', Validators.required],
      company_email: ['', [Validators.required, Validators.email]],
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

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }
  uploadFile() {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);
      this.http.post('api_url', formData).subscribe(
        (responce) => {
          //handle responce
        },
        (error) => {
          //handle error
        }
      );
    }
  }
}
