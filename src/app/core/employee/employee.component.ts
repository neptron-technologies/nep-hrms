import { Component } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee',
  standalone: false,
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {
  employeeForm: FormGroup;
  submitted = false;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private employeeService: EmployeeService) {
    this.employeeForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      department: ['', Validators.required],
      salary: ['', [Validators.required, Validators.min(1000)]]
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.employeeForm.invalid) {
      return;
    }

    this.employeeService.addEmployee(this.employeeForm.value).subscribe({
      next: () => {
        this.successMessage = 'Employee added successfully!';
        this.errorMessage = '';
        this.employeeForm.reset();
        this.submitted = false;
      },
      error: () => {
        this.errorMessage = 'Failed to add employee. Please try again.';
        this.successMessage = '';
      }
    });
  }
}
